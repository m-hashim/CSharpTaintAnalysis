using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;
using CsvHelper;
using CsvHelper.Configuration;
namespace TaintAnalysis
{
    class FullToClean{
        public void Run()
        {
            Tainted<String> TaintedString = new Tainted<string>("");
            int Counter = 0, AnotherCounter=0;
            
            using(var Reader = new  StreamReader("payload_full.csv"))
            using(var CsvReader = new CsvReader(Reader))
            {
                CsvReader.Configuration.RegisterClassMap<FullPayLoadMap>();
                
                List<FullPayLoad> Instances = CsvReader.GetRecords<FullPayLoad>().ToList();
                WriteLine($"Total no of instances is : {Instances.Count}");
                
                List<CleanPayLoad> CleanInstances = new List<CleanPayLoad>();
                
                foreach(FullPayLoad d in Instances)
                {
                    if(d.Label.Contains("norm")||d.AttackType.Contains("sqli")){
                        CleanInstances.Add(new CleanPayLoad(d.PayLoad,d.Label));
                    }
                }
                using(var Writer = new  StreamWriter("payload_clean.csv"))
                using(var CsvWriter = new CsvWriter(Writer)){
                    CsvWriter.Configuration.RegisterClassMap<CleanPayLoadMap>();
                    CsvWriter.WriteRecords(CleanInstances);
                }
            
                WriteLine($"Counter is {Counter} and another counter is {AnotherCounter}");
                ReadKey();
            }

            WriteLine(Counter);
            
        }
    }
}
