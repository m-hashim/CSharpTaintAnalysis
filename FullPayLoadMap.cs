using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;

namespace TaintAnalysis{
    public class FullPayLoadMap : ClassMap<FullPayLoad>
    {
        public FullPayLoadMap()
        {
            Map(m => m.PayLoad).Name("payload");
            Map(m => m.Length).Name("length");
            Map(m => m.AttackType).Name("attack_type");
            Map(m => m.Label).Name("label");
        }
    }

}