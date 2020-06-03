using System;
using System.Collections.Generic;
using UnityEngine;



public class make10 : MonoBehaviour
{
    public static List<int> rnd_num = new List<int>();
    public  List<string> saved_siki = new List<string>(); //save式の格納
    public  List<int> saved_value = new List<int>();      //save複雑度の格納
    public GameObject Showing_Formula;

    private List<int> ary_num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    int min_value_idx = 0;   //模範解答のインデックス
    double tol = 0.001;
    int[] suuzi = new int[4];
    String[] enzan = { "+", "-", "*", "/" }; //式表示用
    //点数の評価に使用
    public static int siki_value = 0;
    bool ans_flag = false;      //答えがあるかどうか
    public static bool whether_have_answer = false;
    int ans_howmany = 0;


    public int CountOf(string self, params string[] strArray)
    {
        int count = 0;

        foreach (string str in strArray)
        {
            int index = self.IndexOf(str, 0);
            while (index != -1)
            {
                count++;
                index = self.IndexOf(str, index + str.Length);
            }
        }

        return count;
    }

    void make_four_num()
    {
        
        if (rnd_num != null)
        {
            rnd_num.Clear(); ;
        }
        
        //以下for文で重複無しの4つの1～9をrnd_numに代入
        for (int i = 0; i < 4; ++i)
        {
            int num_buf = UnityEngine.Random.Range(0, ary_num.Count );
            rnd_num.Add(ary_num[num_buf]);
            ary_num.RemoveAt(num_buf);
            //Debug.Log("hoge");
        }
    }
    int get_min_value()
    {
        
        int min_value=saved_value[0];
        min_value_idx = 0;
        
        
        for (int i = 1; i < ans_howmany-1 ; ++i) 
        {
            
            if (saved_value[i] < min_value)
            {
                min_value = saved_value[i];
                min_value_idx = i;
            }
        }
        ans_howmany = 0;
        return min_value;
    }
    public void save(string siki,int value)
    {
        
        saved_siki.Add(siki);      
        saved_value.Add(value);      
        ++ans_howmany;
    }
    public void keisan(int a, int b, int c, int d)
    {
        suuzi[0] = a;
        suuzi[1] = b;
        suuzi[2] = c;
        suuzi[3] = d;
    }
    public void eval(string siki) { 
        siki_value += CountOf(siki, "+")*1;
        siki_value += CountOf(siki, "-")*1;
        siki_value += CountOf(siki, "*")*2;
        siki_value += CountOf(siki, "/")*3;
        if (ans_flag == false)
        {
            ans_flag = true;
        }
        save(siki, siki_value);
        //siki_value = 0;

    }
    void syokika()
    {
        ary_num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        if (saved_siki != null)
        {
            saved_siki.Clear();
            saved_value.Clear();
            
        }
        ans_flag = false;

        Showing_Formula.GetComponent<Showing_Formula>().SetFormula();
        
        Showing_Formula.GetComponent<Showing_Formula>().SaveFormula();
        
        
    }
    public double sisoku(int mode, double a, double b)
    { //四則演算の選択用のメソッド
        double c = 0;
        if (mode == 0)
        {
            c = a + b;
        }
        else if (mode == 1)
        {
            c = a - b;
        }
        else if (mode == 2)
        {
            c = a * b;
        }
        else if (mode == 3)
        {
            c = a / b;
        }
        return c;
    }
    public void dousyutu(int i, int j, int k, int l)
    {
        double kai = 0.0;
        String siki = ""; //式表示用
        try
        {
            if (i == 0)
            {
                kai = sisoku(l, sisoku(k, sisoku(j, suuzi[0], suuzi[1]), suuzi[2]), suuzi[3]);
                siki = "(" + "(" + suuzi[0] + enzan[j] + suuzi[1] + ")" + enzan[k] + suuzi[2] + ")" + enzan[l] + suuzi[3];
            }
            else if (i == 1)
            {
                kai = sisoku(k, sisoku(j, suuzi[0], suuzi[1]), sisoku(l, suuzi[2], suuzi[3]));
                siki = "(" + suuzi[0] + enzan[j] + suuzi[1] + ")" + enzan[k] + "(" + suuzi[2] + enzan[l] + suuzi[3] + ")";
            }
            else if (i == 2)
            {
                kai = sisoku(l, sisoku(j, suuzi[0], sisoku(k, suuzi[1], suuzi[2])), suuzi[3]);
                siki = "(" + suuzi[0] + enzan[j] + "(" + suuzi[1] + enzan[k] + suuzi[2] + ")" + ")" + enzan[l] + suuzi[3];
            }
            else if (i == 3)
            {
            }
            else if (i == 4)
            {
                kai = sisoku(j, suuzi[0], sisoku(l, sisoku(k, suuzi[1], suuzi[2]), suuzi[3]));
                siki = suuzi[0] + enzan[j] + "(" + "(" + suuzi[1] + enzan[k] + suuzi[2] + ")" + enzan[l] + suuzi[3] + ")";
            }
            else if (i == 5)
            {
                kai = sisoku(j, suuzi[0], sisoku(k, suuzi[1], sisoku(l, suuzi[2], suuzi[3])));
                siki = suuzi[0] + enzan[j] + "(" + suuzi[1] + enzan[k] + "(" + suuzi[2] + enzan[l] + suuzi[3] + ")" + ")";
            }
        }
        catch (Exception)
        { //０で割るときの例外
            kai = 0;
        }
        if (kai == 10.0 || ((kai < 10.0 + tol) && (kai > 10.0 - tol))) { //or以下は分数による誤差を考慮したもの        
            //Debug.Log("式："+siki);
            eval(siki);
        }

    }


    public void Start()
    {
        Showing_Formula = GameObject.Find("Showing_Formula");
        make_ten();
        //
        //どこでリセットすればいいのかわからなくなったので，GameScene実行時にリセットボタンを押すのと同様の
        //関数を実行することでsavee_strFormulaにrnd_numを代入する
        //
        Showing_Formula.GetComponent<Showing_Formula>().reset_plot();
    }
    public void make_ten()
    {
        
        make_four_num();
        
        //4つの数字が作られる段階で式の評価値をリセットする
        siki_value = 0;
        syokika();
        //　i:計算順序　j,k,l:四則演算選択
        keisan(rnd_num[0], rnd_num[1], rnd_num[2], rnd_num[3]);
        for (int i = 0; i < 6; i++)                 //括弧のループ
        {
            for (int j = 0; j < 4; j++)             //左の演算子のループ
            {
                for (int k = 0; k < 4; k++)         //真ん中の演算子のループ
                {
                    for (int l = 0; l < 4; l++)     //右の演算子のループ
                    {

                        dousyutu(i, j, k, l);

                    }
                }
            }
        }

        if (ans_flag == true)
        {
            //一番評価値の高い式の評価値と式をデバッグログ
            //Debug.Log(get_min_value());
            Debug.Log("模範解答："+saved_siki[min_value_idx]);
            whether_have_answer = true;
        }
        else if (ans_flag == false)
        {
            Debug.Log("解なし");
            whether_have_answer = false;
        }
        //Debug.Log("与数：" + rnd_num[0] + rnd_num[1] + rnd_num[2] + rnd_num[3] + "\n");
        

    }
       
}
