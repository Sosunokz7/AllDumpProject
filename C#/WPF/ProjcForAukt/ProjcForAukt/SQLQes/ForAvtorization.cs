using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows;
namespace ProjcForAukt.SQLQes
{
    class ForAvtorization:Window
    {

        private static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Database1.accdb";//Место где БД

        //private string[] InfoMen= new string[7];

        public OleDbConnection Connect = new OleDbConnection(connectString);//Строка подключения 

        public string[] ForTestLoginAndPassword(string Login,string Passw)
        {
            try
            {
                Connect.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Покупатели WHERE (Логин=" + "'" + Login + "' AND " + "Пароль=" + "'" + Passw + "');", Connect);//Запрос на авторизацию
                OleDbDataReader reader = cmd.ExecuteReader();//Получене данных

                if (reader.Read() == false)//Проверка данных
                {
                    MessageBox.Show("Такой пользователь не найден");
                    return null;
                }
                else
                {
                    reader.GetValues(PeremiiForSQL.PeremenSQL.InfMens);//Передача данных в массив
                    return PeremiiForSQL.PeremenSQL.InfMens;
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
           

        }


    }
}
