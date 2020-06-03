using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void playgame()
    {
        BGCanvasScript.gamestart = false;
        Score.score_num = 0;
        SceneManager.LoadScene("GameScene");
        
    }
}
