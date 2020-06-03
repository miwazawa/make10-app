using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Showing_Formula : MonoBehaviour
{

    public GameObject four_num_object = null;               // Textオブジェクト
    public string[] Formula = null;                         //最終的に式に使う計算式
    public string[] converted_Formula = null;                         //最終的に式に使う計算式(calculateに渡すやつ)
    public static List<string> strFormula = new List<string>();    //intからstringに変換するときの入れ子
    public string[]  temp_formula;
    public string str;                      //strFormulaをTextに渡すもの
    public static string converted_str;     //strFormulaをcalcylateに渡すもの
    public string[] saved_formula;          //resetするときに表示させるための式保存の入れ子
    public static List<string> saved_strFormula = new List<string>();    //intからstringに変換するときの入れ子

    //掛け算か割り算か判断するためのbool falseなら掛け算，trueなら割り算
    public static bool kake_or_wari=false;

    public static int RightParenthesisNum = 0;  //右括弧の数
    public static int LeftParenthesisNum = 0;   //左括弧の数
    public int all_num = 0; //演算子の数
    public int shiftnum = 0;//シフトさせる数．Shift_Num関数で使用
    
    

    //計算式を動的表示するテキストの生成オブジェクト
    public GameObject Formula_Text;



    // Start is called before the first frame update
    void Start()
    {
        //Text four_num_tex = four_num_object.GetComponent<Text>();
        StartCoroutine("Set_Formula_Coroutine");


    }

    //左右の括弧の数が等しければtrueを返し，なければfalseを返す関数
    public static bool CheckParenthesisIsRight()
    {
        if (RightParenthesisNum == LeftParenthesisNum) return true;
        else return false; 
    }

    //挿入する位置の調整
    public void Shift_Num(int received_num,string received_ope)
    {
        int numnum = 0;//数字の数

        
        
        //for文で長さほしいから一回tempする
        temp_formula = strFormula.ToArray();

        for(int i = 0; i < temp_formula.Length; ++i)
        {
            //新しい演算子を左側に追加していきたいため，一個右の数字まで進めていき，その数字の一つ左のインデックスにインサートする
            if (numnum == received_num+1) break;
            
            if (temp_formula[i] == "1" || temp_formula[i] == "2" || temp_formula[i] == "3" || temp_formula[i] == "4"
                || temp_formula[i] == "5" || temp_formula[i] == "6" || temp_formula[i] == "7" || temp_formula[i] == "8" || temp_formula[i] == "9")
            {
                numnum++;
                shiftnum++;
            }
            else if (temp_formula[i] == "+" || temp_formula[i] == "-" || temp_formula[i] == "×" || temp_formula[i] == "÷"|| temp_formula[i] == "("|| temp_formula[i] == ")")
            {
                shiftnum++;
            }

        }
        //適切な位置に演算子を挿入
        Showing_Formula.strFormula.Insert(shiftnum-1  , received_ope);
        
        shiftnum = 0;

        //plotに渡すために再変換
        temp_formula = strFormula.ToArray();
        //再変換したものの括弧の数を検査
        CountParenthesis(temp_formula);
        plot();
        

    }
    public void CountParenthesis(string[] temp_formula)
    {
        temp_formula = strFormula.ToArray();
        LeftParenthesisNum = 0;
        RightParenthesisNum = 0;
        for (int i = 0; i < temp_formula.Length; ++i)
        {
            if (temp_formula[i] == "(") LeftParenthesisNum++;
            else if (temp_formula[i] == ")") RightParenthesisNum++;
        }
    }
    IEnumerator Set_Formula_Coroutine()
    {
        //make10の計算終了を待つコルーチン
        yield return new WaitForSeconds(0.2f);

        SetFormula();


    }
    public void DeleteFormula()
    {
        //初期化するだけ
        strFormula = new List<string>();
    }

    //string型に変換させてplot関数に渡すメソッド
    public void SetFormula()
    {
        DeleteFormula();
        //4つの数字をstring型の配列に変換
        for (int i = 0; i < 4; ++i)
        {
            strFormula.Add(make10.rnd_num[i].ToString());

            //Debug.Log(strFormula[i]);

        }

        //foreach (string a in saved_strFormula) Debug.Log(a);
        plot();
    }
    
    public void SaveFormula()
    {
        //resetの時に使うための式保存
        //saved_formula = strFormula.ToArray();
        saved_strFormula = strFormula;
        //foreach (string a in saved_strFormula) Debug.Log(a);
    } 

    //デバッグボタン用
    public void plot()
    {

        //計算式を表示させるテキストオブジェクトに渡す準備
        //strFormulaを配列に変換してstrに1つの文字列としてさらにjoinで変形
        //このstrはcalculateにも渡すためスタティックで定義
        Formula = strFormula.ToArray();
        str = string.Join("", Formula);

        // オブジェクトからTextコンポーネントを取得
        Text formula_text = Formula_Text.GetComponent<Text>();
        // テキストの表示を入れ替える
        formula_text.text = str;

        //calcukateに渡すために変換する
        ConvertToGoodFormula();
        

    }
    public void reset_plot()
    {
        //計算式を表示させるテキストオブジェクトに渡す準備
        //strFormulaを配列に変換してstrに1つの文字列としてさらにjoinで変形
        
        string[] savedFormula = saved_strFormula.ToArray();
        string reset_str = string.Join("", savedFormula);

        //foreach(string a in savedFormula) Debug.Log(a);
        //Debug.Log(reset_str);

        //strFormulaをもとの形に戻す
        //strFormula = saved_strFormula;
        SetFormula();

        // オブジェクトからTextコンポーネントを取得
        Text formula_text = Formula_Text.GetComponent<Text>();
        // テキストの表示を入れ替える
        formula_text.text = reset_str;

    }
    public void CheckParenthesis()
    {
        if (!CheckParenthesisIsRight())
        {
            Debug.Log("括弧の数が違うよ");
            Debug.Log("右の括弧数：" + RightParenthesisNum + "\n左の括弧数：" + LeftParenthesisNum);
        }
        else
        {
            Debug.Log("あっとーよ");
        }
    }

    //演算子を渡すときに*と/に変換させるための関数
    public void ConvertToGoodFormula()
    {
        kake_or_wari = false;
        converted_Formula = strFormula.ToArray();
        for (int i = 0; i < Formula.Length; ++i)
        {
            switch (converted_Formula[i])
            {
                case "×":
                    converted_Formula[i] = "*";
                    break;
                case "÷":
                    converted_Formula[i] = "/";
                    kake_or_wari = true;
                    break;
                default:
                    break;
            }

        }
        
        converted_str = string.Join("", converted_Formula);

    }
}
