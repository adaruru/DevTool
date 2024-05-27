using FluentFTP;
using Lib.Interfaces.Biz;
using Microsoft.AspNetCore.SignalR.Protocol;
using Models.DTOs;
using Models.Entities.DPAR;
using Newtonsoft.Json;
using NPOI.HPSF;
using Renci.SshNet;
using Renci.SshNet.Common;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


public class FtpService
{
    FtpClient? ftpClient;
    SftpClient? sftpClient;

    public bool IsPersistConnect { get; set; }

    /// <summary>
    /// 刪除檔案
    /// </summary>
    /// <param name="config">FTP設定</param>
    /// <param name="remoteFileName">刪除的檔案名稱</param>
    /// <param name="message">刪除失敗訊息</param>
    /// <returns>是否成功、失敗訊息</returns>
    public bool Delete(FtpInfo ftpInfo, string remoteFileName, out string message)
    {
        message = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            string ftpFolder = ftpInfo.FtpDirectory ?? string.Empty;
            string fullFileName = Path.Combine(ftpFolder, remoteFileName);

            _log.Info($"開始FTP刪除，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，檔名：{fullFileName}");

            switch (ftpInfo.FtpType)
            {
                case FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        ftpClient.DeleteFile(fullFileName);
                        //_log.Info($"檔案{fullFileName}刪除成功");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        ftpClient.DeleteFile(fullFileName);
                        //_log.Info($"檔案{fullFileName}刪除成功");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        fullFileName = fullFileName.Replace("\\", "/");
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        sftpClient.Delete(fullFileName);
                        //_log.Info($"檔案{fullFileName}刪除成功");
                        return true;
                    }
                default:
                    _log.Info($"檔案{fullFileName}刪除失敗。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);
            return false;
        }
        finally
        {
            Close();
        }
    }

