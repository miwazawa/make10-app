using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject Score_Text_Obj;
    void Start()
    {
        Text score_text = Score_Text_Obj.GetComponent<Text>();
        score_text.text = ""+Score.score_num;
    }
    //
    void Update()
    {
        
    }
}
