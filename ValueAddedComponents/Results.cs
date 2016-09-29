using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueAddedComponents
{
    public class Results
    {
        private string line;
        
        //Properties
        public string Line
        {
            get { return this.line; }
        }

        public int LineLength()
        {
            return line.Length;
        }

        //Constructor
        public Results(string line)
        {
            this.line = line;
        }
    }
}
