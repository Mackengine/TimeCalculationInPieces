using System;
using System.Collections.Generic;

namespace ReadTextandCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            string userLine = "";
            string inputFile, outputFile, outputPath, inputPath;
            List<string> fileData = new List<string>();
            List<string> userLines = new List<string>();
            List<string> outputTimes = new List<string>();

            Console.WriteLine("Please enter the full file path to the timestamp file to be read in");
            inputPath = Console.ReadLine();
            Console.WriteLine("Please enter your times without decimal separators (eg. for 4512 for 4.512 seconds, or 4500 for 4.500 seconds) \n");
            Console.WriteLine("When you are finished, type 'quit' to exit \n");

            while(userLine.ToLower() != "quit")
            {
                Console.WriteLine("Enter time for run " + (counter + 1) + "\n");
                userLine = Console.ReadLine();
                userLines.Add(userLine);
                counter++;
            }

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(inputPath);
            while ((line = file.ReadLine()) != null)
            {
                if (line != "000000" && line != "")
                {
                    fileData.Add(line);

                }
            }
            foreach(string dataPoint in fileData)
            {
                Console.WriteLine(dataPoint);
            }

            file.Close();

            //Calculate the difference between times
            foreach(string timeStamp in fileData)
            {
                int timeStampCounter = 0;
                int tempFileStamp, tempUserStamp, tempResultStamp;
                string tempOutStamp;
                tempFileStamp = Int32.Parse(timeStamp);
                Console.WriteLine("Temporary timestamp from file " + tempFileStamp);
                tempUserStamp = Int32.Parse(userLines[timeStampCounter]);
                Console.WriteLine("Temporary timestamp from user " + tempUserStamp);
                tempResultStamp = tempFileStamp - tempUserStamp;
                if(tempResultStamp < 0)
                {
                    tempResultStamp = tempResultStamp + 1000;
                }
                Console.WriteLine("Resulting Operation " + tempResultStamp);
                tempOutStamp = tempResultStamp.ToString();
                if(tempOutStamp.Length == 5)
                {
                    tempOutStamp = tempOutStamp + "0";
                }
                else if(tempOutStamp.Length == 4)
                {
                    tempOutStamp = tempOutStamp + "00";
                }
                else if(tempOutStamp.Length == 3)
                {
                    tempOutStamp = tempOutStamp + "000";
                }
                else if(tempOutStamp.Length == 2)
                {
                    tempOutStamp = tempOutStamp + "0000";
                }
                else if (tempOutStamp.Length == 1)
                {
                    tempOutStamp = tempOutStamp + "00000";
                }
                tempOutStamp = Reverse(tempOutStamp);
                tempOutStamp = tempOutStamp.Insert(0, "?");
                Console.WriteLine("Reversed string " + tempOutStamp);
                outputTimes.Add(tempOutStamp);
            }
            Console.WriteLine("Please enter the name of the file to write to ");
            outputFile = Console.ReadLine();
            outputPath = "C:\\Users\\Public\\";
            outputPath = outputPath + outputFile;
            Console.WriteLine(outputPath);

            foreach(string outputStamp in outputTimes)
            {
                using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(outputPath, true))
                {
                    outfile.WriteLine(outputStamp);
                }
                Console.WriteLine(outputStamp);
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
