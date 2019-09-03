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
            if (File.Exists("%userprofile%\\documents\\savings.txt"))
            {
                Save(savings_);
            }
            else
            {
                File.Create("%userprofile%\\documents\\savings.txt");
                Save(savings_);
            }
        }

        private static void Save(List<baseSaving> savings_)
        {
            StreamWriter sw = new StreamWriter("%userprofile%\\documents\\savings.txt",true);
            foreach (var saving in savings_)
            {
                sw.WriteLine(saving.getSavingName()+"|"+saving.getMonthlySaving() + "|" + saving.getDesiredMoney() + "|" +saving.getActualMoney() + "|" +saving.getMonths());
            }
            sw.Close();
        }

    }
}
