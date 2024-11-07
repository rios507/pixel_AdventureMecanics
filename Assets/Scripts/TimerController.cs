using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public delegate void TimeFinished();
    public TimeFinished OnTimeFinished;

    public delegate void TimeChanger();
    public TimeChanger OnTimeChanger;


    [SerializeField] float timeCounter;
    [SerializeField] int TimeGame;
    [SerializeField] TextMeshProUGUI TimerText;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(showMessage());

    }

    // Update is called once per frame
    void Update()
    {
        TimeGame = (int)timeCounter;
        TimerText.text = TimeGame.ToString();
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;

            if (timeCounter <= 0)
            {
                Debug.Log("finish");
                OnTimeFinished?.Invoke();
            }
        }

        
    }
    IEnumerator showMessage()
    {
        Debug.Log("hola");
        yield return new WaitForSeconds(5);
        Debug.Log("chao");

    }
}
