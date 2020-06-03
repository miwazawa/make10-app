using System;
using System.Linq;
using UnityEngine;

public class MenuButtonGenerator : MonoBehaviour
{
    // ボタンのプレファブ
    public GameObject MenuButtonPrefab;
    private GameObject[] buttons;
    public static bool exist_menubuttons = false;
    private GameObject canvas;
    //timerを止めるためのbool
    public static bool timerStop = false;
    //menuが押されたときにToInvisibleGameObjectの子をすべて非アクティブにさせるために定義
    public static GameObject ToInvisible;
    void Start()
    {
        ToInvisible = GameObject.Find("ToInvisibleGameObject");

    }
    public void GenerateMenuButtons()
    {
        //canvas = GameObject.Find("Canvas");
        //var pause_canvas = canvas.GetComponent<CanvasGroup>();
        var buttons = GameObject.FindGameObjectsWithTag("NumberButton");

        if (!exist_menubuttons)
        {

            exist_menubuttons = true;
            //ボタン生成
            this.GenerateMenuButton(3, 1);
            ToInvisible.SetActive(false);
            //演算子ボタンを非アクティブにする
            foreach (var item in buttons) item.SetActive(false);
            timerStop = true;
            
        }
        else
        {
            buttons = GameObject.FindGameObjectsWithTag("MenuButton");
            foreach (var item in buttons) Destroy(item);
            //pause_canvas.gameObject.SetActive(true);
            //pause_canvas.interactable = true;
            timerStop = false;
            exist_menubuttons = false;
            ToInvisible.SetActive(true);
            //演算子ボタンをアクティブにする
            foreach (var item in buttons) item.SetActive(true);
            //全演算子ボタンを待ち状態にする
            NumberButtonGeneratorForLeft.exist_1buttons = false;
            NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
            NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
            NumberButtonGeneratorForCenterRight.exist_4buttons = false;
            NumberButtonGeneratorForRight.exist_5buttons = false;
        }
        //exist_buttons = false;
    }

    public void GenerateMenuButton(int rowCount, int colCount)
    {
        canvas = GameObject.Find("Canvas");
        string[] operators = {"CONTINUE", "RETRY", "BACK" };

        // 一度ボタン等のオブジェクト全削除
        var buttons = GameObject.FindGameObjectsWithTag("MenuButton");
        foreach (var item in buttons) Destroy(item);

        // ボタンの位置調整用
        float offsetCountX = (colCount - 1) / 2.0f;
        float offsetCountY = (rowCount - 1) / 2.0f;

        int index = 0;
        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < colCount; x++)
            {
                // ボタンに設定される番号
                var number = operators[index++];

                // ボタンを生成
                var button = Instantiate(MenuButtonPrefab) as GameObject;

                // ボタンの情報を設定
                var controller = button.GetComponent<MenuButtonController>();
                controller.SetButtonInfos(1, number.ToString());

                // 配置
                button.transform.SetParent(canvas.GetComponent<RectTransform>());
                button.transform.localPosition = new Vector3(0, 600 - 300 * index, 0);

            }
        }
    }
}