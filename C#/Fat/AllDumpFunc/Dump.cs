using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllDumpFunc
{
    public class Dump
    {
        public static string ResultIMT(double IMT)
        {
            if (IMT <= 16)
            {
                return "Выраженный дефицит массы тела ";
            }
            else if ((16 < IMT) && (IMT <= 19.5f))
            {
                return "Малый недостаток массы тела";
            }
            else if ((19.5f< IMT) && (IMT <= 24.99))
            {
                return "Норма";
            }
            else if ((25 <= IMT) && (IMT <= 30))
            {
                return "Избыточная масса тела(предожирение)";
            }
            else if ((30 < IMT) && (IMT <= 35))
            {
                return "Ожирение первой степени";
            }
            else if ((35 < IMT) && (IMT <= 40))
            {
                return "Ожирение второй степени";
            }
            else 
            {
                return "Ожирение третей степени";
            }
        }

    }
}
