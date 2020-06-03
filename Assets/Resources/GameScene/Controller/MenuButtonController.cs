using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{


    // ボタンに表示されるテキストと数値
    public string Text { get; private set; }
    public int Number { get; private set; }
    public List<string> str = null;
    public Canvas pause_canvas;

    // ボタンのサイズ
    public int Width = 100;
    public int Heigh = 100;
    //pause用
    public GameObject canvas;
    GameObject ToInvisible;

    void Start()
    {
        // ボタンクリック時の処理を追加
        this.GetComponent<Button>().onClick.AddListener(OnClick);


        // ボタンのサイズを設定
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Heigh);

        canvas = GameObject.Find("Canvas");
        pause_canvas = canvas.GetComponent<Canvas>();

        

    }

    // ボタンの情報を設定する
    public void SetButtonInfos(int number, string text)
    {
        this.Text = text;
        this.Number = number;

        this.GetComponentsInChildren<Text>()[0].text = text;
    }

    // クリック時の処理
    private void OnClick()
    {
        //buttonの名前をnameに格納
        var name = GetComponentInChildren<Text>().text;

        //何かボタンが押されたときにもう一度操作できるようにToinvisbleをtrueにする
        ToInvisible = GameObject.Find("ToInvisibleGameObject");
        MenuButtonGenerator.ToInvisible.SetActive(true);

        //continueが押されたときの不正防止でもう一度make10を行うため
        var make10 = GameObject.Find("Menu_Button");

        //pause_canvas.gameObject.SetActive(false);

        switch (name)
        {
            case "CONTINUE":
                BGCanvasScript.gamestart = true;
                MenuButtonGenerator.timerStop = false;
                MenuButtonGenerator.exist_menubuttons = false;
                //全演算子ボタンを待ち状態にする
                NumberButtonGeneratorForLeft.exist_1buttons = false;
                NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
                NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
                NumberButtonGeneratorForCenterRight.exist_4buttons = false;
                NumberButtonGeneratorForRight.exist_5buttons = false;

                make10.GetComponent<make10>().make_ten();
                break;
            case "RETRY":
                BGCanvasScript.gamestart = false;
                MenuButtonGenerator.timerStop = false;
                MenuButtonGenerator.exist_menubuttons = false;
                //全演算子ボタンを待ち状態にする
                NumberButtonGeneratorForLeft.exist_1buttons = false;
                NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
                NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
                NumberButtonGeneratorForCenterRight.exist_4buttons = false;
                NumberButtonGeneratorForRight.exist_5buttons = false;

                Score.score_num = 0;
                
                SceneManager.LoadScene("GameScene");
                break;
            case "BACK":
                BGCanvasScript.gamestart = true;
                MenuButtonGenerator.timerStop = false;
                MenuButtonGenerator.exist_menubuttons = false;
                //全演算子ボタンを待ち状態にする
                NumberButtonGeneratorForLeft.exist_1buttons = false;
                NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
                NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
                NumberButtonGeneratorForCenterRight.exist_4buttons = false;
                NumberButtonGeneratorForRight.exist_5buttons = false;

                SceneManager.LoadScene("ChooseScene");
                
                break;

        }
        //最後にボタン消去
        var buttons = GameObject.FindGameObjectsWithTag("MenuButton");
        foreach (var item in buttons) Destroy(item);
    }
}