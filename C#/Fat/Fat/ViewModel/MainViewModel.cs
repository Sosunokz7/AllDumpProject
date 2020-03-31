using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Fat.Model;
namespace Fat.ViewModel
{
    class MainViewModel : Base_VM
    {
        static public EventHandler ClouserWindwo;

        private Dictionary<string,double> AllDouble = new Dictionary<string, double>()
        {
            {"_Vez" ,0},

            {"_Rost",0},
        };
     
        public double Vez { get {   return AllDouble["_Vez"]; } set {AllDouble["_Vez"] = value;OnProperty(); } }

        public double Rost { get {   return AllDouble["_Rost"]; } set {AllDouble["_Rost"] = value;OnProperty();} }

        private string _Answir=null;
        public string Answir { get { return _Answir; } set {_Answir = value;OnProperty(); } }
    

        public ICommand Exit
        {
            get
            {
                return new BaseClick((obj) => { ClouserWindwo?.Invoke(this, EventArgs.Empty); });
             
            }
        }//Закрытие окна

        public ICommand Shet
        {
            get
            {
                return new BaseClick(
                (obj)=> 
                {
                    if (AllDouble["_Rost"].ToString().Length == 3 && AllDouble["_Rost"]!=100)
                    {
                        AllDouble["_Rost"] -= 100;
                    }//Удаление 1го метра если пользователь его ввел
                    double IMT = AllDouble["_Vez"] / Math.Pow((AllDouble["_Rost"] / 100) + 1, 2);
                    double NeedMass = AllDouble["_Rost"]-AllDouble["_Vez"];
                    string BshWord;
                    if (NeedMass < 0)
                    {
                         BshWord = "Вам нужно похудеть на: ";
                    }
                    else
                    {
                         BshWord = "Вам нужно поправиться на: ";
                    }

                    Answir = $"{BshWord}{Math.Abs(NeedMass)}(Кг)\nВаш индекс массы тела равен: {Math.Round(IMT,1)}" +
                    $"\nРасшифровка результата: {AllDumpFunc.Dump.ResultIMT(Math.Round(IMT,2))}";

                },(obj)=> AllDouble["_Vez"] > 0 && AllDouble["_Rost"]>0);
            }

        }

       
       
      

    }
}
