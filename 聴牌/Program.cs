using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace 聴牌
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2};//辺張待ち　３
            int[] b = { 2, 3 };//両面待ち　１，４
            int[] c = { 2 };//単騎待ち,シャボ待ち　２
            int[] d = { 2, 4 };//間張待ち　３
            int[] e = { 2, 5 };//待ちなし
            int[] f = { 2, 2 }; //単騎待ち　 2

            int[] test = f;

            int[] result = {0,0};

            if(test.Length == 1)
            {
                //単騎　雀頭の処理
                result[0] = test[0];
            }else if (test[1] - test[0] == 0)
            {
                //単騎　刻子待ち
                result[0] = test[0];
            }
            else if(test[1] -test[0] == 1)
            {
                //両面、辺張の処理
                result[0] = test[0] - 1;
                result[1] = test[1] + 1;
            }else if(test[1] - test[0] == 2)
            {
                //間張の処理
                result[0] = test[0] + 1;
            }
            else
            {
                //待ちなしの処理
            }

            result.ToList().ForEach(s => Console.WriteLine(s));

        }
    }
}
