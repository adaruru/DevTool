// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// AES加密
/// </summary>
public class AES
{
    /// <summary>
    /// 解密
    /// </summary>
    public static string Decrypt(string encrypt, string key, string iv, CipherMode cipher, PaddingMode padding)
    {
        try
        {
            var aes = new AesCryptoServiceProvider();
            var byteKey = Encoding.ASCII.GetBytes(key);
            var byteIv = Encoding.ASCII.GetBytes(iv);
            aes.Key = byteKey;
            aes.IV = byteIv;
            aes.Mode = cipher;
            aes.Padding = padding;

            var dataByteArray = Convert.FromBase64String(encrypt);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    /// <summary>
    /// 解密
    /// </summary>
    public static string Decrypt(string encrypt, byte[] key, byte[] iv, CipherMode cipher, PaddingMode padding)
    {
        try
        {
            var aes = new AesCryptoServiceProvider();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = cipher;
            aes.Padding = padding;

            var dataByteArray = Convert.FromBase64String(encrypt);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    /// <summary>
    /// 加密
    /// </summary>
    ///  public static string Encrypt(string source, string key, string iv, CipherMode mode, PaddingMode padding)
    public static string Encrypt(string source, string key, string iv, CipherMode cipher, PaddingMode padding)
    {
        try
        {
            var aes = new AesCryptoServiceProvider();
            var byteKey = Encoding.ASCII.GetBytes(key);
            var byteIv = Encoding.ASCII.GetBytes(iv);
            var dataByteArray = Encoding.UTF8.GetBytes(source);

            aes.Key = byteKey;
            aes.IV = byteIv;
            aes.Mode = cipher;
            aes.Padding = padding;

            var encrypt = "";
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                encrypt = Convert.ToBase64String(ms.ToArray());
            }
            return encrypt;
        }
        catch (Exception)
        {

            throw;
        }

    }
    /// <summary>
    /// 加密
    /// </summary>
    public static string Encrypt(string source, byte[] key, byte[] iv, CipherMode cipher, PaddingMode padding)
    {
        try
        {
            var aes = new AesCryptoServiceProvider();
            var dataByteArray = Encoding.UTF8.GetBytes(source);

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = cipher;
            aes.Padding = padding;

            var encrypt = "";
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                    return encrypt;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }

    }
}