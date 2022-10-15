
using System.Net;

namespace Assignment_2_Data_Transmission.Models
{
    //Task  : Get list of directories from server
    public class GetDirectoryList
    {
        public List<String> GetListOfAllDirectories()
        {
            List<string> directoriesList = new List<string>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConnectionDetails.hostName);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ConnectionDetails.userName, ConnectionDetails.passWord);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    //store directories names in to a List
                    directoriesList.Add(reader.ReadLine());
                }

                if (directoriesList.Any())
                {
                    Console.WriteLine("--------------- Task 1 : List of all the direcotories ---------------");
                    foreach (string item in directoriesList)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("There are no directories found!");
                }
                Console.WriteLine();

                reader.Close();
                response.Close();
                return directoriesList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return directoriesList;
            }
            
        }
    }
}
