using UnityEngine;
using UnityEngine.SceneManagement;

public class CalcScene : MonoBehaviour
{
    public void goChoose()
    {
        SceneManager.LoadScene("ChooseScene");
    }
}