    public bool DeleteDirectory(FtpInfo ftpInfo, out string message)
    {
        message = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            string ftpFolder = ftpInfo.FtpDirectory ?? string.Empty;

            _log.Info($"開始FTP刪除資料夾，設定檔:{JsonConvert.SerializeObject(ftpInfo)}");

            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        ftpClient.DeleteDirectory(ftpInfo.FtpDirectory, FtpListOption.Recursive);
                        _log.Info($"資料夾{ftpInfo.FtpDirectory}刪除成功");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        ftpClient.DeleteDirectory(ftpInfo.FtpDirectory, FtpListOption.Recursive);
                        _log.Info($"資料夾{ftpInfo.FtpDirectory}刪除成功");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        sftpClient.DeleteDirectory(ftpInfo.FtpDirectory);
                        _log.Info($"資料夾{ftpInfo.FtpDirectory}刪除成功");
                        return true;
                    }
                default:
                    _log.Info($"資料夾{ftpInfo.FtpDirectory}刪除失敗。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);
            return false;
        }
        finally
        {
            Close();
        }
    }

    /// <summary>
    /// 下載檔案
    /// </summary>
    /// <param name="config">FTP設定</param>
    /// <param name="fileName">下載檔案名稱，於已存在會將現有檔案備份新檔名</param>
    /// <param name="fullFileName">下載的檔案完整路徑</param>
    /// <param name="message">下載失敗訊息</param>
    /// <returns>是否成功、成功資訊流或失敗訊息</returns>
    public bool Download(FtpInfo ftpInfo, string fileName, string localDirectory, out string fullFileName, out string message)
    {
        message = string.Empty;
        fullFileName = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            _log.Info($"開始FTP下載，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，檔名：{fileName}");
            string localTempFolder = localDirectory ?? string.Empty;
            if (!Directory.Exists(localTempFolder))
                Directory.CreateDirectory(localTempFolder);

            string ftpFolder = ftpInfo.FtpDirectory ?? string.Empty;
            string remoteFileName = Path.Combine(ftpFolder, fileName);
            string localFullFileName = Path.Combine(localTempFolder, fileName);
            if (File.Exists(localFullFileName))
            {
                var newFileName = localFullFileName + "." + DateTime.Now.ToString("yyyyMMddHHmmss");
                _log.Info($"該檔案已存在，先進行檔案備份=>{newFileName}");
                File.Move(localFullFileName, newFileName);
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                switch (ftpInfo.FtpType)
                {
                    case SystemEnum.FTPType.FTP:
                        {
                            ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                            var ftpProfile = GetFtpProfile(ftpInfo);
                            if (!ftpClient.IsConnected)
                                ftpClient.Connect(ftpProfile);
                            bool isDownloaded = ftpClient.DownloadStream(memoryStream, remoteFileName);
                            var fileStream = File.Create(localFullFileName);
                            memoryStream.WriteTo(fileStream);
                            fileStream.Flush();
                            fileStream.Close();
                            fullFileName = localFullFileName;
                            if (!isDownloaded)
                            {
                                message = $"檔案{fileName}下載失敗";
                                _log.Info(message);
                            }

                            return isDownloaded;
                        }
                    case SystemEnum.FTPType.FTPS:
                        {
                            ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                            var ftpProfile = GetFtpsProfile(ftpInfo);
                            ftpClient.ValidateCertificate += OnValidateCertificate;
                            ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                            if (!ftpClient.IsConnected)
                                ftpClient.Connect(ftpProfile);
                            bool isDownloaded = ftpClient.DownloadStream(memoryStream, remoteFileName);
                            FileStream fileStream = File.Create(localFullFileName);
                            memoryStream.WriteTo(fileStream);
                            fileStream.Flush();
                            fileStream.Close();
                            fullFileName = localFullFileName;

                            if (!isDownloaded)
                            {
                                message = $"檔案{fileName}下載失敗";
                                _log.Info(message);
                            }

                            return isDownloaded;
                        }
                    case SystemEnum.FTPType.SFTP:
                        {
                            remoteFileName = remoteFileName.Replace("\\", "/");
                            sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                            if (!sftpClient.IsConnected)
                                sftpClient.Connect();
                            sftpClient.DownloadFile(remoteFileName, memoryStream);
                            System.IO.Directory.CreateDirectory(localDirectory);
                            FileStream fileStream = File.Create(localFullFileName);
                            memoryStream.WriteTo(fileStream);
                            //fileStream.Flush();
                            fileStream.Close();
                            fullFileName = localFullFileName;
                            _log.Info($"檔案{fileName}下載成功");
                            return true;
                        }

                    default:
                        _log.Info($"檔案{fileName}下載失敗。訊息：FTP類型錯誤");
                        return false;
                }

                memoryStream.Close();
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);
            return false;
        }
        finally
        {
            Close();
        }
    }

    // <summary>
    // 取得檔案列表
    // 如FTP取得檔案列表為空則為失敗
    // SFTP如取得空資料夾會成功
    // </summary>
    // <param name = "config" > FTP設定 </ param >
    // < param name="fileResults">回傳檔案列表</param>
    // <param name = "message" > 錯誤訊息 </ param >
    // < returns > 是否成功、失敗訊息</returns>
    public bool GetFileList(FtpInfo ftpInfo, out List<string> fileResults, out string message)
    {
        message = string.Empty;
        fileResults = new List<string>();
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            _log.Info($"開始列出FTP檔案，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，目錄：{ftpInfo.FtpDirectory}");

            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        var lists = ftpClient.GetListing(ftpInfo.FtpDirectory, FtpListOption.AllFiles);
                        fileResults = lists.Select(x => x.Name).ToList();
                        if (fileResults.Count <= 0)
                        {
                            message = "找不到任何檔案";
                            _log.Error(message);
                            return false;
                        }
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                        fileResults = lists.Select(x => x.Name).ToList();
                        if (fileResults.Count <= 0)
                        {
                            message = "找不到任何檔案";
                            _log.Error(message);
                            return false;
                        }
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        CreateDirectory(ftpInfo, out var _, false);
                        var lists = sftpClient.ListDirectory(ftpInfo.FtpDirectory);
                        fileResults = lists.Where(x => !x.IsDirectory).Select(x => x.Name).ToList();
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                default:
                    _log.Info($"檔案列出{ftpInfo.FtpDirectory}下檔案發生錯誤。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);

            return false;
        }
        finally
        {
            Close();
        }
    }

    public bool GetFileFolderList(FtpInfo ftpInfo, out List<string> fileResults, out string message)
    {
        message = string.Empty;
        fileResults = new List<string>();
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            _log.Info($"開始列出FTP檔案，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，目錄：{ftpInfo.FtpDirectory}");

            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        var lists = ftpClient.GetListing(ftpInfo.FtpDirectory, FtpListOption.AllFiles);
                        fileResults = lists.Where(x => x.SubType == FtpObjectSubType.SubDirectory).Select(x => x.Name).ToList();
                        if (fileResults.Count <= 0)
                        {
                            message = "找不到任何檔案";
                            _log.Error(message);
                            return false;
                        }
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                        fileResults = lists.Where(x => x.SubType == FtpObjectSubType.SubDirectory).Select(x => x.Name).ToList();
                        if (fileResults.Count <= 0)
                        {
                            message = "找不到任何檔案";
                            _log.Error(message);
                            return false;
                        }
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        CreateDirectory(ftpInfo, out var _, false);
                        var lists = sftpClient.ListDirectory(ftpInfo.FtpDirectory);
                        fileResults = lists.Where(x => x.IsDirectory).Select(x => x.Name).ToList();
                        _log.Info($"列出{ftpInfo.FtpDirectory}下檔案：{string.Join(",", fileResults)}");
                        fileResults.Remove(".");
                        fileResults.Remove("..");
                        return true;
                    }
                default:
                    _log.Info($"檔案列出{ftpInfo.FtpDirectory}下檔案發生錯誤。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);

            return false;
        }
        finally
        {
            Close();
        }
    }

    public FtpInfo GetFtpInfo(FTPConfig ftpConfig, string ftpFolder, Encoding encoding, int timeout = 120)
    {
        var ftpInfo = new FtpInfo()
        {
            Account = ftpConfig.FTPAccount,
            Encoding = encoding,
            FtpDataConnectionType = ftpConfig.FtpDataConnectionType,
            FtpDirectory = ftpFolder,
            FtpEncryptionMode = ftpConfig.FtpEncryptionMode,
            FtpType = ftpConfig.FTPType,
            Host = ftpConfig.FTPIp,
            Port = ftpConfig.Port,
            Mima = ftpConfig.FTPPassword,
            Timeout = timeout,
            SslProtocols = ftpConfig.SslProtocols,
            IsOverride = true
        };

        try
        {
            ftpInfo.Mima = AES.Decrypt(ftpInfo.Mima, Const.AESKey, Const.AESIv);
        }
        catch (Exception)
        {
        }

        return ftpInfo;
    }

    public bool TestConnectFTP(FtpInfo ftpInfo, out string message)
    {
        message = string.Empty;
        var result = true;
        try
        {
            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    using (var client = new FtpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima))
                    {
                        client.Connect();
                        client.Disconnect();
                    }
                    break;

                case SystemEnum.FTPType.SFTP:
                    using (var client = new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima))
                    {
                        client.Connect();
                        client.Disconnect();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            result = false;
            message = GetNewExceptionMessageWithFtpInfo(ftpInfo, "Ftp連線異常", ex);
        }
        return result;
    }

    /// <summary>
    /// 上傳檔案
    /// </summary>
    /// <param name="config">FTP設定</param>
    /// <param name="remoteFileName">下載檔案名稱</param>
    /// <param name="stream">上傳的檔案資訊流</param>
    /// <param name="message">上傳失敗訊息</param>
    /// <returns>是否成功、失敗訊息</returns>
    public bool Upload(FtpInfo ftpInfo, string remoteFileName, FileStream stream, out string message)
    {
        message = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            string ftpFolder = ftpInfo.FtpDirectory ?? string.Empty;
            string fullFileName = Path.Combine(ftpFolder, remoteFileName);

            _log.Info($"開始FTP上傳，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，檔名：{fullFileName}");

            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        if (ftpInfo.IsOverride)
                        {
                            var ftpResult = ftpClient.UploadStream(stream, fullFileName, FtpRemoteExists.Overwrite, true);
                            if (ftpResult != FtpStatus.Success)
                            {
                                _log.Error("FTP上傳發生錯誤");
                                return false;
                            }
                        }
                        else
                        {
                            var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                            var fileResults = lists.Select(x => x.Name).ToList();
                            if (fileResults.Contains(remoteFileName))
                            {
                                message = "檔案已存在";
                                _log.Error(message);
                                return false;
                            }
                        }
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        if (ftpInfo.IsOverride)
                        {
                            var ftpResult = ftpClient.UploadStream(stream, fullFileName, FtpRemoteExists.Overwrite, true);
                            if (ftpResult != FtpStatus.Success)
                            {
                                _log.Error("FTP上傳發生錯誤");
                                return false;
                            }
                        }
                        else
                        {
                            var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                            var fileResults = lists.Select(x => x.Name).ToList();
                            if (fileResults.Contains(remoteFileName))
                            {
                                message = "檔案已存在";
                                _log.Error(message);
                                return false;
                            }
                        }
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        fullFileName = fullFileName.Replace("\\", "/");
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        sftpClient.UploadFile(stream, fullFileName, ftpInfo.IsOverride);
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                default:
                    _log.Info($"檔案{fullFileName}上傳失敗。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);
            return false;
        }
        finally
        {
            Close();
        }
    }

    public bool Upload(FtpInfo ftpInfo, string remoteFileName, string localFullFileName, out string message)
    {
        message = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            string ftpFolder = ftpInfo.FtpDirectory ?? string.Empty;
            string fullFileName = Path.Combine(ftpFolder, remoteFileName);

            _log.Info($"開始FTP上傳，設定檔:{JsonConvert.SerializeObject(ftpInfo)}，檔名：{fullFileName}");

            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        if (ftpInfo.IsOverride)
                        {
                            ftpClient.UploadDataType = FtpDataType.Binary;
                            var ftpResult = ftpClient.UploadFile(localFullFileName, fullFileName, FtpRemoteExists.Overwrite, true);
                            if (ftpResult != FtpStatus.Success)
                            {
                                _log.Error("FTP上傳發生錯誤");
                                return false;
                            }
                        }
                        else
                        {
                            var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                            var fileResults = lists.Select(x => x.Name).ToList();
                            if (fileResults.Contains(remoteFileName))
                            {
                                message = "檔案已存在";
                                _log.Error(message);
                                return false;
                            }
                        }
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        if (ftpInfo.IsOverride)
                        {
                            var ftpResult = ftpClient.UploadFile(localFullFileName, fullFileName, FtpRemoteExists.Overwrite, true);
                            if (ftpResult != FtpStatus.Success)
                            {
                                _log.Error("FTP上傳發生錯誤");
                                return false;
                            }
                        }
                        else
                        {
                            var lists = ftpClient.GetListing(ftpInfo.FtpDirectory);
                            var fileResults = lists.Select(x => x.Name).ToList();
                            if (fileResults.Contains(remoteFileName))
                            {
                                message = "檔案已存在";
                                _log.Error(message);
                                return false;
                            }
                        }
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        fullFileName = fullFileName.Replace("\\", "/");
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();
                        using (var fileStream = new FileStream(localFullFileName, FileMode.Open))
                        {
                            sftpClient.UploadFile(fileStream, fullFileName, ftpInfo.IsOverride);
                            fileStream.Close();
                        }
                        _log.Info($"檔案{fullFileName}上傳成功");
                        return true;
                    }
                default:
                    _log.Info($"檔案{fullFileName}上傳失敗。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
            _log.Exception(ex);
            return false;
        }
        finally
        {
            Close();
        }
    }

    public bool CreateDirectory(FtpInfo ftpInfo, out string message, bool closConnect = true)
    {
        message = string.Empty;
        ftpInfo.EncodingName = ftpInfo.Encoding.EncodingName;
        try
        {
            switch (ftpInfo.FtpType)
            {
                case SystemEnum.FTPType.FTP:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        FtpProfile ftpProfile = GetFtpProfile(ftpInfo);
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);

                        if (!ftpClient.DirectoryExists(ftpInfo.FtpDirectory))
                            ftpClient.CreateDirectory(ftpInfo.FtpDirectory);

                        return true;
                    }
                case SystemEnum.FTPType.FTPS:
                    {
                        ftpClient = ftpClient == null ? new FtpClient() : ftpClient;
                        var ftpProfile = GetFtpsProfile(ftpInfo);
                        ftpClient.ValidateCertificate += OnValidateCertificate;
                        ServicePointManager.ServerCertificateValidationCallback = ServerCertificateValidationCallback;
                        if (!ftpClient.IsConnected)
                            ftpClient.Connect(ftpProfile);
                        if (!ftpClient.DirectoryExists(ftpInfo.FtpDirectory))
                            ftpClient.CreateDirectory(ftpInfo.FtpDirectory);
                        return true;
                    }
                case SystemEnum.FTPType.SFTP:
                    {
                        sftpClient = sftpClient == null ? new SftpClient(ftpInfo.Host, ftpInfo.Port, ftpInfo.Account, ftpInfo.Mima) : sftpClient;
                        if (!sftpClient.IsConnected)
                            sftpClient.Connect();

                        if (!sftpClient.Exists(ftpInfo.FtpDirectory))
                            sftpClient.CreateDirectory(ftpInfo.FtpDirectory);

                        return true;
                    }
                default:
                    _log.Info($"建立資料夾失敗。訊息：FTP類型錯誤");
                    return false;
            }
        }
        catch (Exception ex)
        {
            message = $"建立資料夾{ftpInfo.FtpDirectory}發生錯誤:{ex.Message}";
            _log.Exception(ex);
            return false;
        }
        finally
        {
            if (closConnect)
                Close();
        }
    }

    public void Close()
    {
        try
        {
            if (ftpClient != null)
            {
                if (ftpClient.IsConnected && !IsPersistConnect)
                    ftpClient.Disconnect();
                if (!IsPersistConnect)
                {
                    ftpClient.Dispose();
                    ftpClient = null;
                }
            }
        }
        catch (ObjectDisposedException ex)
        {
        }

        try
        {
            if (sftpClient != null)
            {
                if (sftpClient.IsConnected && !IsPersistConnect)
                    sftpClient.Disconnect();
                if (!IsPersistConnect)
                {
                    sftpClient.Dispose();
                    sftpClient = null;
                }
            }
        }
        catch (ObjectDisposedException)
        {
        }

    }

    private FtpProfile GetFtpProfile(FtpInfo ftpInfo)
    {
        return new FtpProfile()
        {
            Host = ftpInfo.Host,
            Timeout = ftpInfo.Timeout,
            Credentials = new NetworkCredential(ftpInfo.Account, ftpInfo.Mima),
            Encoding = ftpInfo.Encoding,
            DataConnection = ftpInfo.FtpDataConnectionType,
        };
    }

    private FtpProfile GetFtpsProfile(FtpInfo ftpInfo)
    {
        return new FtpProfile()
        {
            Host = ftpInfo.Host,
            Timeout = ftpInfo.Timeout,
            Credentials = new NetworkCredential(ftpInfo.Account, ftpInfo.Mima),
            DataConnection = ftpInfo.FtpDataConnectionType,
            Protocols = ftpInfo.SslProtocols,
            Encryption = ftpInfo.FtpEncryptionMode,
            Encoding = ftpInfo.Encoding
        };
    }

    ///// <summary>
    ///// 將錯誤訊息前面加上Ftp相關資訊後重新回傳
    ///// </summary>
    ///// <param name="messagePrefix">訊息前綴，此段Text會放在新錯誤訊息的最前面</param>
    ///// <param name="ex">錯誤</param>
    ///// <param name="localPath">Ftp上傳或下載的本地路徑</param>
    ///// <param name="remotePath">Ftp上傳或下載的遠端路徑</param>
    ///// <returns>結合FtpInfo的錯誤訊息</returns>
    private string GetNewExceptionMessageWithFtpInfo(FtpInfo ftpInfo, string messagePrefix, Exception ex, string localPath = null, string remotePath = null)
    {
        var infoMessage =
            $"Ftp參數資訊：【Ftp類型：{ftpInfo.FtpType.GetEnumName()}】,【主機：{ftpInfo.Host}】,【Port：{ftpInfo.Port}】,【連線帳號：{ftpInfo.Account}】";

        if (localPath != null)
            infoMessage += $",【本地位置：{localPath}】";

        if (remotePath != null)
            infoMessage += $",【遠端位置：{remotePath}】";

        if (!string.IsNullOrEmpty(messagePrefix))
            messagePrefix += "，";

        return $"{messagePrefix}{infoMessage}{Environment.NewLine}{ex.Message}";
    }

    private void OnValidateCertificate(FtpClient client, FtpSslValidationEventArgs sslValidationEventArgs)
    {
        sslValidationEventArgs.Accept = true;
    }

    private bool ServerCertificateValidationCallback(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
}
