using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadData
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractInfo refpos1 = new ExtractInfo();
            Console.WriteLine("----------------------Search System.va------------------------");
            //Search the array by its keyword inside the file
            refpos1.ArrayKeyWord = "REFPOS1";

            //find the string keyword inside the file
            refpos1.FindStringKeyWord = "HOSTNAME";
            refpos1.startLineSearch = 34751;
            string FilePath = "C://files//2022-07-22//TD020R01B06//md//system.va";
            refpos1.FilePath = FilePath;
            List<string> formatArray = new List<string>();
            formatArray = refpos1.getData();

            //Show the found string keyword.
            Console.WriteLine(refpos1.FindString);

            //show the list of arrays found by the array keyword
            foreach (var num in formatArray)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine("----------------------Search Sysmat.va------------------------");
            ExtractInfo sysmast = new ExtractInfo();
            sysmast.ArrayKeyWord = "DMR_GRP[1].$MASTER_COUN";
            string FilePath1 = "C://files//2022-07-22//TD020R01B06//md//sysmast.va";
            sysmast.startLineSearch = 23;
            sysmast.FilePath = FilePath1;
            List<string> sysmatList = new List<string>();
            sysmatList = sysmast.getData();
            //show the list of arrays found by the array keyword
            foreach (var num in sysmatList)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine("----------------------Search Numreg.va------------------------");
            ExtractInfo numreg = new ExtractInfo();
            numreg.ArrayKeyWord = "$NUMREG  Storage";
            numreg.FindStringKeyWord = "MAXREGNUM";
            string FileString = "C://files//2022-07-22//TD020R01B06//md//numreg.va";
            numreg.startLineSearch = 2;
            numreg.FilePath = FileString;
            List<string> numregList = new List<string>();
            numregList = numreg.getData();
            Console.WriteLine(numreg.FindString);
            //show the list of arrays found by the array keyword
            foreach (var num in sysmatList)
            {
                Console.WriteLine(num.ToString());
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
