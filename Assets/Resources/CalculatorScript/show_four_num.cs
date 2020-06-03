using UnityEngine;
using UnityEngine.UI;

public class show_four_num : MonoBehaviour
{

    public GameObject four_num_object; // Textオブジェクト
    public GameObject makeanswer_Button;
    MakeAnswer script;

    // 初期化
    void Start()
    {
        var makeanswer = GameObject.Find("MakeAnswer_Button");
        script= makeanswer.GetComponent<MakeAnswer>();
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text four_num_tex = four_num_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        if (script.four_num.Count == 0)
        {
            four_num_tex.text = "";
        }
        else if (script.four_num.Count == 1)
        {
            four_num_tex.text = "" + script.four_num[0];
        }
        else if (script.four_num.Count == 2)
        {
            four_num_tex.text = "" + script.four_num[0] + script.four_num[1];
        }
        else if (script.four_num.Count == 3)
        {
            four_num_tex.text = "" + script.four_num[0] + script.four_num[1] + script.four_num[2];
        }
        else if (script.four_num.Count == 4)
        {
            four_num_tex.text = "" + script.four_num[0] + script.four_num[1] + script.four_num[2] + script.four_num[3];
        }
        
    }
}