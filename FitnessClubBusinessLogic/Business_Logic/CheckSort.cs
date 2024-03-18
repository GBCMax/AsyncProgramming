using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Business_Logic
{
    public class CheckSort
    {
        public bool Check(long[] mass)
        {
            for (int i = 0; i < mass.Length - 1; i++)
            {
                if (mass[i] > mass[i + 1])
                    return false;
            }
            return true;
        }
    }
}
