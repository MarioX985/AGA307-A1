using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static public int score = 100;
    static public int timeRemaining = 150;
    public GameObject timeBox;
    public GameObject scoretextBox;

    public void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        scoretextBox.GetComponent<Text>().text = "Score: " + score.ToString();
        timeBox.GetComponent<Text>().text = "Time: " + timeRemaining.ToString();
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timeRemaining--;

        StartCoroutine(Timer());
    }
}
