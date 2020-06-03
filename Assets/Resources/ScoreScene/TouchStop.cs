using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStop : MonoBehaviour
{
    public GameObject result;
    Animator animator;
    void Start()
    {
        ForbidTouching();
    }

    IEnumerator ForbidTouching()
    {
        result.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        result.SetActive(true);
    }
}
