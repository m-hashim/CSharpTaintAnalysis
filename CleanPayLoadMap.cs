using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;

namespace TaintAnalysis{
    public class CleanPayLoadMap : ClassMap<FullPayLoad>
    {
        public CleanPayLoadMap()
        {
            Map(m => m.PayLoad).Name("payload");
            Map(m => m.Label).Name("label");
        }
    }

}