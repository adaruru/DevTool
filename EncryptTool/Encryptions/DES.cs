﻿using System.Security.Cryptography;
using System.Text;

public class DES
{
    /// <summary>
    /// 加密
    /// </summary>
    public static string Encrypt(string Source, string Key, string Iv)
    {
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes(Key);
            byte[] iv = Encoding.ASCII.GetBytes(Iv);
            byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

            des.Key = key;
            des.IV = iv;
            string encrypt = "";
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
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
    /// 解密
    /// </summary>
    public static string Decrypt(string Encrypt, string Key, string Iv)
    {
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes(Key);
            byte[] iv = Encoding.ASCII.GetBytes(Iv);
            des.Key = key;
            des.IV = iv;

            byte[] dataByteArray = Convert.FromBase64String(Encrypt);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
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

    public static string Encrypt(string Source, byte[] Key, byte[] Iv)
    {
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //byte[] key = Encoding.ASCII.GetBytes("jG6$q)n%");
            //byte[] iv = Encoding.ASCII.GetBytes("0(uS6B'U");
            byte[] dataByteArray = Encoding.UTF8.GetBytes(Source);

            des.Key = Key;
            des.IV = Iv;
            string encrypt = "";
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
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

    public static string Decrypt(string Encrypt, byte[] Key, byte[] Iv)
    {
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Key;
            des.IV = Iv;

            byte[] dataByteArray = Convert.FromBase64String(Encrypt);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
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
}