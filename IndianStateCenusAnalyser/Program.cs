using System;

namespace IndianStateCenusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = @"D:\git\IndianStateCenusAnalyser\IndianStateCenusAnalyser\Files\StateCensusData.csv";
            string fileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            CSVStateCenusData cSVStateCenusData = new CSVStateCenusData();
            cSVStateCenusData.LoadData(Path, fileHeaders);
        }
    }
}
