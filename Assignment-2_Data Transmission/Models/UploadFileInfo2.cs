using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Data_Transmission.Models
{
    public class UploadFileInfo2
    {
        //file for uploading to the FTP server
        static string filePath = @"C:\Users\Owner\Documents\0001-BDAT\Data encoding standards\Assignment 2\info2.csv";

        public void FileUpload()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConnectionDetails.hostName + "/200526620 Mahinthan Kugendiran/info2.csv");
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ConnectionDetails.userName, ConnectionDetails.passWord);

                byte[] fileContent;
                using (StreamReader sourceStream = new StreamReader(filePath))
                {
                    //read the file contents in bytes array
                    fileContent = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                }

                request.ContentLength = fileContent.Length;

                using (Stream reqStream = request.GetRequestStream())
                {
                    //write content to info2.csv
                    reqStream.Write(fileContent, 0, fileContent.Length);
                }

                using (FtpWebResponse ftpWebResponse = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine();
                    Console.WriteLine("--------------- Taks 3 : Upload info2.csv to ftp server ---------------");
                    Console.WriteLine("Upload is completed!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
