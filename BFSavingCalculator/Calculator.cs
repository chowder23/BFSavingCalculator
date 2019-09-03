using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSavingCalculator
{
    public static class Calculator
    {
        static List<baseSaving> _allSaving = new List<baseSaving>();
        static double _mySalary;
        static double _myActualMoney;
        static string _myName;
        static double _currentSalary;
        static bool going = true;
        public static void addSaving()
        {
            Console.WriteLine("Mi a megtakarítás neve?");
            string savingName = Console.ReadLine();
            Console.WriteLine("Mennyit akarsz félrerakni havonta?");
            double monthlySaving = (double)int.Parse(Console.ReadLine());
            Console.WriteLine("Mennyi pénzt akarsz összegyűjteni?");
            double desiredSaving = (double)int.Parse(Console.ReadLine());
            _allSaving.Add(new baseSaving(monthlySaving, savingName, desiredSaving));
        }

        public static void setMySalary(double mySalary_)
        {
            _mySalary = mySalary_;
            _currentSalary = mySalary_;
        }

        public static void Init()
        {
            Console.WriteLine("Mi a neved?");
            _myName = Console.ReadLine();
            Console.WriteLine("Mennyi a körülbelüli havi fizetésed amivel számolni szeretnél?(kesőbb megváltoztatható)");
            setMySalary((double)int.Parse(Console.ReadLine()));

        }

        public static bool ReadFiles()
        {
            return false;
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Profil \n2. Új megtakarítás hozzáadása \n3.Fennmaradó havi kereset \n4.Megtakarítások listázása \n5.Kilépés");

        }
        private static void ShowProfile()
        {
            Console.WriteLine("Neved: " + _myName + "\nJövedelmed: " + _mySalary + "\nMegmaradt jövedelem: " + _currentSalary);
            Console.ReadLine();
        }

        private static void RemaningSalary()
        {
            double tmp = 0;
            foreach (baseSaving saving in _allSaving)
            {
                tmp += saving.getMonthlySaving();
            }
            Console.WriteLine("A fennmaradó havi jövedelme: " + (_mySalary - tmp));
        }

        private static void SavingsListing()
        {
            foreach (baseSaving saving in _allSaving)
            {
                Console.WriteLine(saving.ToString());
            }
            Console.ReadLine();
        }

        private static void ReadMenuInput()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowProfile();
                    break;
                case "2":
                    addSaving();
                    break;
                case "3":
                    RemaningSalary();
                    break;
                case "4":
                    SavingsListing();
                    break;
                case "5":
                    going = false;
                    break;
                default:
                    break;

            }
        }

        public static void Start()
        {
            bool first = true;
            while (going)
            {

                if (ReadFiles())
                {

                }
                else if (first)
                {
                    Init();
                    first = false;
                    ShowMenu();
                    ReadMenuInput();
                }
                else
                {
                    ShowMenu();
                    ReadMenuInput();
                }
            }
        }
    }
}

