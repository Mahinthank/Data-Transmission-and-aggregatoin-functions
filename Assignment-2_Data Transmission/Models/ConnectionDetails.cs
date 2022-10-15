using FluentFTP;
using System;
using System.IO;
using System.Net;

namespace Assignment_2_Data_Transmission.Models
{
    //This class contains login information to connect with server
    public static class ConnectionDetails// : System.Net.Http.HttpMessageInvoker
    {
        //testing path1 @"ftp://waws-prod-yt1-039.ftp.azurewebsites.windows.net/22F_BDAT1001/01_BDAT1001_10886"
        //testing path2 @"ftp://waws-prod-yt1-039.ftp.azurewebsites.windows.net/01_BDAT1001_10886"
       
        //login credentioals 
        public static readonly string hostName = @"ftp://waws-prod-yt1-039.ftp.azurewebsites.windows.net/22F_BDAT1001/01_BDAT1001_10886";//200526620 Mahinthan Kugendiran
        public static readonly string userName = @"ftpservernital\bdat1001-user";
        public static readonly string passWord = "Bdat1001#";
    }
}
