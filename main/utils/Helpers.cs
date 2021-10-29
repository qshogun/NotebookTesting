using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NotebookTesting
{
    public class Helpers
    {
        public static Dictionary<string, string> GetData(string filePath)
        {
            var data = File
            .ReadAllLines(filePath)
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);
            return data;
        }
    }
}