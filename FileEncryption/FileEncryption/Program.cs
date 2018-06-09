using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"D:\GitHub\FileEncryption.git\trunk\FileEncryption\FileEncryption\TestFiles\";

            Console.WriteLine("Encryption Starts");
            FileHandler.Action.Encript(
                rootPath + "greentea.jpg",
                rootPath + "greenteaEncrypted.jpg");
            Console.WriteLine("Encryption Ends");

            Console.WriteLine("Decription Ends");
            FileHandler.Action.Decript(
                rootPath + "greenteaEncrypted.jpg",
                rootPath + "greenteaDecrypted.jpg");
            Console.WriteLine("Decription Ends");
        }
    }
}
