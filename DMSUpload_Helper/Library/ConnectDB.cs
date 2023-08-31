using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;

namespace DMSUpload_Helper.Library
{
    
    public class ConnectDB
    {

        SqlCommand Com = new SqlCommand();
        SqlTransaction Transections;

        public DataTable ExecuteReader(string SQL, string datasource)
        {
            SqlConnection Con = new SqlConnection(datasource);
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                Com.CommandText = SQL;
                Com.CommandTimeout = 500;
                dt.Load(Com.ExecuteReader());
            }
            catch (Exception)
            {
                Con.Close();
                Com.Dispose();
                return dt;
            }
            Con.Close();
            Com.Dispose();
            return dt;
        }

        public void ExecuteNonQuery(string SQL, string datasource)
        {
            SqlConnection Con = new SqlConnection(datasource);
            try
            {
                Con.Open();
                Com.Connection = Con;
                Transections = Con.BeginTransaction(IsolationLevel.ReadCommitted);
                Com.Transaction = Transections;
                Com.CommandType = CommandType.Text;
                Com.CommandText = SQL;
                Com.ExecuteNonQuery();
                Transections.Commit();
                Transections.Dispose();
                Con.Close();
                Com.Dispose();
            }
            catch (Exception)
            {
                Transections.Commit();
                Transections.Dispose();
                Con.Close();
                Com.Dispose();
            }
        }

        public DataTable ExecuteReaderWithParams(string SQL, IDataParameter[] sqlParams, string datasource)
        {
            SqlConnection Con = new SqlConnection(datasource);
            DataTable dt = new DataTable();
            try
            {
                Con.Open();
                Com.Parameters.Clear();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                if (sqlParams != null)
                {
                    foreach (IDataParameter para in sqlParams)
                    {
                        if (para.Value == null || para.Value.ToString() == "")
                        {
                            para.Value = DBNull.Value;
                        }

                        Com.Parameters.AddWithValue(para.ParameterName, para.Value);
                    }
                }
                Com.CommandText = SQL;

                Com.CommandTimeout = 500;
                dt.Load(Com.ExecuteReader());
                Com.Parameters.Clear();
            }
            catch (Exception)
            {
                Con.Close();
                Com.Dispose();
                Com.Parameters.Clear();

                throw;
            }
            Con.Close();
            Com.Dispose();
            return dt;
        }

        public void ExecuteNonQueryWithParams(string SQL, IDataParameter[] sqlParams, string datasource)
        {
            SqlConnection Con = new SqlConnection(datasource);

            try
            {
                Con.Open();
                Com.Parameters.Clear();
                Com.Connection = Con;
                Com.CommandType = CommandType.Text;
                if (sqlParams != null)
                {
                    foreach (IDataParameter para in sqlParams)
                    {
                        if (para.Value == null || para.Value.ToString() == "")
                        {
                            para.Value = DBNull.Value;
                        }

                        Com.Parameters.AddWithValue(para.ParameterName, para.Value);
                    }
                }
                Com.CommandText = SQL;

                Com.CommandTimeout = 500;
                Com.ExecuteNonQuery();
                Com.Parameters.Clear();
                Con.Close();
                Com.Dispose();
                
            }
            catch (Exception)
            {
                Con.Close();
                Com.Dispose();
                Com.Parameters.Clear();

                throw;
            }
        }

        public string DecryptString2(string cipherText, string Key, string IV)
        {
            string plaintext = null;
            // Check arguments.
            try
            {
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");


                string url64 = Base64UrlEncoder.Decode(cipherText);

                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = Convert.FromBase64String(Key);
                    rijAlg.IV = Convert.FromBase64String(IV);

                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(url64)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                plaintext = null;
            }
            return plaintext;
        }

    }
}
