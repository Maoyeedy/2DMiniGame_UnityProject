using UnityEngine;
using TMPro;

public class ScoreAdd : MonoBehaviour
{
    public GameObject directionTip;
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
    private int _index;
    private float _defaultY;
    private AudioSource _audio;
    private bool _firstOneFinished;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _defaultY = spawnPoint.y;
        UpdateText();
        targets[_index].SetActive(true);
        for (var i = 1; i < targets.Length; i++)
            targets[i].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Countdown.CountdownTime += timeDelta;
            HighlightText();

            GameProgress.PlayerScore += 1;
            UpdateText();
            
            _audio.Play();

            if (!_firstOneFinished)
            {
                _firstOneFinished = true;
                directionTip.SetActive(false);
            }

            if (GameProgress.PlayerScore > 0 && GameProgress.PlayerScore % switchPerScore == 0)
                SwitchTarget();
            else
                ResetTarget(other);
        }
    }

    private void UpdateText()
    {
        scoreText.text = $"Score: {GameProgress.PlayerScore.ToString()}";
    }

    private void HighlightText()
    {
        timerText.color = colorHighlight;
        Invoke(nameof(StartFade), delay);
        if (scaleTimer)
        {
            timerText.fontSize = fontSizeHighlight;
            StartCoroutine(ScaleText());
        }
    }

    private void StartFade()
    {
        StartCoroutine(FadeText());
    }

    private System.Collections.IEnumerator FadeText()
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

    private System.Collections.IEnumerator ScaleText()
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

    private void ResetTarget(Collider2D target)
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
}