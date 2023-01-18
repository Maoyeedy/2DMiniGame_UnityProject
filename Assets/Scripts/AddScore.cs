using UnityEngine;
using TMPro;

public class ScoreAdd : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float timeDelta = 2f;
    public Color32 colorHighlight=new(255, 255, 255, 255);
    public Color32 colorDefault=new(209, 184, 233, 255);
    public float delay = 0.25f;
    public float fadeDuration = 0.25f;
    public Vector3 spawnPoint;
    private int _internalCount;

    private void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Countdown.CountdownTime += timeDelta;
            HighlightTimer();
            
            GameProgress.PlayerScore += 1;
            UpdateText();

            Transform ts = other.transform;
            ts.position = spawnPoint;
            ts.rotation = Quaternion.Euler(0, 0, 0);

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
        else
        {
            print("Player Entered");
        }
    }

    private void UpdateText()
    {
        scoreText.text = $"Score: {GameProgress.PlayerScore.ToString()}";
    }

    private void HighlightTimer()
    {
        StartFade();
        // timerText.color = colorHighlight;
        // Invoke(nameof(StartFade), delay);
    }
    private void StartFade()
    {
        StartCoroutine(FadeText());
    }

    System.Collections.IEnumerator FadeText()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            timerText.color = Color32.Lerp(colorHighlight, colorDefault, t);
            yield return null;
        }
    }
}