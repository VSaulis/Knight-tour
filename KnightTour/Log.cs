using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KnightTour
{
    public class Log
    {
        private List<string> _log;
        private string _filePath;

        public Log()
        {
            _filePath = @"C:\Users\Vytautas\source\repos\KnightTour\Result\result.txt";
            _log = new List<string>();
        }

        public void AddToLog(string record) 
        {
            _log.Add(record);
        }

        public void WriteToFile() 
        {
            File.WriteAllLines(_filePath, _log);
        }

    }
}
