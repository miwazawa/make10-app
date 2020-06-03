using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonControllerForCenterRight : MonoBehaviour
{

    int B_IDX = 3;
    // ボタンに表示されるテキストと数値
    public string Text { get; private set; }
    public int Number { get; private set; }
    public List<string> str = null;

    // ボタンのサイズ
    public int Width = 100;
    public int Heigh = 100;
    public GameObject ga;

    void Start()
    {
        // ボタンクリック時の処理を追加
        this.GetComponent<Button>().onClick.AddListener(OnClick);


        // ボタンのサイズを設定
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Heigh);

        // テスト用のボタン情報を設定
        //SetButtonInfos(1, "");
        //GetComponentInParent<NumberButtonGeneratorForCenterCenter>().GetComponent<Showing_Formula>();

        ga = GameObject.Find("Showing_Formula");
    }

    // ボタンの情報を設定する
    public void SetButtonInfosForCenterRight(int number, string text)
    {
        this.Text = text;
        this.Number = number;

        this.GetComponentsInChildren<Text>()[0].text = text;
    }

    // クリック時の処理
    private void OnClick()
    {

        var ope = GetComponentInChildren<Text>().text;
        //Debug.Log(ope + "Clicked ...");

        //ope(演算子)を適切な位置に挿入．左から4番目なので3番目

        //以下でgaに
        //ga.GetComponent<Showing_Formula>().shiftnum = 191;
        ga.GetComponent<Showing_Formula>().Shift_Num(B_IDX, ope);
        //var sine = GetComponent<Showing_Formula>().shiftnum;//.Shift_Num(B_IDX,ope);
        //Debug.Log(ga.GetComponent<Showing_Formula>().shiftnum);

        //var method = GameObject.Find("Showing_Formula");

        //Showing_Formula.strFormula.Insert(Showing_Formula.shiftnum + B_IDX, ope);

        //最後にボタン消去
        var buttons = GameObject.FindGameObjectsWithTag("NumberButton");
        foreach (var item in buttons) Destroy(item);
    }
}