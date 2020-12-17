using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MJpro
{
    class ShuntuL
    {
        static void Main(string[] args)
        {
            //順子を昇順で取り除くプログラム
            //サンプル↓
            int[] Test1 = { 1, 2, 2, 5, 6, 7 };
            int[] Test2 = { 1, 2, 2, 3, 5, 7 };
            int[] Test3 = { 1, 3, 4, 7, 8, 8 };
            int[] Test4 = { 1, 3, 3, 5, 5, 8 };

            int[] TEST = Test4;


            
            int[] ANS = new int[3]; //順子を格納
            //手牌から取得した順子を削除する
            var Shuntu = new List<int>(TEST);

            //配列を昇順にして重複排除した配列をListに格納
            var Test = new List<int>();
            foreach (int i in TEST)
            {
                if (!Test.Contains(i))
                {
                    Test.Add(i);
                }
            }
            Test.Sort();

            int SerchPoint = 1; //探索する場所

            //取り除く順子を取得
            while (true)
            {
                int num;
                num = Test[SerchPoint - 1] + Test[SerchPoint] + Test[SerchPoint + 1];

                if (num%3 == 0)
                {
                    ANS[0] = Test[SerchPoint] - 1;
                    ANS[1] = Test[SerchPoint];
                    ANS[2] = Test[SerchPoint] + 1 ;
                    break;
                }

                SerchPoint += 1;
                if (SerchPoint == Test.Count)
                    break;
            }


            
            
            Shuntu.Remove(ANS[0]);
            Shuntu.Remove(ANS[1]);
            Shuntu.Remove(ANS[2]);

            Shuntu.ForEach(s => Console.WriteLine(s));


            


        }
    }
}
