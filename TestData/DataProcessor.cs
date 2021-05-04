using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;

namespace TestData
{
    public class DataProcessor
    {
        public enum OutputType { Clipboard, TextOnly, File }

        public OutputType OutputMethod { get; set; }

                 
        public string OutputData(LinkedList<string> numberList, OutputType outputMethod)
        {
            var _numberList = numberList;
            var _outputMethod = outputMethod;
            var output = "";
            

            switch (_outputMethod) 
            {
                case OutputType.Clipboard:
                    output = _numberList.First.Value;
                    Clipboard.SetText(output);
                    break;

                case OutputType.TextOnly:
                    output = _numberList.First.Value;
                    break;

                case OutputType.File:
                    writeToFile(_numberList);
                    output = "NumberList.txt --> Desktop";
                    break;

                default:
                    output = _numberList.First.Value;
                    break;
            }

            return output;
        }

        private void writeToFile(LinkedList<string> numberList)
        {
            var _numberList = numberList;
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderPath, "NumberList.txt")))
            {
                foreach (string item in _numberList)
                    outputFile.WriteLine(item);
            }
        }
    }
}
