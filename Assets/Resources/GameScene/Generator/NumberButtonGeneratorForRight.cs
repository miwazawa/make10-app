using UnityEngine;

public class NumberButtonGeneratorForRight : MonoBehaviour
{
    // ボタンのプレファブ
    public GameObject NumberButtonPrefab;
    private GameObject[] buttons;
    //演算子ボタンがあるかどうかのブーリアン，ほかの演算子ボタンgeneratorでもこれを使用する
    public static bool exist_5buttons = false;
    void Start()
    {

    }
    public void GenerateForCenterRight()
    {
        
        if (!exist_5buttons)
        {
            //いったんボタン削除
            buttons = GameObject.FindGameObjectsWithTag("NumberButton");
            foreach (var item in buttons) Destroy(item);
            //ボタン生成
            //こいつは一番左だから「)」だけでいい
            this.GenerateNumberButtonsForRight(1, 1);

            //生成したら他のgenerator達はfalseにする
            NumberButtonGeneratorForLeft.exist_1buttons = false;
            NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
            NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
            NumberButtonGeneratorForCenterRight.exist_4buttons = false;
            NumberButtonGeneratorForRight.exist_5buttons = true;
        }
        else
        {
            buttons = GameObject.FindGameObjectsWithTag("NumberButton");
            foreach (var item in buttons) Destroy(item);

            //destroyしたら他のgenerator達を再度待ち状態にする
            NumberButtonGeneratorForLeft.exist_1buttons = false;
            NumberButtonGeneratorForCenterLeft.exist_2buttons = false;
            NumberButtonGeneratorForCenterCenter.exist_3buttons = false;
            NumberButtonGeneratorForCenterRight.exist_4buttons = false;
            NumberButtonGeneratorForRight.exist_5buttons = false;
        }
    }

    public void GenerateNumberButtonsForRight(int rowCount, int colCount)
    {
        var canvas = GameObject.Find("Canvas");
        /*
        // 番号をシャッフル
        var numbers = Enumerable.Range(1, rowCount * colCount)
            .OrderBy(i => Guid.NewGuid()).ToArray();
        Debug.Log(string.Join(", ", numbers));
        */

        string[] operators = { ")", "-", "×", "÷", ")" };

        // 一度ボタン等のオブジェクト全削除
        var buttons = GameObject.FindGameObjectsWithTag("NumberButton");
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
                var button = Instantiate(NumberButtonPrefab) as GameObject;

                // ボタンの情報を設定
                var controller = button.GetComponent<NumberButtonControllerForRight>();
                controller.SetButtonInfosForRight(1, number.ToString());

                // 画面中央に配置されるようにする
                button.transform.SetParent(canvas.GetComponent<RectTransform>());

                // (0, 0. 0) からボタンサイズ*個数分ずらして配置すると、中央から右上に偏る
                //button.transform.localPosition = new Vector3(
                //    controller.Width * x,
                //    controller.Heigh * y,
                //    0);

                // したがって、表示する行数列数から中央に来るように調整した位置とする
                button.transform.localPosition = new Vector3(
                    controller.Width * x - controller.Width * offsetCountX,
                    controller.Heigh * y - controller.Heigh * offsetCountY,
                    0);
            }
        }
    }
}