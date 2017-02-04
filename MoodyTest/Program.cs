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

        private static double Compute(double b, double i,double m,double interst)
        {
            return (b * Math.Pow((1 + (i - interst)), m));
        }

        private static double[] ComputeBonds(double b, double i, double m)
        {
            double[] result = new double[3];
            result[0] = Compute(b, i, m, 0.01);
            result[1] = Compute(b, i, m, 0.02);
            result[2] = Compute(b, i, m, 0.03);
            return result;
        }
    }
}
