using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
namespace TaintAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            //one time run 
            //new FullToClean().Run();
      
            //Analysis of clean payload
            new CleanPayLoadAnalysis().Run();
        }
    }
}
