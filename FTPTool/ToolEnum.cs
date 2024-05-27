using System.ComponentModel.DataAnnotations;
public class ToolEnum
{
}
/// FTP 類型(1:FTP、2:SFTP、3:FTPS)
/// </summary>
public enum FTPType
{
    [Display(Name = "FTP")]
    FTP = 1,

    [Display(Name = "SFTP")]
    SFTP = 2,

    [Display(Name = "FTPS")]
    FTPS = 3
}
