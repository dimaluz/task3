using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            List<Double> [] Cashes = new List<Double>[5];

            String path = args[0];
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            Int32 index = 0;

            foreach (FileInfo file in files) {
                String filepath = path +@"\"+ file.Name;
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                StreamReader read = new StreamReader(fs);
                Cashes[index] = new List<Double>();
                Boolean isNum; Double value;
                while (!read.EndOfStream) {
                    String str = read.ReadLine();
                    isNum=Double.TryParse(str, out value);
                    if(isNum)
                        Cashes[index].Add(value);
                }
                index++;
                read.Close();
                fs.Close();
            }

            Double[] results = new Double[16];
            Double[] intervals = new Double[16];
            Double sum = 0.0;
            for (Int32 i = 0; i < 16; i++) {
                for (Int32 j = 0; j < 5; j++) {
                    sum += Cashes[j][i];
                }
                results[i] = sum; intervals[i] = i + 1;
                sum = 0.0;
            }
            Double val =results[0]; Int32 pos=0;
            for(Int32 i=0; i < 16; i++)
                if(val < results[i]){
                    val = results[i]; pos = i;
                }
            Console.WriteLine(pos);
            Console.Read();
        }
    }
}
