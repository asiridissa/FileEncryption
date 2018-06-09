using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileHandler
{
    public static class Action
    {
        private static string Key = @"myKey123"; // Your Key Here
        static UnicodeEncoding _ue = new UnicodeEncoding();
        static RijndaelManaged _rmCrypto = new RijndaelManaged();

        ///<summary>
        /// Asiri Dissanayaka - 09/06/2018.
        ///
        /// Encrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile">Input file path</param>
        ///<param name="outputFile">Output file path</param>
        public static void Encript(string inputFile, string outputFile)
        {
            try
            {
                byte[] key = _ue.GetBytes(Key);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                CryptoStream cs = new CryptoStream(fsCrypt, _rmCrypto.CreateEncryptor(key, key), CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
                //todo: do your exception handling here
            }
        }

        ///<summary>
        /// Asiri Dissanayaka - 09/06/2018.
        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile">Input file path</param>
        ///<param name="outputFile">Output file path</param>
        public static void Decript(string inputFile, string outputFile)
        {
            try
            {
                byte[] key = _ue.GetBytes(Key);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                CryptoStream cs = new CryptoStream(fsCrypt, _rmCrypto.CreateDecryptor(key, key), CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                //todo: do your exception handling here
            }
        }
    }
}
