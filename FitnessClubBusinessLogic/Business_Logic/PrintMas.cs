using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Business_Logic
{
    public class PrintMas
    {
        public string ShowMas(long[] mas)
        {
            string S = "";
            for(int i = 0; i < mas.Length; i++)
            {
                S += mas[i].ToString() + " ";
            }
            return S;
        }
    }
}
