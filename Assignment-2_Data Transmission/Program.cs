//Assignment 2 - Data Transmission

using Assignment_2_Data_Transmission.Models;

//Task 1 : getting list of all all directories
GetDirectoryList getDirectoryList = new GetDirectoryList();
List<string> directoriesList = getDirectoryList.GetListOfAllDirectories();

//Task 2 : Downloading info.csv file from ftp server and save it in local as info2.csv
DownloadFileInfo downloadFileInfo = new DownloadFileInfo();
downloadFileInfo.DownloadFile();

//Task 3 : Uploading info2.csv file to ftp server
UploadFileInfo2 uploadFileInfo2 = new UploadFileInfo2();
uploadFileInfo2.FileUpload();   

//Task 4 : Aggregate functions
AggregateFunctions aggregateFunctions = new AggregateFunctions();

//Task 4 : Aggregate functions : getting directories count
aggregateFunctions.GetTotalNumberOfDirectories(directoriesList);

//Task 4 : Aggregate functions : getting Min and Max of student ID
aggregateFunctions.GetMinMaxStudentId(directoriesList);

//Task 4 : Aggregate functions : finding startswith letter directories
aggregateFunctions.FindDirectoryByStartingLetter(directoriesList);

//Task 4 : Aggregate functions : finding  Contains letter directories
aggregateFunctions.FindDirectoryByContainsLetters(directoriesList);

//Task 4 : Aggregate functions : calculate the student Ids average
aggregateFunctions.CalculateStudentIdAverage(directoriesList);

//Extra task : Aggregate functions : getting student details from info.csv file and calculating the age
aggregateFunctions.GetStudentDetails();

