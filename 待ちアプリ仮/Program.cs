using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 待ちアプリ仮
{
    class Program
    {
        public enum Type
        {
            MANZ,
            PINZ,
            SOUZ,
            SANGEN,
            KAZE
        }
        static void Main(string[] args)
        {
            Tehai tehai = new Tehai();

            int[] TEST = { 2, 3, 3,  3, 4, 4,  5, 6, 6,  6, 6, 7,  8 };
            tehai.Trueman();
            tehai.Wait(TEST);

            int a;
            a = 1;
            a += 1;
            a += 1;

        }
    }
}
