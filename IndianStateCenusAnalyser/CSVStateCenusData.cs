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
            int numberOfRecord = 0;
            try
            {
                if (Path.GetExtension(csvFilePath) != ".csv")
                {
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INCORRECT_FILE_TYPE, "Incorrect File Type");
                }
                if (!File.Exists(csvFilePath))
                {
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.FILE_NOT_FOUND, "File Not Found");
                }
                StreamReader sr = new StreamReader(csvFilePath);
                string line;
                string[] rowData = new string[100];
                rowData = File.ReadAllLines(csvFilePath);
                if (rowData[0] != fileHeaders)
                {
                    throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INVALID_HEADERS, "Invalid Headers");
                }
                while ((line = sr.ReadLine()) != null)
                {
                    numberOfRecord++;
                    //iterate the csv data
                    foreach (string csvData in rowData)
                    {
                        if (!csvData.Contains(","))
                        {
                            throw new CenusAnalyserCustomException(CenusAnalyserCustomException.InvalidCenusdetails.INVALID_DELIMITER, "Invalid Delimiters In File");
                        }
                        else
                        {
                            Console.WriteLine("{0}" + "\t", csvData.Replace(",", " "));
                            Console.WriteLine("\t");
                        }
                    }
                }
                Console.WriteLine("total number of records:" + numberOfRecord);
            }
            catch (CenusAnalyserCustomException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return numberOfRecord;
        }
    }
}
