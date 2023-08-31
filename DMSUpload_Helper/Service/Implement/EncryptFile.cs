using DMSUpload_Helper.Library;
using DMSUpload_Helper.Models;
using DMSUpload_Helper.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Service.Implement
{
    public class EncryptFile : IEncryptFile
    {
        private readonly string FilePath = string.Empty;
        private readonly string _Url;
        private readonly string dmsp = string.Empty;
        private readonly byte[] arrBt = { 128, 241, 144, 21, 207, 119, 254, 207, 75, 245, 2, 55, 152, 57, 43, 1, 188, 201, 28, 205, 250, 246, 90, 46, 142, 254, 41, 57, 63, 247, 200, 130 };

        public EncryptFile()
        {
            _Url = Properties.Settings.Default.PFILE_API;
            dmsp = Properties.Settings.Default.dmsp;
            FilePath = Properties.Settings.Default.FilePath;
        }

        public Byte[] Encrypt(IFormFile fileData)
        {
            try
            {
                if (!Directory.Exists($"{FilePath}"))
                {
                    Directory.CreateDirectory($"{FilePath}");
                }
                if (!Directory.Exists($"{FilePath}Default"))
                {
                    Directory.CreateDirectory($"{FilePath}Default");
                }
                if (!Directory.Exists($"{FilePath}Encrypt"))
                {
                    Directory.CreateDirectory($"{FilePath}Encrypt");
                }
                if (!Directory.Exists($"{FilePath}Decrypt"))
                {
                    Directory.CreateDirectory($"{FilePath}Decrypt");
                }

                string[] Encryptfiles1 = Directory.GetFiles(Path.Combine($"{FilePath}Encrypt\\"));
                foreach (string fileNo in Encryptfiles1)
                {
                    var fileInfo = new FileInfo(fileNo);
                    fileInfo.Delete();
                }

                using (var fileStream = new FileStream(Path.Combine($"{FilePath}Default\\", fileData.FileName), FileMode.Create))
                {
                    fileData.CopyTo(fileStream);
                    fileStream.Close();
                }
                using (Aes encryptor = Aes.Create())
                {
                    byte[] salt = arrBt;
                    string base64String = Convert.ToBase64String(salt, 0, salt.Length);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(dmsp);

                    RijndaelManaged AES = new RijndaelManaged
                    {
                        KeySize = 256,
                        BlockSize = 128,
                        Padding = PaddingMode.PKCS7,
                        Mode = CipherMode.CBC
                    };

                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    encryptor.Key = key.GetBytes(AES.KeySize / 8);
                    encryptor.IV = key.GetBytes(AES.BlockSize / 8);

                    using (var ms = new MemoryStream())
                    {
                        fileData.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);

                        using (var fileStream = new FileStream(Path.Combine($"{FilePath}Encrypt\\", fileData.FileName), FileMode.Create))
                        {
                            using (CryptoStream cs = new CryptoStream(fileStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                using (FileStream fsInput = new FileStream(Path.Combine($"{FilePath}Default\\", fileData.FileName), FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsInput.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }

                                    fsInput.Close();
                                }
                            }

                            fileStream.Close();
                        }

                    }

                    AES.Clear();
                    AES.Dispose();

                    pdb.Dispose();

                }

                string[] files = Directory.GetFiles(Path.Combine($"{FilePath}Default\\"));
                foreach (string fileNo in files)
                {
                    var fileInfo = new FileInfo(fileNo);
                    fileInfo.Delete();
                }

                string[] files2 = Directory.GetFiles(Path.Combine($"{FilePath}Encrypt\\"));
                Byte[] bytes = null;

                foreach (string fileNo in files2)
                {
                    var fileInfo = new FileInfo(fileNo);

                    using (FileStream fsInput = new FileStream(Path.Combine(fileNo), FileMode.Open))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fsInput.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();

                            memoryStream.Close();
                        }

                        fsInput.Close();
                    }
                }

                return bytes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Byte[] EncryptFileData(IFormFile fileData, int document_id, int document_type)
        {
            try
            {
                if (!Directory.Exists($"{FilePath}"))
                {
                    Directory.CreateDirectory($"{FilePath}");
                }
                if (!Directory.Exists($"{FilePath}{document_id}_{document_type}"))
                {
                    Directory.CreateDirectory($"{FilePath}{document_id}_{document_type}");
                }
                if (!Directory.Exists($"{FilePath}{document_id}_{document_type}_Temp"))
                {
                    Directory.CreateDirectory($"{FilePath}{document_id}_{document_type}_Temp");
                }
                if (!Directory.Exists($"{FilePath}Encrypt"))
                {
                    Directory.CreateDirectory($"{FilePath}Encrypt");
                }
                if (!Directory.Exists($"{FilePath}Decrypt"))
                {
                    Directory.CreateDirectory($"{FilePath}Decrypt");
                }

                string[] Encryptfiles1 = Directory.GetFiles(Path.Combine($"{FilePath}Encrypt\\"));
                foreach (string fileNo in Encryptfiles1)
                {
                    var fileInfo = new FileInfo(fileNo);
                    fileInfo.Delete();
                }

                using (var fileStream = new FileStream(Path.Combine($"{FilePath}{document_id}_{document_type}\\", fileData.FileName), FileMode.Create))
                {
                    fileData.CopyTo(fileStream);
                    fileStream.Close();
                }
                using (Aes encryptor = Aes.Create())
                {
                    byte[] salt = arrBt;
                    string base64String = Convert.ToBase64String(salt, 0, salt.Length);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(dmsp);

                    RijndaelManaged AES = new RijndaelManaged
                    {
                        KeySize = 256,
                        BlockSize = 128,
                        Padding = PaddingMode.PKCS7,
                        Mode = CipherMode.CBC
                    };

                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
                    encryptor.Key = key.GetBytes(AES.KeySize / 8);
                    encryptor.IV = key.GetBytes(AES.BlockSize / 8);

                    using (var ms = new MemoryStream())
                    {
                        fileData.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);

                        using (var fileStream = new FileStream(Path.Combine($"{FilePath}{document_id}_{document_type}_Temp\\", fileData.FileName), FileMode.Create))
                        {
                            using (CryptoStream cs = new CryptoStream(fileStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                using (FileStream fsInput = new FileStream(Path.Combine($"{FilePath}{document_id}_{document_type}\\", fileData.FileName), FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsInput.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }

                                    fsInput.Close();
                                }
                            }

                            fileStream.Close();
                        }

                    }

                    AES.Clear();
                    AES.Dispose();

                    pdb.Dispose();

                }

                Directory.Delete(Path.Combine($"{FilePath}{document_id}_{document_type}"), true);

                string[] files2 = Directory.GetFiles(Path.Combine($"{FilePath}{document_id}_{document_type}_Temp\\"));
                Byte[] bytes = null;

                foreach (string fileNo in files2)
                {
                    var fileInfo = new FileInfo(fileNo);

                    using (FileStream fsInput = new FileStream(Path.Combine(fileNo), FileMode.Open))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fsInput.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();

                            memoryStream.Close();
                        }

                        fsInput.Close();
                    }
                }

                return bytes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Byte[] Decrypt(DownloadFile down)
        {
            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(dmsp);
                    byte[] salt = new byte[32];

                    RijndaelManaged rijndael = new RijndaelManaged();
                    var bt = Convert.FromBase64String(down.salt);
                    rijndael.KeySize = 256;
                    rijndael.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, arrBt, 50000);
                    rijndael.Key = key.GetBytes(rijndael.KeySize / 8);
                    rijndael.IV = key.GetBytes(rijndael.BlockSize / 8);
                    rijndael.Padding = PaddingMode.PKCS7;
                    rijndael.Mode = CipherMode.CBC;

                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passwordBytes, arrBt, 50000);
                    encryptor.Key = key.GetBytes(rijndael.KeySize / 8);
                    encryptor.IV = key.GetBytes(rijndael.BlockSize / 8);

                    if (!Directory.Exists($"{FilePath}Decrypt\\Image"))
                    {
                        Directory.CreateDirectory($"{FilePath}Decrypt\\Image");
                    }
                    if (!Directory.Exists($"{FilePath}Decrypt\\Document"))
                    {
                        Directory.CreateDirectory($"{FilePath}Decrypt\\Document");
                    }

                    using (var fileStream = new FileStream(Path.Combine($"{FilePath}Encrypt\\", $"{down.FileName}.{down.FileExt}"), FileMode.Open))
                    {
                        using (CryptoStream cs = new CryptoStream(fileStream, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            if (down.FileExt.ToLower() == "pdf")
                            {
                                using (FileStream fsOutput = new FileStream(Path.Combine($"{FilePath}Decrypt\\Document\\", $"{down.FileName}.{down.FileExt}"), FileMode.Create))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOutput.WriteByte((byte)data);
                                    }

                                    fsOutput.Close();
                                }
                            }
                            if (down.FileExt.ToLower() == "tiff" || down.FileExt.ToLower() == "tif")
                            {
                                using (FileStream fsOutput = new FileStream(Path.Combine($"{FilePath}Decrypt\\Image\\", $"{down.FileName}.{down.FileExt}"), FileMode.Create))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOutput.WriteByte((byte)data);
                                    }

                                    fsOutput.Close();
                                }
                            }
                        }

                        string[] Encryptfiles = Directory.GetFiles(Path.Combine($"{FilePath}Encrypt\\"));
                        foreach (string fileNo in Encryptfiles)
                        {
                            var fileInfo = new FileInfo(fileNo);
                            fileInfo.Delete();
                        }

                        fileStream.Close();
                    }
                }

                string[] files = Directory.GetFiles(Path.Combine($"{FilePath}Decrypt\\"));
                Byte[] bytes = null;

                foreach (string fileNo in files)
                {
                    var fileInfo = new FileInfo(fileNo);

                    using (FileStream fsInput = new FileStream(Path.Combine(fileNo), FileMode.Open))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            fsInput.CopyTo(memoryStream);
                            bytes = memoryStream.ToArray();

                            memoryStream.Close();
                        }

                        fsInput.Close();
                    }
                    //fileInfo.Delete();
                }

                return bytes;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }

}
