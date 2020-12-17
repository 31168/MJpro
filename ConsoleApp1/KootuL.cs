using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class KootuL
    {
        static void Main(string[] args)
        {
            //手牌から昇順で刻子を取り除くプログラム
            //サンプル↓
            int[] Test1 = { 1, 1, 1, 5, 6, 7 };
            int[] Test2 = { 2, 2, 2, 3, 3, 3 };
            int[] Test3 = { 1, 5, 6, 7, 8, 8 };

            int[] TEST = Test2;

            int SerchPoint = 0; //探索する場所
            int Kootu = 0 ; //取り除く刻子

            //刻子を探す
            while (SerchPoint < TEST.Length-2)
            {
                int Serches = TEST[SerchPoint] + TEST[SerchPoint+1] + TEST[SerchPoint+2];

                if(Serches == TEST[SerchPoint] * 3)
                {
                    Kootu = TEST[SerchPoint];
                    break;
                }
                SerchPoint += 1;

            }

            int[] ANS = new int[TEST.Length - 3];

            //見つからなかったらここで戻り値
            if (Kootu == 0)
            {
                TEST.ToList().ForEach(s => Console.WriteLine(s));
                string a = Console.ReadLine();
            }    


            //探した刻子を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;
            for(int i=0; i<TEST.Length; i++)
            {

                if (TEST[i] != Kootu)
                {
                    ANS[num] = TEST[i];
                    num += 1;
                }
                else
                {
                    if (count >= 2)
                    {
                        ANS[num] = TEST[i];
                        num += 1;

                    }
                    else
                        count += 1;

                }
            }

            //刻子が見つかったらここで戻り値
            ANS.ToList().ForEach(s => Console.WriteLine(s));
        }
    }
}
