using UnityEngine;

public class Calculate : MonoBehaviour
{
    public make10 ga;
    //GameObject animator;
    public void Start()
    {
        ga = GetComponent<make10>();
        //animator = GetComponent<PlayAnimation>();
    }

    //割り算が含まれる式の時はresultの方がdouble出ないといけない
    //ここまではわかるが，割り算が含まれない時はresultの型がintでないとcastできないとエラーが出てくる
    //したがって以下のように掛け算の時と割り算の時でresultの型に変化をつけるようにした
    public void WitchCalculate()
    {
        //括弧の数が正しい時にか計算させないことによるエラー回避
        //（演算子不測のエラーなんて知らん）
        if (Showing_Formula.CheckParenthesisIsRight())
        {
            if (Showing_Formula.kake_or_wari)
            {
                Warizan_Calculate_maketen();
            }
            else if (!Showing_Formula.kake_or_wari)
            {
                kakezan_Calculate_maketen();
            }
        }
        
    }
    public void Warizan_Calculate_maketen()
    {
        string exp = Showing_Formula.converted_str;

        System.Data.DataTable dt = new System.Data.DataTable();
        double result = (double)dt.Compute(exp, "");

        //結果を表示
        //Debug.Log("answer:" + result);

        //Debug.Log(Showing_Formula.converted_str);
        CheckAnswer(result,exp);
    }
    public void kakezan_Calculate_maketen()
    {
        string exp = Showing_Formula.converted_str;

        System.Data.DataTable dt = new System.Data.DataTable();
        int result = (int)dt.Compute(exp, "");

        //結果を表示
        //Debug.Log("answer:" + result);

        //Debug.Log(Showing_Formula.converted_str);
        CheckAnswer(result,exp);
    }
    public void CheckAnswer(double result,string exp)
    {
        if((result < 10.0 + 0.001) && (result > 10.0 - 0.001))
        {
            //Debug.Log("Make 10！");
            Score.score_num += CalcScore(exp);
            this.GetComponent<PlayAnimation>().PlayMake10();
            //Debug.Log(ga);
            ga.make_ten();
            
        }else
        {
            Score.score_num-=10;
            //Debug.Log("You made " + result + " lol!");
            this.GetComponent<PlayAnimation>().PlayFailed();
        }
    }
    public void HaveAnAnswer()
    {
        if (make10.whether_have_answer == false)
        {
            Score.score_num+=10;
            //Debug.Log("You are right！");

            //goodかniceかexcellentを乱数で表示させる
            int rnd = Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    this.GetComponent<PlayAnimation>().PlayGood();
                    break;
                case 1:
                    this.GetComponent<PlayAnimation>().PlayNice();
                    break;
                case 2:
                    this.GetComponent<PlayAnimation>().PlayExcellent();
                    break;
            }
            
            ga.make_ten();
        }
        else if(make10.whether_have_answer==true)
        {
            Score.score_num-=10;
            //Debug.Log("You are wrong！lol");
            //Debug.Log(make10.whether_have_answer);
            //Debug.Log(this.GetComponent<PlayAnimation>());
            this.GetComponent<PlayAnimation>().PlayFailed();
            ga.make_ten();
        }
    }
    int CalcScore(string exp)
    {
        int siki_value = 0;
        siki_value += CountOf(exp, "+") * 3;
        siki_value += CountOf(exp, "-") * 3;
        siki_value += CountOf(exp, "*") * 5;
        siki_value += CountOf(exp, "/") * 10;
        return siki_value+5;
    }
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
}
