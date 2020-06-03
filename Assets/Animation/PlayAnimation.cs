using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animator animator_failed;
    Animator animator_make10;
    Animator animator_good;
    Animator animator_excellent;
    Animator animator_nice;
    public GameObject img_failed;
    public GameObject img_make10;
    public GameObject img_good;
    public GameObject img_excellent;
    public GameObject img_nice;

    // ゲーム初期化処理
    void Start()
    {
        animator_failed = img_failed.GetComponent(typeof(Animator)) as Animator;
        animator_make10 = img_make10.GetComponent(typeof(Animator)) as Animator;
        animator_good = img_good.GetComponent(typeof(Animator)) as Animator;
        animator_excellent = img_excellent.GetComponent(typeof(Animator)) as Animator;
        animator_nice = img_nice.GetComponent(typeof(Animator)) as Animator;
    }

    // Update is called once per frame
    public void PlayFailed()
    {
        animator_failed.Play("Failed", 0, 0.0f);
    }
    public void PlayGood()
    {
        animator_good.Play("Success", 0, 0.0f);
    }
    public void PlayNice()
    {
        animator_nice.Play("Success", 0, 0.0f);
    }
    public void PlayExcellent()
    {
        animator_excellent.Play("Success", 0, 0.0f);
    }
    public void PlayMake10()
    {
        animator_make10.Play("Success", 0, 0.0f);
    }
}
