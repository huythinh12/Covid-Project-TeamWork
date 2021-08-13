using UnityEngine;
using System;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static event Action<int> OnTimer;
    WaitForSeconds waitToTime = new WaitForSeconds(1); 
    [SerializeField] int timer = 60;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        while (timer > 0)
        {
            OnTimer?.Invoke(timer);
            yield return waitToTime;
            timer--;
        }
        OnTimer?.Invoke(timer);


    }
}
