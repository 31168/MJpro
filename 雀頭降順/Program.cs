using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 雀頭降順
{
    class Program
    {
        static void Main(string[] args)
        {
            //手牌から昇順で雀頭を取り除くプログラム
            //サンプル↓
            int[] Test1 = { 1, 1, 1, 5, 6, 6 };
            int[] Test2 = { 1, 2, 2, 3, 3, 3 };
            int[] Test3 = { 1, 5, 6, 7, 8 };

            int[] TEST = Test3;

            int SerchPoint = TEST.Length-1; //探索する場所
            int Zyanto = 0; //取り除く雀頭

            //雀頭を探す
            while (SerchPoint > 0)
            {
                int Serches = TEST[SerchPoint] + TEST[SerchPoint - 1];

                if (Serches == TEST[SerchPoint] * 2)
                {
                    Zyanto = TEST[SerchPoint];
                    break;
                }
                SerchPoint -= 1;

            }

            int[] ANS = new int[TEST.Length - 2];

            //見つからなかったらここで戻り値
            if (Zyanto == 0)
            {
                TEST.ToList().ForEach(s => Console.WriteLine(s));
                Console.WriteLine("戻り値なし");
                string a = Console.ReadLine();
            }


            //探した雀頭を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;//取り除いた手牌の数をカウント
            for (int i = 0; i < TEST.Length; i++)
            {

                if (TEST[i] != Zyanto)
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

            //雀頭が見つかったらここで戻り値
            ANS.ToList().ForEach(s => Console.WriteLine(s));
        }
    }
}
