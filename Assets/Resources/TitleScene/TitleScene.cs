using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene("ChooseScene");
		}
	}
}