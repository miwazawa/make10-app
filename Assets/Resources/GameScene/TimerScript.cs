
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

	//　トータル制限時間
	private float totalTime;
	//　制限時間（分）
	[SerializeField]
	private int minute;
	//　制限時間（秒）
	[SerializeField]
	private float seconds;
	//　前回Update時の秒数
	private float oldSeconds;
	private Text timerText;
	


	void Start()
	{
		totalTime = minute * 60 + seconds;
		oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
		
	}


	void Update()
	{
		
		if (BGCanvasScript.gamestart && !MenuButtonGenerator.timerStop)
		{
			//　制限時間が0秒以下なら何もしない
			if (totalTime <= 0f)
			{
				return;
			}
			//　一旦トータルの制限時間を計測；
			totalTime = minute * 60 + seconds;
			totalTime -= Time.deltaTime;

			//　再設定
			minute = (int)totalTime / 60;
			seconds = totalTime - minute * 60;

			//　タイマー表示用UIテキストに時間を表示する
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = "残り" + ((int)seconds).ToString("00") + "秒";
			}
			oldSeconds = seconds;
			//　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
			if (totalTime <= 0f)
			{
				Debug.Log("制限時間終了");
				SceneManager.LoadScene("ScoreScene");
			}
		}

		
	}
}
