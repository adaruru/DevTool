// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Security.Cryptography;
using System.Text;

public class SHA256
{
    /// <summary>   
    /// SHA256加密
    /// </summary>   
    /// <span  name="original" class="mceItemParam"></span>原始字串      
    public static string Encrypt(string original)
    {
        var sha256Data = Encoding.UTF8.GetBytes(original);
        var sha256 = new SHA256Managed();
        var result = sha256.ComputeHash(sha256Data);
        return BitConverter.ToString(result).Replace("-", "").ToUpper();
    }
}