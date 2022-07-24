using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReadData
{
    public class ExtractInfo
    {
        public string FindString { get; set; }

        public string FindStringKeyWord { get; set; }
        public string FilePath { get; set; }
        public string ArrayKeyWord { get; set; }
        public int startLineSearch { get; set; }

        public List<string> getData()
        {
            List<string> ExtractedInfo = new List<string>();
            string lines = "";
            LinkedList<string> ls = new LinkedList<string>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                while ((lines = sr.ReadLine()) != null)
                {
                    ls.AddLast(lines);
                }
            }
            int i = 0;
            int linePointer = startLineSearch;
            int lastLinePointer = 0;
            foreach (var item in ls)
            {
                int lineNumber = 0;
                
                if (FindStringKeyWord!=null && item.Contains(FindStringKeyWord))
                {
                    FindString = item;
                }
                if (item.Contains("ARRAY") && item.Contains(ArrayKeyWord))
                {

                    string checkS = Regex.Replace(item, @"[^\d]", "");
                    if (checkS.Length == 3)
                    {
                        lineNumber = Convert.ToInt32(checkS.Substring(2));
                    }
                    else if (checkS.Length == 4)
                    {
                        lineNumber = Convert.ToInt32(checkS.Substring(3));
                    }else if (checkS.Length == 2)
                    {
                        lineNumber = Convert.ToInt32(checkS.Substring(1));
                    }
                    else
                    {
                        lineNumber = Convert.ToInt32(checkS);
                    }


                    linePointer = i;
                    lastLinePointer = linePointer + lineNumber;

                }

                if (i > linePointer && i <= lastLinePointer)
                {
                    string textFormat = Regex.Replace(item, @"[^0-9a-zA-Z:,+-.]+", "");
                    textFormat = Regex.Replace(textFormat, @"[a-z]|[A-Z]", "");
                    if (textFormat.Length == 1)
                    {
                        textFormat = Regex.Replace(textFormat, @"[0-9]", "");
                    }

                    int countLength = textFormat.Length;
                    string formatTextSub = "";
                    if (textFormat != "")
                    {
                        formatTextSub = textFormat.Substring(1, countLength - 1);
                    }

                    try
                    {
                        ExtractedInfo.Add(formatTextSub);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.ToString());
                    }



                }


                i++;


            }

            return ExtractedInfo;
        }
    }
}
