using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace IndianStateCenusAnalyser
{
    public class CSVStateCenusData
    {
        public string csvFilePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCensusData.csv";
        public string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public object LoadData(string csvFilePath,string fileHeaders)
        {
            try
            {
                if (!File.Exists(csvFilePath))
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.FILE_NOT_FOUND, "File Not Found");
                if (Path.GetExtension(csvFilePath) != ".csv")
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INCORRECT_FILE_TYPE, "Incorrect File Type");
                StreamReader sr = new StreamReader(csvFilePath);
                string line;
                string[] rowData = new string[100];
                int numberOfRecord = 0;
                rowData = File.ReadAllLines(csvFilePath);
                if (rowData[0] != fileHeaders)
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INVALID_HEADERS, "Invalid Headers");

                while ((line = sr.ReadLine()) != null)
                {
                    numberOfRecord++;
                    rowData = line.Split(',');
                    if (rowData.Contains(","))
                        throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INVALID_DELIMITER, "Invalid Delimiters In File");
                     //iterate the csv data
                    foreach (string csvData in rowData)
                    {
                        Console.Write("{0}" + "\t", csvData + "{0}" + "\t" + "\t", csvData);
                    }
                }
                Console.WriteLine("total number of records:" + numberOfRecord);
                return numberOfRecord;
            }
            catch (CenusAnalyserCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.FILE_NOT_FOUND, "File Not Found");
        }
    }
}
