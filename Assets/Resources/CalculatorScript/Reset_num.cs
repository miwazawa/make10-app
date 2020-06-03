using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_num : MonoBehaviour
{
    public GameObject makeanswer_Button;
    MakeAnswer script;

    void Start()
    {
        var makeanswer = GameObject.Find("MakeAnswer_Button");
        script = makeanswer.GetComponent<MakeAnswer>();
    }

    public void Resetnumber()
    {
        script.four_num.Clear();
        script.num_idx = 0;
    }
}
