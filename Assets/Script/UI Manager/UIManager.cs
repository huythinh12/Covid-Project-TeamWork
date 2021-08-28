using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerTxt;
    [SerializeField] GameObject timeOff;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnTimer += HandleTimer;
    }

    void HandleTimer(int time)
    {
        if (time <= 0)
        {
            timeOff.SetActive(true);
            timerTxt.gameObject.SetActive(false);
            Time.timeScale = 0;
            return;
        }
        timerTxt.text = time.ToString();
    }

}
