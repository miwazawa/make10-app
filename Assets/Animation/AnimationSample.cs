using UnityEngine;
using System.Collections;

public class AnimationSample : MonoBehaviour
{

	Animator animator;

	// ゲーム初期化処理
	void Start()
	{
		animator = GetComponent(typeof(Animator)) as Animator;
		
		
	}

	// frameごとに呼び出される
	public void PlayFailed()
	{
		//var info = animator.GetCurrentAnimatorStateInfo(0);
		animator.Play("Failed", 0, 0.0f);
	}
}