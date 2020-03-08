using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Backend_ApiNetCore3_1.Domain.Core.Models
{
    public abstract class CustomEntityWithLog<T> : BaseEntity<T> where T : IEquatable<T>
    {
        public int UpdaterUserId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }

    public abstract class CustomEntity<T> : BaseEntity<T> where T : IEquatable<T>
    {
        public int UpdaterUserId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }

    public abstract class BaseEntity<T> where T : IEquatable<T>
    {
        #region Properties
        public T Id { get; protected set; }

        #endregion


        #region Operators

        public static bool operator ==(BaseEntity<T> a, BaseEntity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<T> a, BaseEntity<T> b)
        {
            return !(a == b);
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public string Encrypt(string value)
        {


            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(GetKey(), GetIV()))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(value);
                            }
                        }

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[GetIV().Length + decryptedContent.Length];

                        Buffer.BlockCopy(GetIV(), 0, result, 0, GetIV().Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, GetIV().Length, decryptedContent.Length);

                        value = Convert.ToBase64String(result);
                    }
                }
            }

            return value;

        }

        public string Decrypt(string value)
        {


            var fullCipher = Convert.FromBase64String(value);

            using (var aesAlg = Aes.Create())
            {

                var cipher = new byte[fullCipher.Length - GetIV().Length];

                Buffer.BlockCopy(fullCipher, 0, GetIV(), 0, GetIV().Length);
                Buffer.BlockCopy(fullCipher, GetIV().Length, cipher, 0, cipher.Length);

                using (var decryptor = aesAlg.CreateDecryptor(GetKey(), GetIV()))
                {

                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                value = srDecrypt.ReadToEnd();
                            }
                        }
                    }


                }
            }



            return value;


        }

        private static byte[] GetKey()
        {
            return Encoding.UTF8.GetBytes(Settings.Secret);
        }

        private static byte[] GetIV()
        {
            return new byte[16];
        }

        #endregion
    }
}