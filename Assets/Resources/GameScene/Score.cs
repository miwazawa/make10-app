using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject ScoreObject = null;
    public static int score_num = 0;

    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text ScoreText = ScoreObject.GetComponent<Text>();
        ScoreText.text = score_num + "点";
    }
}
