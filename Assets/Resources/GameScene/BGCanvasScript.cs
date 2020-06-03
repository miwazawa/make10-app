using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGCanvasScript : MonoBehaviour
{
    public GameObject canvas;
    public static bool gamestart = false;

    void Start()
    {
        var bgcanvas = canvas.GetComponent<Canvas>();
        StartCoroutine(WaitCountdownEnd());
        
    }
    
    void Awake()
    {
        
        //DontDestroyOnLoad(this.gameObject);
    }
    

    IEnumerator WaitCountdownEnd()
    {
        canvas.gameObject.SetActive(false);
        //make10の計算終了を待つコルーチン
        yield return new WaitForSeconds(4.0f);
        
        canvas.gameObject.SetActive(true);
        gamestart = true;
        //pauser.Resume();

    }
}
