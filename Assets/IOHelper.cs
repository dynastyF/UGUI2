using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using Newtonsoft.Json;
/// <summary>
/// https://blog.csdn.net/qinyuanpei/article/details/47775979
/// </summary>

public static class IOHelper  {
    public static bool IsFileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    public static bool IsDirectoryExits(string fileName)
    {
        return Directory.Exists(fileName);
    }

    public static void CreateFile(string fileName, string content) {
        StreamWriter streamWriter = File.CreateText(fileName);
        streamWriter.Write(content);
        streamWriter.Close();
    }

    public static void CreateDirectory(string fileName) {
        if (IsDirectoryExits(fileName)) {
            return;
        }
        Directory.CreateDirectory(fileName);
    }

    public static void setData(string fileName, object pObject) {
        string toSave = SerializeObject(pObject);
        toSave = RijndaelEncrypt(toSave, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        StreamWriter streamWriter = File.CreateText(fileName);
        streamWriter.Write(toSave);
        streamWriter.Close();
    }

    public static object GetData(string fileName, Type pType)
    {
        StreamReader streamReader = File.OpenText(fileName);
        string data = streamReader.ReadToEnd();
        //对数据进行解密，32位解密密钥
        data = RijndaelDecrypt(data, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        streamReader.Close();
        return DeserializeObject(data, pType);
    }

    private static string SerializeObject(object pObject)
    {
        //序列化后的字符串
        string serializedString = string.Empty;
        //使用Json.Net进行序列化
        serializedString = JsonConvert.SerializeObject(pObject);
        return serializedString;
    }

    private static string RijndaelEncrypt(string pString, string pKey)
    {
        //密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待加密明文数组
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateEncryptor();

        //返回加密后的密文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    private static string RijndaelDecrypt(string pString, string pKey)
    {
        //解密密钥
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
        //待解密密文数组
        byte[] toEncryptArray = Convert.FromBase64String(pString);

        //Rijndael解密算法
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rDel.CreateDecryptor();

        //返回解密后的明文
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }

    private static object DeserializeObject(string pString, Type pType)
    {
        //反序列化后的对象
        object deserializedObject = null;
        //使用Json.Net进行反序列化
        deserializedObject = JsonConvert.DeserializeObject(pString, pType);
        return deserializedObject;
    }
}
