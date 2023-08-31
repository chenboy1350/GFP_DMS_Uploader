using DMSUpload_Helper.Library;
using DMSUpload_Helper.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace DMSUpload_Helper.Service.Interface
{
    public interface IEncryptFile
    {
        Byte[] Decrypt(DownloadFile down);
        byte[] Encrypt(IFormFile fileData);
        byte[] EncryptFileData(IFormFile fileData, int document_id, int document_type);
    }
}
