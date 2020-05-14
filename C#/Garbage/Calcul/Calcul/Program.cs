using System;
using System.Collections.Generic;
using System.Linq;

namespace Calcul
{
    class Program
    {
        private static List<double> DigitList = new List<double>();

        static void Main(string[] args)
        {
            Console.Write(
                "+:Сложение\n" +
                "-:Вычетание\n" +
                "*:Умножение\n" +
                "/:Деление\n");

            while (true)
            {
                string Premer = Console.ReadLine();
                Schot(Premer); 
            }
        }

        
        static private void Schot(string Premer)
        {
            string Digit="0";//Цыфра на которой остоновился итератор
            sbyte Action = 0;//Действие 0:Ничего(То чему равен case) 1:Умножение 2:Деление
           
            foreach(char i in Premer)
            {
                switch (i)
                {
                    case '+':
                        {
                            if (Action == 0)
                            {
                                DigitList.Add(double.Parse(Digit));//Добовление в колекцию числа       
                            }
                            else if (Action == 1)
                            {
                               
                                DigitList[DigitList.Count - 1] = DigitList.Last() * double.Parse(Digit);//Замена последнего элемента на его произведение
                               
                            }
                            else 
                            {
                                DigitList[DigitList.Count - 1] = DigitList.Last() / double.Parse(Digit);//Замена последнего элемента на его
                            }
                            Action = 0;
                            Digit = "0";
                            break;
                        }
                    case '-':
                        {
                            if (Action == 0)
                            {
                                DigitList.Add(double.Parse(Digit));

                            }
                            else if ((Action == 1) && (Digit!="0" &&Digit!="-0"))
                            {

                                DigitList[DigitList.Count - 1] = DigitList.Last() * double.Parse(Digit);
                            }
                            else if ((Action == 2) && (Digit != "0" && Digit != "-0"))
                            {
                                DigitList[DigitList.Count - 1] = DigitList.Last() / double.Parse(Digit);
                            }

                            Action = 0;
                            Digit = "-0";
                            break;
                        }
                    case '*':
                        {
                            if (Action == 0)
                            {
                                DigitList.Add(double.Parse(Digit));
                            }
                            else if (Action == 1)
                            {
                                DigitList[DigitList.Count - 1] = DigitList.Last() * double.Parse(Digit);
                            }
                            else
                            { 
                                DigitList[DigitList.Count - 1] = DigitList.Last() / double.Parse(Digit);

                            }
                            Action = 1;
                            Digit = "0";
                            break;
                        }
                    case '/':
                        {
                            if (Action == 0)
                            {
                                DigitList.Add(double.Parse(Digit));
                                
                            }
                            else if (Action == 1)
                            { 
                                DigitList[DigitList.Count - 1] = DigitList.Last() * double.Parse(Digit);  
                            }
                            else
                            {
                                DigitList[DigitList.Count - 1] = DigitList.Last() / double.Parse(Digit);                              
                            }
                            Action = 2;
                            Digit = "0";
                            break;
                        }
                        default:
                        {
                            Digit += i;//Само число
                            break;
                        }
                } 
            }
            #region Завершение счета
            if (Action == 0)
            {
                DigitList.Add(int.Parse(Digit));
            }
            else if (Action == 1)
            {                
                DigitList[DigitList.Count - 1] = (DigitList.Last() * double.Parse(Digit)); 
            }
            else
            { 
                DigitList[DigitList.Count - 1] = (DigitList.Last() / double.Parse(Digit));

            }
            Action = 0;
            Digit = "0";
            #endregion
            Console.WriteLine($"Ответ: {DigitList.Sum()}");
            DigitList.Clear();
        }


    }
}
