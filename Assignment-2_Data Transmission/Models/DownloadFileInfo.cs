
using System.Net;

namespace Assignment_2_Data_Transmission.Models
{
    //Task 2 : Download file info.csv and create a copy with the name info2.csv and save in local
    public class DownloadFileInfo
    {
        public void DownloadFile()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConnectionDetails.hostName + "/200526620 Mahinthan Kugendiran/info.csv");
                request.Credentials = new NetworkCredential(ConnectionDetails.userName, ConnectionDetails.passWord);
                string result = String.Empty;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                result = reader.ReadToEnd();

                //local file path to save info2.csv
                string path = @"C:\Users\Owner\Documents\0001-BDAT\Data encoding standards\Assignment 2\info2.csv";

                using (StreamWriter newFile = File.CreateText(path))
                {
                    newFile.Write(result);
                    newFile.Close();
                }
                Console.WriteLine("--------------- Taks 2 : Download file info.csv and create a copy with the name info2.csv ---------------");
                Console.WriteLine($"Download completed and new file info2.csv has been created.");

                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
