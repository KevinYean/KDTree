using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class FileReader
    {
        private int lineNumber;
        private List<string> dataStringList;

        /// <summary>
        /// Initializes a newly created FileReader.
        /// </summary>
        public FileReader()
        {
            lineNumber = 0;
            dataStringList = new List<string>();
        }

        /// <summary>
        /// Returns the text file in a format of a list of strings for each lines.
        /// </summary>
        /// <param name="filePath"></param>
        public List<string> GetTxtFile(string filePath)
        {
            dataStringList = new List<string>();
            lineNumber = 0; //KeepsTrack of the number of lines.
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dataStringList.Add(line);
                    lineNumber++;
                }
            }
            return dataStringList;
        }

        /// <summary>
        /// Returns the line number of the most recently read file.
        /// </summary>
        /// <returns></returns>
        public int GetLineNumber()
        {
            return lineNumber;
        }

    }
}