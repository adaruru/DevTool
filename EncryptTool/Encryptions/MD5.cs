// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// MD5加密
/// </summary>
public class MD5
{
    /// <summary>   
    /// 1. 取得 MD5 編碼後的 Hex 字串   
    /// 2. 加密後為 32 Bytes Hex String (16 Byte)   
    /// </summary>   
    /// <span name="original" class="mceItemParam">輸入原始字串</span>   
    /// <returns> MD5 加密後字串</returns>   
    public static string Encrypt(string original)
    {
        var md5 = new MD5CryptoServiceProvider();
        byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(original));
        return BitConverter.ToString(b).Replace("-", string.Empty);
    }

    /// <summary>
    /// 取得計算後檔案的MD5值
    /// </summary>
    public static string GetFileMD5(Stream stream)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).ToLowerInvariant();
        }
    }

    /// <summary>
    /// 取得計算後檔案的MD5值
    /// </summary>
    public static string GetFileMD5(byte[] stream)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).ToLowerInvariant();
        }
    }
}