using IndianStateCenusAnalyser;
using NUnit.Framework;

namespace NUnitTest
{
    public class Tests
    {
        string csvFilePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCensusData.csv";
        string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        string WrongFilePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCenusData.csv";
        string WrongFileType= @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCensusData.txt";
        string InvalidDelimiterFilePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\InvalidDelimiterStateCensusData.csv";
        string InvalidFileHeaders = "State,Population,AreaInSqK,DensityPerSqKm";
        [SetUp]
        public void Setup()
        {
            
        }
        //Test-1.1 ->Given the States Census CSV file, Check to ensure the Number of Record matches
        [Test]
        public void Given_NumberOfRecords_Match_CSVStateData()
        {
            CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
            var actual=cSVStateCenusData.LoadData(csvFilePath, fileHeaders);
            Assert.AreEqual(30,actual);
        }
        //Test-1.2 ->Given the State Census CSV File if incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStateCensusCSVFile_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadData(WrongFilePath, fileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        //Test-1.3 ->Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStateCensusCSVFileType_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadData(WrongFileType, fileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }
        //Test-1.4 ->Given the State Census CSV File when correct but delimiter incorrect Returns a customException
        [Test]
        public void Given_StateCensusCSVFile_WhenCorrectButDelimiterIsIncorrect_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadData(InvalidDelimiterFilePath, fileHeaders);
                Assert.AreEqual(1, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Invalid Delimiters In File", e.Message);
            }
        }
        //Test-1.5 ->Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void Given_StateCensusCSVFile_WhenCorrectButHeaderIsIncorrect_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadData(csvFilePath, InvalidFileHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Invalid Headers", e.Message);
            }
        }
    }
}