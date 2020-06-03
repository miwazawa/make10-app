using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonControllerForCenterCenter : MonoBehaviour
{

    int B_IDX=2;
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
    public void SetButtonInfosForCenterCenter(int number, string text)
    {
        this.Text = text;
        this.Number = number;

        this.GetComponentsInChildren<Text>()[0].text = text;
    }

    // クリック時の処理
    private void OnClick()
    {
        
        var ope = GetComponentInChildren<Text>().text; 
        
        //以下でgaに
        ga.GetComponent<Showing_Formula>().Shift_Num(B_IDX, ope);

        //最後にボタン消去
        var buttons = GameObject.FindGameObjectsWithTag("NumberButton");
        foreach (var item in buttons) Destroy(item);
    }
}