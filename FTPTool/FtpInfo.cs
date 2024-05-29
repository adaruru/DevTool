
using FluentFTP;
using Newtonsoft.Json;
using System.Text;

public class FtpInfo
{
    /// <summary>
    /// 使用者帳號
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// FTP傳輸編碼
    /// </summary>
    [JsonIgnore]
    public Encoding Encoding { get; set; }

    public string EncodingName { get; set; }

    /// <summary>
    /// FTP連線模式
    /// </summary>
    public FluentFTP.FtpDataConnectionType FtpDataConnectionType { get; set; }

    /// <summary>
    /// 預設目錄
    /// </summary>
    public string FtpDirectory { get; set; }

    /// <summary>
    /// FTPS 加密模式
    /// </summary>
    public FtpEncryptionMode FtpEncryptionMode { get; set; }

    /// <summary>
    /// SSHKey
    /// </summary>
    public string FtpSSHKey { get; set; }

    /// <summary>
    /// 連線類型
    /// </summary>
    public SystemEnum.FTPType FtpType { get; set; }

    /// <summary>
    /// 主機位置
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// 當FTP上有同檔名時是否刪除
    /// 如設為False則當同檔案存在時將會報錯
    /// </summary>
    public bool IsOverride { get; set; }

    /// <summary>
    /// 密碼
    /// </summary>
    [JsonIgnore]
    public string Mima { get; set; }

    /// <summary>
    /// Port
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// FTPS SSL通訊協定
    /// </summary>
    public SslProtocols SslProtocols { get; set; }

    /// <summary>
    /// FTP連線逾時時間
    /// </summary>
    public int Timeout { get; set; }
}
