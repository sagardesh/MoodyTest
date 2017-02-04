using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = Console.ReadLine();
            ParseTextFile(FilePath);
        }

        private static void ParseTextFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                double[] bv = new double[3];
                double e = 0;
                var lines = File.ReadLines(filePath);
                foreach (var line in lines)
                {
                    string[] arr = line.Split(' ');
                    if(arr[0] == "E")
                        e += Compute(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2]));
                    else
                    {
                        bv = ComputeBonds(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2]), Convert.ToDouble(arr[3]));
                    }
                    
                }
                foreach(double item in bv)
                {
                    Console.WriteLine(item + e);
                }
                    
            }
        }

        private static double Compute(double n, double q)
        {
            return (n * q);
        }

        private static double[] ComputeBonds(double b, double i, double m)
        {
            double[] result = new double[3];
            result[0] = (b * Math.Pow((1 + (i - 0.01)), m));
            result[1] = (b * Math.Pow((1 + (i - 0.02)), m));
            result[2] = (b * Math.Pow((1 + (i - 0.03)), m));
            return result;
        }
    }
}
