using System;
using System.Collections.Generic;
namespace TaintAnalysis{
    public class CleanPayLoad
    {
        
        public string PayLoad { get; set; }
        public string Label { get; set; }

        public CleanPayLoad(){}
        public CleanPayLoad(string payLoad, string label){
            this.PayLoad = payLoad;
            this.Label = label;
        }
    }
}