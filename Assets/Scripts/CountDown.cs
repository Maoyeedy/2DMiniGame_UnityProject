using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText, resultText;
    public GameObject main;
    public GameObject result;
    public float timeLimit = 5f;
    public static float CountdownTime;

    private void Start()
    {
        CountdownTime = timeLimit;
    }

    private void Update()
    {
        if (CountdownTime <= 0f)
        {
            main.SetActive(false);
            result.SetActive(true);
            resultText.text = $"Your score is {GameProgress.PlayerScore}";
        }
        else
        {
            CountdownTime -= Time.deltaTime;
            timerText.text = $"{CountdownTime:F1}s";
        }
    }
}