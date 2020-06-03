using UnityEngine;
using UnityEngine.SceneManagement;

public class Calc : MonoBehaviour
{
    public void calc()
    {
        SceneManager.LoadScene("CalculatorScene");
    }
}
