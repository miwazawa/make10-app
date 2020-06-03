using UnityEngine;
using UnityEngine.UI;

public class NumberButtonControllerForRight : MonoBehaviour
{
    // ボタンに表示されるテキストと数値
    public string Text { get; private set; }
    public int Number { get; private set; }

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
        ga = GameObject.Find("Showing_Formula");
    }

    // ボタンの情報を設定する
    public void SetButtonInfosForRight(int number, string text)
    {
        this.Text = text;
        this.Number = number;

        this.GetComponentsInChildren<Text>()[0].text = text;
    }

    // クリック時の処理
    private void OnClick()
    {
        var buttons = GameObject.FindGameObjectsWithTag("NumberButton");
        foreach (var item in buttons) Destroy(item);
        var ope = GetComponentInChildren<Text>().text;
        //Debug.Log(ope + "Clicked ...");


        //一番後ろに「）」挿入
        Showing_Formula.strFormula.Add(ope);
        Showing_Formula.RightParenthesisNum++;
        ga.GetComponent<Showing_Formula>().plot();
    }
}