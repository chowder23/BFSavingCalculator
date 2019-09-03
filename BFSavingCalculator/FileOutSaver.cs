using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BFSavingCalculator
{
    static class FileOutSaver
    {
        public static void SaveOut(List<baseSaving> savings_)
        {
            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\savings.txt"))
            {
                Save(savings_);
            }
            else
            {
                using (File.Create(@"C:\Users\" + Environment.UserName + @"\Documents\savings.txt"))
                {
                }
               
                Save(savings_);
            }
        }

        private static void Save(List<baseSaving> savings_)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\" + Environment.UserName + @"\Documents\savings.txt", true);
            foreach (var saving in savings_)
            {
                sw.WriteLine(saving.getSavingName()+"|"+saving.getMonthlySaving() + "|" + saving.getDesiredMoney() + "|" +saving.getActualMoney() + "|" +saving.getMonths());
            }
            sw.Close();
        }

        public static bool FileExist()
        {
            return File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\savings.txt");
        }

        public static List<baseSaving> LoadIn()
        {
            List<baseSaving> savings = new List<baseSaving>();
            baseSaving newSaving;

            using (StreamReader sr = new StreamReader(@"C:\Users\" + Environment.UserName + @"\Documents\savings.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split('|');
                    newSaving = new baseSaving(splitLine[0], (double)int.Parse(splitLine[1]), (double)int.Parse(splitLine[2]), int.Parse(splitLine[4]), (double)int.Parse(splitLine[3]));
                    savings.Add(newSaving);
                }
                
            }

            return savings;
        }
    }
}
