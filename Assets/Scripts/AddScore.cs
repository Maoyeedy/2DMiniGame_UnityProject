using System.Collections;
using TMPro;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public AudioSource bingo;
    public CanvasGroup canvas;
    [Header("Update Texts")] public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float timeDelta = 2f;
    public Color32 colorHighlight = new(255, 255, 255, 255);
    public Color32 colorDefault = new(209, 184, 233, 255);
    public float delay = 0.25f;
    public float fadeDuration = 0.25f;
    public bool scaleTimer;
    public float fontSizeHighlight = 64f;
    public float fontSizeDefault = 40f;
    [Header("Spawning Targets")] public Vector3 spawnPoint;
    [Range(0f, 2f)] public float minScale = 0.7f;
    [Range(0f, 2f)] public float maxScale = 1.1f;
    public GameObject[] targets;
    public int switchPerScore = 2;
    private float _defaultY;
    private bool _firstOneFinished;
    private int _index;

    private void Start()
    {
        _defaultY = spawnPoint.y;
        UpdateText();

        targets[_index].SetActive(true);
        for (var i = 1; i < targets.Length; i++)
            targets[i].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;
        bingo.Play();

        CountDown.CountdownTime += timeDelta;
        HighlightText();

        GameProgress.PlayerScore += 1;
        UpdateText();

        if (!_firstOneFinished)
        {
            _firstOneFinished = true;
            StartCoroutine(FadeOut());
        }

        if (GameProgress.PlayerScore > 0 && GameProgress.PlayerScore % switchPerScore == 0)
            SwitchTarget();
        else
            ResetTarget(other);
    }
    private void UpdateText()
    {
        scoreText.text = $"Score: {GameProgress.PlayerScore.ToString()}";
    }
    private void HighlightText()
    {
        timerText.color = colorHighlight;
        Invoke(nameof(StartFade), delay);
        if (!scaleTimer) return;
        timerText.fontSize = fontSizeHighlight;
        StartCoroutine(ScaleText());
    }
    private void StartFade()
    {
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            timerText.color = Color32.Lerp(colorHighlight, colorDefault, t);
            if (scaleTimer) timerText.fontSize = Mathf.Lerp(fontSizeHighlight, fontSizeDefault, t);

            yield return null;
        }
    }

    private IEnumerator ScaleText()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / delay;
            timerText.fontSize = Mathf.Lerp(fontSizeDefault, fontSizeHighlight, t);
            yield return null;
        }
    }
    private void SwitchTarget()
    {
        if (_index < targets.Length - 1)
        {
            targets[_index].SetActive(false);
            _index++;
            EnableTarget();
        }
        else if (_index == targets.Length - 1)
        {
            targets[_index].SetActive(false);
            _index = 0;
            EnableTarget();
        }
    }
    private void EnableTarget()
    {
        targets[_index].SetActive(true);
        ResetTarget(targets[_index].GetComponent<Collider2D>());
    }
    private void ResetTarget(Component target)
    {
        if (_index == 1)
            spawnPoint.y = _defaultY + 0.6f;
        else
            spawnPoint.y = _defaultY;

        var ts = target.transform;
        ts.position = spawnPoint;
        ts.rotation = Quaternion.Euler(0, 0, 0);
        var randomScale = Random.Range(minScale, maxScale);
        ts.localScale *= randomScale;

        var rb = target.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }

    private IEnumerator FadeOut()
    {
        var rate = 1.0f / fadeDuration;
        var progress = 0.0f;
        while (progress < 1.0)
        {
            canvas.alpha = Mathf.Lerp(1, 0, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
        canvas.alpha = 0;
    }
}