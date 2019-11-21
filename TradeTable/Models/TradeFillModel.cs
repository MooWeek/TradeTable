using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeTable.Models
{
    class TradeFillModel : INotifyPropertyChanged
    {
        public DateTime FillingDate { get; set; } = DateTime.Now;

        private double _balance;
        private double _newBalance;
        private int _bets;
        private int _correctBets;
        private double _profit;

        

        public double Balance
        {
            get { return _balance; }
            set { 
                if(_balance == value)
                {
                    return;
                }
                _balance = value;
                OnPropertyChanged("Balance");
            }
        }
        public double NewBalance
        {
            get { return _newBalance; }
            set
            {
                if (_newBalance == value)
                {
                    return;
                }
                _newBalance = value;
                OnPropertyChanged("Balance");
            }
        }

        public int Bets
        {
            get { return _bets; }
            set { 
                if(_bets == value)
                {
                    return;
                }
                _bets = value;
                OnPropertyChanged("Bets");
            }
        }  

        public int CorrectBets
        {
            get { return _correctBets; }
            set { 
                if(_correctBets == value)
                {
                    return;
                }
                _correctBets = value;
                OnPropertyChanged("CorrectBets");
            }
        }
        
        public double Profit
        {
            get { return _profit; }
            set {
                OnPropertyChanged("Profit");
                _profit = _newBalance - _balance;
                OnPropertyChanged("Profit");
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
