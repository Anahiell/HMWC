using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileAds
{
   
    class BinFileWork
    {
        private string path5dig = "FivDig.txt";
        private string path2Dig = "TwoDNum.txt";
        private string pathNeg = "NegNum.txt";
        private string pathPos = "PosNum.txt";
        public void Univers(string paths)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Waiting in process...");
            Console.ForegroundColor = ConsoleColor.White;
            int cntPos = 0;
            int cntNeg = 0;
            int cnt2Dig = 0;
            int cnt5Dig = 0;

            if (File.Exists(paths))
            {
                using (var fs = new FileStream(paths, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        Int32[] some = new Int32[100000];
                        for (int i = 0; i < 100000; i++)
                        {
                            some[i] = br.ReadInt32();
                            if (some[i] >= 0)
                            {
                                cntPos++;
                                CounterPositiv(some);
                            }
                            else
                            {
                                cntNeg++;
                                CounterNegativ(some[i]);
                            }
                            if (some[i] > 9 && some[i] < 100 || some[i] < -9 && some[i] > -100)
                            {
                                cnt2Dig++;
                                CounterTwoDigit(some[i]);
                            }
                            if (some[i] > 9999 && some[i] < 99999)
                            {
                                cnt5Dig++;
                                CounterFiveDigit(some[i]);
                            }
                        }
                    }
                } 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! File not found!");
            }
            Console.WriteLine($"Count Positive number: {cntPos}\nCount Negative number: {cntNeg}\nCount Two-Diggit number: {cnt2Dig}\nCount 5-diggit number: {cnt5Dig}\n");
        }
        public void CounterPositiv(Object obj)
        {
            using (var fs = new StreamWriter(pathPos, true))
            {
                fs.WriteLine(obj);
            }
        }
        public void CounterNegativ(Object obj)
        {
            using (var fs = new StreamWriter(pathNeg,true))
            {
                fs.WriteLine(obj);
            }
        }
        public  void CounterTwoDigit(Object obj)
        {
            using (var fs = new StreamWriter(path2Dig,true))
            {
                fs.WriteLine(obj);
            }
        }
        public void CounterFiveDigit(Object obj)
        {
            using (var fs = new StreamWriter(path5dig,true))
            {
                fs.WriteLine(obj);
            }
        }
    }
}
