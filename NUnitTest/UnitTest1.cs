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
        string statesCodePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCode.csv";
        string statesCodeFileHeader = "SrNo,State,Name,TIN,StateCode";
        string WrongStatesCodePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StatesCode.csv";
        string WrongStatesCodeFileType = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCode.txt";
        string InvalidDelimiterWrongStatesCodePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\InvalidDelimiterStateCode.csv";
        string InvalidStatesCodeFIleHeaders = "SrNo,State,Name,PIN,StateCode";
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
        //Test-2.1 ->Given the States Code CSV file, Check to ensure the Number of Record matches
        [Test]
        public void Given_NumberOfRecords_Match_CSVStatesCodeData()
        {
            CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
            var actual = cSVStateCenusData.LoadStatesCodeData(statesCodePath, statesCodeFileHeader);
            Assert.AreEqual(38, actual);
        }
        //Test-2.2 ->Given the State Code CSV File if incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStatesCodeCSVFile_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadStatesCodeData(WrongStatesCodePath, statesCodeFileHeader);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        //Test-2.3 ->Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        [Test]
        public void Given_IncorrectStatesCodeCSVFileType_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadStatesCodeData(WrongStatesCodeFileType, statesCodeFileHeader);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Incorrect File Type", e.Message);
            }
        }
        //Test-2.4 ->Given the State Code CSV File when correct but delimiter incorrect Returns a customException
        [Test]
        public void Given_StatesCodeCSVFile_WhenCorrectButDelimiterIsIncorrect_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadStatesCodeData(InvalidDelimiterWrongStatesCodePath, statesCodeFileHeader);
                Assert.AreEqual(1, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Invalid Delimiters In File", e.Message);
            }
        }
        //Test-2.5 ->Given the State Code CSV File when correct but csv header incorrect Returns a custom Exception
        [Test]
        public void Given_StatesCodeCSVFile_WhenCorrectButHeaderIsIncorrect_Throw_Exception()
        {
            try
            {
                CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                var actual = cSVStateCenusData.LoadStatesCodeData(statesCodePath, InvalidStatesCodeFIleHeaders);
                Assert.AreEqual(0, actual);
            }
            catch (CenusAnalyserCustomException e)
            {
                Assert.AreEqual("Invalid Headers", e.Message);
            }
        }
    }
}