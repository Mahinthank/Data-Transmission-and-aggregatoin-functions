
using Azure;
using FluentFTP;
using FluentFTP.Helpers;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;

namespace Assignment_2_Data_Transmission.Models
{
    //Task 4 : Display examples of the following Aggregate functions for the list of directories:
    public class AggregateFunctions
    {
        //Task 4 : Aggregate function : Count
        public void GetTotalNumberOfDirectories(List<string> directoriesList)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("--------------- Task 4 : Count ---------------");
                Console.WriteLine($"The total number of directories in FTP = {directoriesList.Count}");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
        //Task 4 : Aggregate function : find Min & Max student id
        public void GetMinMaxStudentId(List<string> directoriesList)
        {
            try
            {
                List<int> studentIdList = new List<int>();

                foreach (string str in directoriesList)
                {
                    //extracting student id substring from directory name then convert to int and store to a list
                    int studentId;
                    string directiryName = str.Split(' ')[0];
                    Int32.TryParse(directiryName, out studentId);
                    studentIdList.Add(studentId);
                }

                int minStdId = int.MaxValue;
                int maxStdId = int.MinValue;

                if (studentIdList.Any())
                {
                    //finding Max and Min vlaue manually (without using in build methods Min() / Max())
                    foreach (int stId in studentIdList)
                    {
                        if (stId > maxStdId)
                        {
                            maxStdId = stId;
                        }

                        if (stId < minStdId)
                        {
                            minStdId = stId;
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("--------------- Task 4 : Mininum StudentId ---------------");
                Console.WriteLine($"Minimum of StudentId is {minStdId}");
                Console.WriteLine();
                Console.WriteLine("--------------- Task 4 : Maximum StudentId ---------------");
                Console.WriteLine($"Maximum of StudentId is {maxStdId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Task 4 : Aggregate function : StartsWith letter directory
        public void FindDirectoryByStartingLetter(List<string> directoriesList)
        {
            try
            {
                List<string> directoryNameList = new List<string>();

                foreach (string str in directoriesList)
                {
                    string name = str.Substring(str.IndexOf(' ') + 1);
                    directoryNameList.Add(name);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- Task 4 : StartsWith ---------------");
                Console.Write("Finding directory name : Starts with letter => ");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Console.WriteLine();
                string startingLetter = inputKey.KeyChar.ToString();

                List<String> foundedDirectories = new List<String>();

                if (directoryNameList.Any())
                {
                    //by using in built feature StartsWith() , we can easllity find the directories name 
                    //foundedDirectories = directoryNameList.Where(d => d.StartsWith(startingLetter, StringComparison.InvariantCultureIgnoreCase)).ToList();

                    //finding startswith letter directories by manual approach (without using StartsWith())
                    foreach (string name in directoryNameList)
                    {
                        if (name[0].ToString().Equals(startingLetter, StringComparison.CurrentCultureIgnoreCase))
                        {
                            foundedDirectories.Add(name);
                        }
                    }
                }

                if (foundedDirectories.Any())
                {
                    Console.WriteLine();
                    Console.WriteLine($"List of directories startwith {startingLetter.ToUpper()} : ");
                    foreach (string dir in foundedDirectories)
                    {
                        Console.WriteLine(dir);
                    }
                }
                else
                {
                    Console.WriteLine($"There are NO any directories startwith {startingLetter.ToUpper()}");
                }

                Console.WriteLine();
                Console.WriteLine($"Total Count Starts with letter : {startingLetter.ToUpper()} = {foundedDirectories.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Task 4 : Aggregate function : Contains letter(s) directory
        public void FindDirectoryByContainsLetters(List<string> directoriesList)
        {
            try
            {
                List<string> directoryNameList = new List<string>();

                foreach (string str in directoriesList)
                {
                    string name = str.Substring(str.IndexOf(' ') + 1);
                    directoryNameList.Add(name);
                }

                Console.WriteLine();
                Console.WriteLine("--------------- Task 4 : Contains ---------------");
                Console.Write("Finding directory name : Contains letter/letters => : ");
                string inputLetters = Console.ReadLine();

                if (String.IsNullOrEmpty(inputLetters))
                {
                    Console.WriteLine();
                    Console.WriteLine("You entered NOTHING. Please enter any alphabet/alphabets.");
                }
                else
                {
                    List<String> foundedDirectories = new List<String>();
                    if (directoryNameList.Any())
                    {
                        foundedDirectories = directoryNameList.Where(d => d.Contains(inputLetters, StringComparison.InvariantCultureIgnoreCase)).ToList();
                    }

                    if (foundedDirectories.Any())
                    {
                        Console.WriteLine($"List of directories Contains {inputLetters} : ");
                        foreach (string name in foundedDirectories)
                        {
                            Console.WriteLine(name);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There are NO any directories Contains {inputLetters}");
                    }
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Task 4 : Aggregate function : Average (StudentId)
        public void CalculateStudentIdAverage(List<string> directoriesList)
        {
            try
            {
                List<int> studentIdList = new List<int>();

                if (directoriesList.Any())
                {
                    foreach (string str in directoriesList)
                    {
                        int studentId;
                        string directiryName = str.Split(' ')[0];
                        Int32.TryParse(directiryName, out studentId);
                        studentIdList.Add(studentId);
                    }
                }
                //to find average we can easily use in built mehtod Average(). studentIdList.Average()
                //But here I approched to find average manually without using Average()
                double averageOfStudentIds = 0;
                if (studentIdList.Any())
                {
                    double sumOfStudenIds = 0;
                    foreach (int stdId in studentIdList)
                    {
                        sumOfStudenIds += stdId;
                    }
                    averageOfStudentIds = (double)sumOfStudenIds / (studentIdList.Count);
                }

                Console.WriteLine("--------------- Task 4 : Average (StudentId) ---------------");
                Console.WriteLine($"Average of all the StudentIds is  : {averageOfStudentIds}");
                Console.WriteLine($"Average of all the StudentIds withouty decimal point is  : {(int)averageOfStudentIds}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Extra Task : Getting student details and calculating the Age
        public void GetStudentDetails()
        {
            try
            {
                string strFilePath = ConnectionDetails.hostName + "/200526620 Mahinthan Kugendiran/info.csv";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConnectionDetails.hostName + "/200526620 Mahinthan Kugendiran/info.csv");
                request.Credentials = new NetworkCredential(ConnectionDetails.userName, ConnectionDetails.passWord);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                //read info.csv file content line by line and store in array
                string[] allLines = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                //creating DataTable to store data from info.csv file
                DataTable studentDataTable = new DataTable();

                for (int i = 0; i < allLines.Length; i++)
                {
                    if (i == 0)//to store data table column names
                    {
                        string[] headers = allLines[i].Split(',');
                        if (headers.Length > 0)
                        {
                            foreach (string header in headers)
                            {
                                //adding collumns to data table 
                                studentDataTable.Columns.Add(header);
                            }
                        }
                    }
                    else if (i > 0)// for adding data for rows
                    {
                        DataRow newRow = studentDataTable.NewRow();
                        string[] dataValues = allLines[i].Split(',');

                        for (int j = 0; j < studentDataTable.Columns.Count; j++)
                        {
                            if (String.IsNullOrEmpty(dataValues[j]))
                            {
                                newRow[j] = String.Empty;
                            }
                            else
                            {
                                newRow[j] = dataValues[j];
                            }
                        }
                        studentDataTable.Rows.InsertAt(newRow, i - 1);//insert the row data
                    }
                }

                //calculating stu;dent age
                string studentDob = (studentDataTable.Rows[0]["DateOfBirth"]).ToString();
                DateTime dob = DateTime.ParseExact(studentDob, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int studentAge = (DateTime.Today.Year - dob.Year);//calculating age in years

                //Extra task : Aggregate functions : getting student details from info.csv file and calculating the age
                Console.WriteLine("--------------- Extra Task : getting student details from info.csv file and calculating the age ---------------");
                Console.WriteLine("Student details : ");
                Console.WriteLine($"StudentId = {studentDataTable.Rows[0]["StudentId"]}");
                Console.WriteLine($"Student Name = {studentDataTable.Rows[0]["FirstName"]} {studentDataTable.Rows[0]["LastName"]}");
                Console.WriteLine($"Student B-date = {studentDataTable.Rows[0]["DateOfBirth"]}");
                Console.WriteLine($"Age = {studentAge}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
