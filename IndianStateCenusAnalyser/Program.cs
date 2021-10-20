using System;

namespace IndianStateCenusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCensusData.csv";
            string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            string statesCodePath = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCode.csv";
            string statesCodeFileHeader = "SrNo,State,Name,TIN,StateCode";
            int options;
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("choose 1.AnalyseIndianStateCSVData 2.AnalyseIndianStatesCodeCSVData");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
                        cSVStateCenusData.LoadData(path, fileHeaders);
                        break;
                    case 2:
                        CSVStateCenusData cSVStatesCodeCenusData = new CSVStateCenusData();
                        cSVStatesCodeCenusData.LoadStatesCodeData(statesCodePath, statesCodeFileHeader);
                        break;
                    default:
                        Console.WriteLine("Choose valid options");
                        break;
                }
            }
        }
    }
}
