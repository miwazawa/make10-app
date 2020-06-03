using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAlpha : MonoBehaviour
{
    public GameObject panel;
    private Image image;
    void Start()
    {
        image = panel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BGCanvasScript.gamestart && MenuButtonGenerator.timerStop)
        {
            image.color = GetAlphaColor(image.color);

        }
        else if (BGCanvasScript.gamestart && !MenuButtonGenerator.timerStop)
        {
            image.color = GetAlphaColor2(image.color);
        }
    }
    Color GetAlphaColor(Color color)
    {
        color.a = 0.7f;

        return color;
    }
    Color GetAlphaColor2(Color color)
    {
        color.a = 0.0f;

        return color;
    }
}
