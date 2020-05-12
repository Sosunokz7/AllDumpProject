using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows;
using ProjcForAukt.SQLQes.PeremiiForSQL;
namespace ProjcForAukt.SQLQes
{
    class AllSQLQuest : Window
    {

        private static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Database1.accdb";//Место где БД

        private OleDbConnection Connect = new OleDbConnection(connectString);//Строка подключения 
        private int NumLota;

        public string[,] ThisLot = new String[7, 1000];


        public int ForTestLoginAndPassword(string Login, string Passw)
        {
            try
            {
                Connect.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Покупатели WHERE (Логин='" + Login + "' AND " + "Пароль='"  + Passw + "');", Connect);//Запрос на авторизацию
                OleDbDataReader reader = cmd.ExecuteReader();//Получене данных



                OleDbCommand CmdForVid = new OleDbCommand("SELECT * FROM Ведущие WHERE (Логин='" + Login + "' AND Пароль='"  + Passw + "');", Connect);

                OleDbDataReader readers = CmdForVid.ExecuteReader();
               



                if (reader.Read() == true)//Проверка данных
                {
                 
                    reader.GetValues(PeremiiForSQL.PeremenSQL.InfMens);//Передача данных в массив
                    return 1;
                }
                else if (readers.Read() == true)
                {

                    readers.GetValues(PeremiiForSQL.PeremenSQL.Lotkers);
                    return 2;
                }
                else
                {
                    return 0;
                }

                Connect.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }//Для авторизации


       
        public void ForTestRegistr(string[] ArrayForRegistr)
        {
            try
            {
                Connect.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Покупатели WHERE ([Номер паспорта]='" + ArrayForRegistr[0] + "' OR [Номер карты]='" + ArrayForRegistr[4] + "'OR" + "[Логин]='" + ArrayForRegistr[5] + "'" + ")", Connect);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == false)
                {
                    //Convert.ToInt32(ArrayForRegistr[0]);
                    //Convert.ToInt32(ArrayForRegistr[4]);

                    OleDbCommand Cmds = new OleDbCommand("INSERT INTO Покупатели ([Номер паспорта],[Фамилия],[Имя],[Адрес проживания],[Номер карты],[Логин],[Пароль])  VALUES ('" + ArrayForRegistr[0] + "','" + ArrayForRegistr[1] + "','" + ArrayForRegistr[2] + "','" + ArrayForRegistr[3] + "','" + ArrayForRegistr[4] + "','" + ArrayForRegistr[5] + "','" + ArrayForRegistr[6] + "');", Connect);

                    Cmds.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрированны ");
                    
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже зарегистрирован");
                }


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            Connect.Close();
        }



        public void ForSellLot()
        {
            try
            {

                Connect.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Лоты", Connect);
                OleDbDataReader reader = cmd.ExecuteReader();
                int LenStr = -1;

                while (reader.Read())
                {

                    LenStr++;


                    for (int i = 0; i != 7; i++)
                    {

                        SQLQes.PeremiiForSQL.PeremenSQL.ForLots[i, LenStr] = reader.GetValue(i).ToString();

                    }

                }
                PeremiiForSQL.PeremenSQL.LenLots = LenStr;

            }
            catch (Exception e)
            {
                MessageBox.Show("Сейчас нет лотов на продажу");
                //MessageBox.Show(e.Message);



            }
            Connect.Close();
        }


        public long TraidValueMany(long Mani, int NumberLot)
        {
            try
            {
                NumberLot++;
                Connect.Open();

                OleDbCommand cmd = new OleDbCommand("UPDATE Лоты SET [Начальная ставка]=" + Mani + ",[Номер покупателя с максимальной ставкой]='" + PeremiiForSQL.PeremenSQL.InfMens[0] + "',[Адресс доставки]='" + PeremiiForSQL.PeremenSQL.InfMens[3] + "' WHERE [Номер лота]=" + NumberLot + ";", Connect);

                cmd.ExecuteNonQuery();

                OleDbCommand CMDS = new OleDbCommand("SELECT [Начальная ставка] FROM Лоты WHERE [Номер лота]=" + NumberLot + ";", Connect);


                OleDbDataReader reader = CMDS.ExecuteReader();
                reader.Read();

                long xz = Convert.ToInt64(reader.GetValue(0));
                Connect.Close();
                return xz;
                
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
                Connect.Close();
                return 0;
               
            }
          

             

          


        }


        public void MyLots()
        {
            Connect.Open();
            Console.WriteLine(PeremiiForSQL.PeremenSQL.InfMens[0]);
            OleDbCommand cmd = new OleDbCommand("SELECT [Номер лота],[Название],[Цена проддажи],[Адрес доставки],[Фото] FROM [Проданные лоты] WHERE ([Номер паспорта покупателя]='"+PeremiiForSQL.PeremenSQL.InfMens[0]+"');", Connect);
            OleDbDataReader reader = cmd.ExecuteReader();
           
            int LenArr = -1;
            while (reader.Read())
            {
                LenArr++;

                for (int i = 0; i != 5; i++)
                {
                    PeremiiForSQL.PeremenSQL.MyLotsForMe[i, LenArr] = reader.GetValue(i).ToString();
                }

            }

            PeremiiForSQL.PeremenSQL.LenMyLots = LenArr;
            Connect.Close();
        }


        public void SELLSLOT()
        {
            try
            {
                Connect.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Лоты", Connect);

                OleDbDataReader reader = cmd.ExecuteReader();

                OleDbCommand cmds = new OleDbCommand("SELECT MAX([Номер лота]) FROM [Проданные лоты]", Connect);
                 
                OleDbDataReader read= cmds.ExecuteReader();
                read.Read();
                int NumLotrs = Convert.ToInt32(read.GetValue(0)) + 1;

                while (reader.Read())
                {
                    OleDbCommand AddLot = new OleDbCommand("INSERT INTO [Проданные лоты] ([Номер лота],[Номер паспорта покупателя],[Название],[Цена проддажи],[Адрес доставки],[Фото])  VALUES('" + NumLotrs + "','" + reader.GetValue(4) + "','" + reader.GetValue(1) + "','" + reader.GetValue(5) + "','" + reader.GetValue(7) + "','" + reader.GetValue(6) + "');", Connect);
                    AddLot.ExecuteNonQuery();

                }

              
            }
            catch(Exception f)
            {

                MessageBox.Show("Все лоты были проданны");

                OleDbCommand DeleteItems = new OleDbCommand("DELETE * FROM Лоты;", Connect);
                DeleteItems.ExecuteNonQuery();
                MessageBox.Show(f.Message);

            }
            Connect.Close();
        }

        public void AddLot(string LotName,string OpisLot,long StartPrais,string NameImagesLot)
        {
            try
            {
                Connect.Open();
                try
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT MAX([Номер лота]) FROM Лоты;", Connect);
                    OleDbDataReader readeMaxNumLot = cmd.ExecuteReader();

                    readeMaxNumLot.Read();

                    NumLota = Convert.ToInt32(readeMaxNumLot.GetValue(0)) + 1;
                  
                }
                catch
                {
                    NumLota = 1;
                }

                OleDbCommand cmdAdd = new OleDbCommand("INSERT INTO [Лоты] ([Номер лота],[Название предмета],[Описание предмета],[Номер поспорта  продовца],[Номер покупателя с максимальной ставкой],[Начальная ставка],[Фотография лота],[Адресс доставки]) VALUES (" + NumLota.ToString() + ",'" + LotName + "','" + OpisLot + "','" + PeremenSQL.InfMens[0] + "','0'," + StartPrais.ToString() + ",'" + NameImagesLot + "','0');", Connect);
                cmdAdd.ExecuteNonQuery();
                MessageBox.Show("Лот зарегистрирован");

            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
            
            Connect.Close();
          
        }

    }
}


    



      
           
