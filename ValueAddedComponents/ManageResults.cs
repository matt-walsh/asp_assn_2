using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ValueAddedComponents
{
    public class ManageResults
    {
        StreamWriter writer;
        StreamReader reader;

        private string fileName;

        public ManageResults(string fileName)
        {
            this.fileName = fileName + ".txt";
        }

        public bool WriteOutput(List<Results> results)
        {
            try
            {
                writer = new StreamWriter(this.fileName);
            }
            catch (Exception e)
            {
            }
            

            using (writer)
            {
                foreach (Results line in results)
                {
                    try
                    {
                        writer.WriteLine(line.Line);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }               
            }

            return true;
        }

        public List<Results> ReadOutput()
        {
            try
            {
                reader = new StreamReader(fileName);
            }
            catch (Exception e)
            {
            }

            List<Results> returnList = new List<Results>();
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //We want to remove all white space, for ease of parsing

                    //Holds the new string to be created
                    string newLine = "";

                    //Remove leading and trailing whitespace
                    line.Trim();

                    //remove spaces inside string
                    for (int i = 0; i < line.Length - 1; i++)
			        {
                        if (line[i] != ' ')
                        {
                            newLine += line[i];
                        }
			        }

                    returnList.Add(new Results(newLine));
                }
            }

            return returnList;
        }
    }
}
