using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    private Text countdownText;

    private float timeLeft;

    void Awake()
    {
        countdownText = GetComponent<Text>();
    }

    void StartCountdown()
    {
        timeLeft = 3;
        StartCoroutine(CountdownUpdate());
    }

	IEnumerator CountdownUpdate()
    {
        Animator anim = GetComponent<Animator>();

        if (anim){
            anim.SetTrigger("Begin");
        }

        while(timeLeft > 0)
        {
            countdownText.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForFixedUpdate();
            timeLeft -= Time.deltaTime;
        }

        GameEventSystem.OnBeginPlay();
        countdownText.text = "Go!";
    }

    void OnEnable()
    {
        GameEventSystem.LevelReset += StartCountdown;
    }

    void OnDisable()
    {
        GameEventSystem.LevelReset -= StartCountdown;
    }
}
