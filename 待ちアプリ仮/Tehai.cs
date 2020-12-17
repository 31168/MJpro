using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace 待ちアプリ仮
{
    class Tehai
    {
        public int Numbers { get; set; }  //赤=50 字牌=0
        public string Name { get; set; }
        public Type Type { get; set; }

        //待ちがあるかの判断をブールで処理
        public List<int> Mati { get; set; }

        public Boolean One{ get; set; }
        public Boolean Two { get; set; }
        public Boolean Three { get; set; }
        public Boolean Four { get; set; }
        public Boolean Five { get; set; }
        public Boolean Six { get; set; }
        public Boolean Seven { get; set; }
        public Boolean Eight { get; set; }
        public Boolean Nine { get; set; }

        //↓それぞれのメソッドの試行回数
        public int SyuntuL_num { get; set; }
        public int SyuntuR_num { get; set; }
        public int KotuL_num { get; set; }
        public int KotuR_num { get; set; }
        public int ZyantoL_num { get; set; }
        public int ZyantoR_num { get; set; }



        //---------メインメソッド---------


        public void Wait(int[] Tehai)
        {
            
            
            if(Tehai.Length <= 2)
            {
                
                Tehai = Tenapi(Tehai);
                Anser(Tehai);
                return;
            }

            SyuntuL(Tehai);
            SyuntuR(Tehai);
            KotuL(Tehai);
            KotuR(Tehai);
            ZyantoL(Tehai);
            ZyantoR(Tehai);


        }

        //雀頭を取り出した場合の処理
        public void WaitZ(int[] Tehai)
        {
            if (Tehai.Length <= 2)
            {

                Tehai = Tenapi(Tehai);
                Anser(Tehai);
                return;
                
            }

            SyuntuL(Tehai);
            SyuntuR(Tehai);
            KotuL(Tehai);
            KotuR(Tehai);
        }


        //---------面子を取り出すメソッド集---------

        //＊＊＊＊＊順子を昇順で取り出す＊＊＊＊＊
        public void SyuntuL (int[] Tehai)
        {
            

            var RESULT = new List<int>(Tehai);

            //配列を昇順にして重複排除した配列をListに格納
            var Syuntu = new List<int>();
            foreach (int i in Tehai)
            {
                if (!Syuntu.Contains(i))
                {
                    Syuntu.Add(i);
                }
            }

            //重複を排除したとき手牌の数が２以下なら見つからない
            if (Syuntu.Count <= 2)
                return;

            int SerchPoint = 1; //探索する場所

            //取り除く順子を取得.取得した順子を削除する
            while (true)
            {
                //見つからなかったら処理終了
                if (SerchPoint == Syuntu.Count -1)
                {
                    
                    return;
                }
                    

                int num;
                num = Syuntu[SerchPoint - 1] + Syuntu[SerchPoint] + Syuntu[SerchPoint + 1];

                if (num % 3 == 0)
                {
                    RESULT.Remove(Syuntu[SerchPoint] - 1);
                    RESULT.Remove(Syuntu[SerchPoint]);
                    RESULT.Remove(Syuntu[SerchPoint] + 1);
                    break;
                }

                SerchPoint += 1;
            }

             Tehai = RESULT.ToArray();

            //再帰
            this.SyuntuL_num += 1;
            Wait(Tehai);

        }

        //＊＊＊＊＊順子を降順で取り出す＊＊＊＊＊
        public void SyuntuR (int[] Tehai)
        {

            var RESULT = new List<int>(Tehai);

            //配列を昇順にして重複排除した配列をListに格納
            var Syuntu = new List<int>();
            foreach (int i in Tehai)
            {
                if (!Syuntu.Contains(i))
                {
                    Syuntu.Add(i);
                }
            }

            //重複を排除したとき手牌の数が２以下なら見つからない
            if (Syuntu.Count <= 2)
                return;

            int SerchPoint = Syuntu.Count - 2; //探索する場所

            //取り除く順子を取得.取得した順子を削除する
            while (true)
            {
                //見つからなかったら処理終了
                if (SerchPoint == Syuntu.Count)
                     return;

                int num;
                num = Syuntu[SerchPoint - 1] + Syuntu[SerchPoint] + Syuntu[SerchPoint + 1];

                if (num % 3 == 0)
                {
                    RESULT.Remove(Syuntu[SerchPoint] - 1);
                    RESULT.Remove(Syuntu[SerchPoint]);
                    RESULT.Remove(Syuntu[SerchPoint] + 1);
                    break;
                }

                SerchPoint -= 1;
            }
            
            //順子を取り除いた手牌を配列に格納
            Tehai = RESULT.ToArray();
            //再帰
            this.SyuntuR_num += 1;
            Wait(Tehai);
        }

        //＊＊＊＊＊刻子を昇順で取り出す＊＊＊＊＊
        public void KotuL(int[] Tehai)
        {

            int SerchPoint = 0; //探索する場所
            int Kootu = 0; //取り除く刻子

            //刻子を探す
            while (SerchPoint > 1)
            {
                int Serches = Tehai[SerchPoint] + Tehai[SerchPoint + 1] + Tehai[SerchPoint + 2];

                if (Serches == Tehai[SerchPoint] * 3)
                {
                    Kootu = Tehai[SerchPoint];
                    break;
                }
                SerchPoint += 1;

            }

            int[] ANS = new int[Tehai.Length - 3];

            //見つからなかったらここで戻り値
            if (Kootu == 0)
            {
                return;
            }


            //探した刻子を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;
            for (int i = 0; i < Tehai.Length; i++)
            {
                if (Tehai[i] != Kootu)
                {
                    ANS[num] = Tehai[i];
                    num += 1;
                }
                //刻子を格納し終わった後の処理
                else
                {
                    if (count >= 3)
                    {
                        ANS[num] = Tehai[i];
                        num += 1;
                    }
                    else
                        count += 1;
                }
            }
            //刻子が見つかったらここで戻り値再帰
            this.KotuL_num += 1;
            Wait(Tehai);
        }

        //＊＊＊＊＊刻子を降順で取り出す＊＊＊＊＊
        public void KotuR(int[] Tehai)
        {

            int SerchPoint = Tehai.Length - 1; //探索する場所
            int Kootu = 0; //取り除く刻子

            //刻子を探す
            while (SerchPoint > 1)
            {
                int Serches = Tehai[SerchPoint] + Tehai[SerchPoint - 1] + Tehai[SerchPoint - 2];

                if (Serches == Tehai[SerchPoint] * 3)
                {
                    Kootu = Tehai[SerchPoint];
                    break;
                }
                SerchPoint -= 1;

            }

            int[] ANS = new int[Tehai.Length - 3];

            //見つからなかったらここで戻り値
            if (Kootu == 0)
            {
                return;
            }


            //探した刻子を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;
            for (int i = 0; i < Tehai.Length; i++)
            {
                if (Tehai[i] != Kootu)
                {
                    ANS[num] = Tehai[i];
                    num += 1;
                }
                //刻子を格納し終わった後の処理
                else
                {
                    if (count >= 3)
                    {
                        ANS[num] = Tehai[i];
                        num += 1;

                    }
                    else
                        count += 1;
                }
            }
            //刻子が見つかったらここで戻り値再帰
            KotuR_num += 1;
            Wait(ANS);
        }

        //＊＊＊＊＊雀頭を昇順で取り出す＊＊＊＊＊
        public void ZyantoL(int[] Tehai)
        {
            int SerchPoint = 0; //探索する場所
            int Zyanto = 0; //取り除く雀頭

            while (SerchPoint < Tehai.Length - 1)
            {
                int Serches = Tehai[SerchPoint] + Tehai[SerchPoint + 1];

                if (Serches == Tehai[SerchPoint] * 2)
                {
                    Zyanto = Tehai[SerchPoint];
                    break;
                }
                SerchPoint += 1;

            }

            int[] ANS = new int[Tehai.Length - 2];

            //見つからなかったらここで戻り値
            if (Zyanto == 0)
            {
                return;
            }


            //探した雀頭を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;//取り除いた手牌の数をカウント
            for (int i = 0; i < Tehai.Length; i++)
            {

                if (Tehai[i] != Zyanto)
                {
                    ANS[num] = Tehai[i];
                    num += 1;
                }
                else
                {
                    if (count >= 2)
                    {
                        ANS[num] = Tehai[i];
                        num += 1;

                    }
                    else
                        count += 1;

                }

            }

            //雀頭が見つかったらここで戻り値
            ZyantoL_num += 1;
            WaitZ(ANS);
        }

        //＊＊＊＊＊雀頭を降順で取り出す＊＊＊＊＊
        public void ZyantoR(int[] Tehai)
        {
            int SerchPoint = Tehai.Length - 1; //探索する場所
            int Zyanto = 0; //取り除く雀頭

            //雀頭を探す
            while (SerchPoint > 0)
            {
                int Serches = Tehai[SerchPoint] + Tehai[SerchPoint - 1];

                if (Serches == Tehai[SerchPoint] * 2)
                {
                    Zyanto = Tehai[SerchPoint];
                    break;
                }
                SerchPoint -= 1;

            }

            int[] ANS = new int[Tehai.Length - 2];

            //見つからなかったらここで戻り値
            if (Zyanto == 0)
            {
                return;
            }


            //探した雀頭を取り除いた手牌を新しい配列に格納
            int num = 0;
            int count = 0;//取り除いた手牌の数をカウント
            for (int i = 0; i < Tehai.Length; i++)
            {

                if (Tehai[i] != Zyanto)
                {
                    ANS[num] = Tehai[i];
                    num += 1;
                }
                else
                {
                    if (count >= 2)
                    {
                        ANS[num] = Tehai[i];
                        num += 1;

                    }
                    else
                        count += 1;

                }

            }

            //雀頭が見つかったらここで戻り値
            ZyantoR_num += 1;
            WaitZ(ANS);
        }

        //＊＊＊＊＊聴牌時ノ処理＊＊＊＊＊
        public int[] Tenapi(int[] Tehai)
        {
            int[] result = { 0, 0 };

            if (Tehai.Length == 1)
            {
                //単騎　雀頭の処理
                result[0] = Tehai[0];
            }
            else if (Tehai[1] - Tehai[0] == 0)
            {
                //単騎　刻子待ち
                result[0] = Tehai[0];
            }
            else if (Tehai[1] - Tehai[0] == 1)
            {
                //両面、辺張の処理
                result[0] = Tehai[0] - 1;
                result[1] = Tehai[1] + 1;
            }
            else if (Tehai[1] - Tehai[0] == 2)
            {
                //間張の処理
                result[0] = Tehai[0] + 1;
            }
            else
            {
                //待ちなしの処理
            }

            return result;
        }


        //*****待ち牌のブール型をとぅるーにｓる
        public void Anser(int[] ans)
        {
            for(int i=0; i<2; i++)
            {
                switch (ans[i])
                {
                    case 1:
                        this.One = true;
                        break;
                    case 2:
                        this.Two = true;
                        break;
                    case 3:
                        this.Three = true;
                        break;
                    case 4:
                        this.Four = true;
                        break;
                    case 5:
                        this.Five = true;
                        break;
                    case 6:
                        this.Six = true;
                        break;
                    case 7:
                        this.Seven = true;
                        break;
                    case 8:
                        this.Eight = true;
                        break;
                    case 9:
                        this.Nine = true;
                        break;
                    default:
                        break;
                }
            }
        }



        //---------出力するメソッド---------
        public void Output(int[] TEST)
        {
            TEST.ToList().ForEach(s => Console.Write($"[{s}]"));
            Console.WriteLine();
        }

        //ブーリアンの初期処理
        public void Trueman()
        {
            One = false;
            Two = false;
            Three = false;
            Four = false;
            Five = false;
            Six = false;
            Seven = false;
            Eight = false;
            Nine = false;
            
        }
    }
}
