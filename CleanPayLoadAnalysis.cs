using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;
using CsvHelper;
using CsvHelper.Configuration;
namespace TaintAnalysis
{
    class CleanPayLoadAnalysis{
        public void Run()
        {
            Tainted<String> TaintedString = new Tainted<string>("");
            int TotalNormal = 0, TotalAnomaly = 0 ;
            int ObservedNormalTrue=0, ObservedAnomalyTrue = 0;
            int ObservedNormalFalse=0, ObservedAnomalyFalse = 0;
            
            using(var Reader = new  StreamReader("payload_clean.csv"))
            using(var CsvReader = new CsvReader(Reader))
            {
                CsvReader.Configuration.RegisterClassMap<CleanPayLoadMap>();
                
                List<CleanPayLoad> Instances = CsvReader.GetRecords<CleanPayLoad>().ToList();
                WriteLine($"Total no of instances is : {Instances.Count}");
                
                
                foreach(CleanPayLoad d in Instances)
                {
                    TaintedString = new Tainted<string>(d.PayLoad);
                    TaintedString.Untaint(new Tainted<string>.IsCleanUntaintTreatmentMethod(StringUntainter.IsFreeOfSQLInjectionUntainter));
                    if (d.Label.Equals("norm")) 
                    {
                        TotalNormal++;
                        if (TaintedString.IsClean) ObservedNormalTrue++;
                        else ObservedNormalFalse++;
                    }

                    else 
                    {
                        TotalAnomaly++;
                        if (TaintedString.IsClean) ObservedAnomalyFalse++;
                        else ObservedAnomalyTrue++;
                    }
                    
                }
            
                WriteLine($"Total Normal {TotalNormal} and Observed Normal {ObservedNormalTrue} and {ObservedNormalFalse}" );
                WriteLine($"Total Anomaly {TotalAnomaly} and Observed Anomaly {ObservedAnomalyTrue} and {ObservedAnomalyFalse}" );
                
                float CorrectPrediction = (float)(ObservedNormalTrue+ObservedAnomalyTrue)/(TotalNormal+TotalAnomaly);
                float IncorrectPrediction = (float)(ObservedNormalFalse+ObservedAnomalyFalse)/(TotalNormal+TotalAnomaly);
                
                WriteLine($"Correct Prediction is {CorrectPrediction.ToString("p")}");
                WriteLine($"Incorrect Prediction is {IncorrectPrediction.ToString("p") }");
                
                ReadKey();


            }

            
        }
    }
}
