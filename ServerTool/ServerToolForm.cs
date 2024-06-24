using System.Diagnostics;

public partial class ServerToolForm : Form
{
    public ServerToolForm()
    {
        InitializeComponent();
    }
    private void installSmtp(object sender, EventArgs e)
    {
        string powershellCommand = $"Install-WindowsFeature -Name -IncludeAllSubFeature -IncludeManagementTools; Install-WindowsFeature -Name SMTP-Server";
        ProcessStartInfo processStartInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{powershellCommand}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            Verb = "runas" // 提升權限
        };
    }

    private void instalIIS(object sender, EventArgs e)
    {
        // Command to install IIS
        string fileName = "C:\\Windows\\system32\\DISM.EXE";  // 如果 dism.exe 不在路徑中，使用絕對路徑
        string arguments = string.Empty;
        arguments += "/Online /Enable-Feature ";
        arguments += "/FeatureName:IIS-WebServer "; // 網站伺服器
        arguments += "/FeatureName:IIS-WebServerRole "; //World Wide Web 服務 網站伺服器角色
        arguments += "/FeatureName:IIS-WebServerManagementTools "; // 網站伺服器管理工具
        arguments += "/FeatureName:IIS-ManagementConsole "; // 管理主控台
        arguments += "/FeatureName:IIS-WebServer "; // 網站伺服器
        arguments += "/FeatureName:IIS-CommonHttpFeatures "; // 常見 HTTP 功能
        arguments += "/FeatureName:IIS-StaticContent "; // 靜態內容
        arguments += "/FeatureName:IIS-DefaultDocument "; // 預設文件
        arguments += "/FeatureName:IIS-DirectoryBrowsing "; // 目錄瀏覽
        arguments += "/FeatureName:IIS-HttpErrors "; // HTTP 錯誤
        arguments += "/FeatureName:IIS-HttpRedirect "; // HTTP 重導向
        arguments += "/FeatureName:IIS-ApplicationDevelopment "; // 應用程式開發
        arguments += "/FeatureName:IIS-ASPNET45 "; // ASP.NET 4.5
        arguments += "/FeatureName:IIS-NetFxExtensibility45 "; // .NET Framework 擴展性 4.5
        arguments += "/FeatureName:IIS-NetFxExtensibility "; // .NET Framework 擴展性
        arguments += "/FeatureName:IIS-ISAPIExtensions "; // ISAPI 擴展
        arguments += "/FeatureName:IIS-ASP "; // ASP
        arguments += "/FeatureName:IIS-ISAPIFilter "; // ISAPI 篩選器
        arguments += "/FeatureName:IIS-HealthAndDiagnostics "; // 健康和診斷
        arguments += "/FeatureName:IIS-HttpLogging "; // HTTP 日誌
        arguments += "/FeatureName:IIS-LoggingLibraries "; // 日誌庫
        arguments += "/FeatureName:IIS-RequestMonitor "; // 請求監視器
        arguments += "/FeatureName:IIS-HttpTracing "; // HTTP 跟踪
        arguments += "/FeatureName:IIS-CustomLogging "; // 自訂日誌
        arguments += "/FeatureName:IIS-Security "; // 安全性
        arguments += "/FeatureName:IIS-WindowsAuthentication "; // Windows 身份驗證
        arguments += "/FeatureName:IIS-RequestFiltering "; // 請求篩選
        arguments += "/FeatureName:IIS-IPSecurity "; // IP 安全性
        arguments += "/FeatureName:IIS-Performance "; // 性能
        arguments += "/FeatureName:IIS-HttpCompressionStatic "; // 靜態 HTTP 壓縮
        arguments += "/FeatureName:IIS-WebServerManagementTools "; // 網站伺服器管理工具
        arguments += "/FeatureName:IIS-ManagementConsole "; // 管理主控台
        arguments += "/FeatureName:IIS-ManagementScriptingTools "; // 管理腳本工具
        arguments += "/FeatureName:IIS-ManagementService "; // 管理服務
        arguments += "/FeatureName:IIS-WebSockets "; // WebSockets
        arguments += "/FeatureName:IIS-CGI "; // CGI
        arguments += "/FeatureName:IIS-ServerSideIncludes "; // 伺服器端包含
        arguments += "/FeatureName:IIS-BasicAuthentication "; // 基本身份驗證
        arguments += "/FeatureName:IIS-DigestAuthentication "; // 摘要身份驗證
        arguments += "/FeatureName:IIS-WindowsAuthentication "; // Windows 身份驗證
        arguments += "/FeatureName:IIS-ClientCertificateMappingAuthentication "; // 用戶端憑證映射身份驗證
        arguments += "/FeatureName:IIS-IISCertificateMappingAuthentication "; // IIS 憑證映射身份驗證
        arguments += "/FeatureName:WAS-WindowsActivationService "; // Windows 啟用服務
        arguments += "/FeatureName:WAS-ProcessModel "; // 處理模型
        arguments += "/FeatureName:WAS-ConfigurationAPI "; // 設定 API
        arguments += "/FeatureName:WCF-Pipe-Activation45 "; // WCF 管道啟用 4.5
        arguments += "/FeatureName:WCF-TCP-Activation45 "; // WCF TCP 啟用 4.5
        arguments += "/FeatureName:WCF-TCP-PortSharing45 "; // WCF TCP 埠共用 4.5
        arguments += "/FeatureName:WCF-HTTP-Activation "; // WCF HTTP 啟用

        arguments += "/FeatureName:IIS-HttpTracing "; //HTTP 跟踪（狀況及診斷）
        //arguments += "/FeatureName:IIS-FTPServer /All"; // FTP伺服器 (FTP服務、FTP擴充性)

        ProcessStartInfo processStartInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            Verb = "runas" // 提升權限
        };

        try
        {
            using (Process process = Process.Start(processStartInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("IIS 安裝成功");
                }
                else
                {
                    MessageBox.Show("IIS 安裝失敗: " + output + "\r\n" + error + "");
                }
            }

            //using (Process process = new Process())
            //{
            //    process.StartInfo = processStartInfo;
            //    process.Start();

            //    string output = process.StandardOutput.ReadToEnd();
            //    string error = process.StandardError.ReadToEnd();

            //    process.WaitForExit();

            //    if (process.ExitCode == 0)
            //    {
            //        MessageBox.Show("IIS 安裝成功");
            //    }
            //    else
            //    {
            //        MessageBox.Show("IIS 安裝失敗: " + error);
            //    }
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show("執行安裝時發生錯誤: " + ex.Message);
        }
        MessageBox.Show("done");
    }
}