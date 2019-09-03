using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSavingCalculator
{
    public class baseSaving
    {
        double _monthlySaving;
        double _desiredMoney;
        double _actualMoney;
        int _monthsNumber;
        string _savingName;


        public baseSaving(double monthlySaving_, string savingName_, double desiredMoney_)
        {
            this._monthlySaving = monthlySaving_;
            this._monthsNumber = 0;
            this._savingName = savingName_;
            this._desiredMoney = desiredMoney_;
            this._actualMoney = 0;
        }


        public int getMonths()
        {
            return _monthsNumber;
        }

        public double getMonthlySaving()
        {
            return _monthlySaving;
        }

        public double getDesiredMoney()
        {
            return _desiredMoney;
        }

        public double getActualMoney()
        {
            return _actualMoney;
        }

        public string getSavingName()
        {
            return _savingName;
        }

        public int getNeededMoths()
        {
            return (int)(_desiredMoney / _monthlySaving);
        }

        public void IncreaseMoney()
        {
            _actualMoney += _monthlySaving;
        }

        public void SpendAmmount(double spentAmmount_)
        {
            _actualMoney -= spentAmmount_;
        }

        public void SpendAll()
        {
            _actualMoney = 0;
        }

        public bool GoalReached()
        {
            return _actualMoney >= _desiredMoney ? true : false;
        }

        public override string ToString()
        {
            return "Megtakarítás neve: " + _savingName + ", havi megtakarítás: " + _monthlySaving + "Ft, eddig összegyűjtött: " + _actualMoney + "Ft";
        }
    }
}
