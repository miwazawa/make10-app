using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class four_num_text : MonoBehaviour
{

    public GameObject four_num_object = null; // Textオブジェクト


    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text four_num_tex = four_num_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        four_num_tex.text = ""  +make10.rnd_num[0] +"  "+ make10.rnd_num[1] + "  " + make10.rnd_num[2] + "  " + make10.rnd_num[3];
    }
}