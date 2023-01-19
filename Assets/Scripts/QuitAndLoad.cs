using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndLoad : MonoBehaviour
{
    public KeyCode quit = KeyCode.Escape;
    public KeyCode reload = KeyCode.Return;
    public bool clearScoreOnStart = true;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = $"Your Score is {GameProgress.PlayerScore.ToString()}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(quit))
            Application.Quit();
        if (Input.GetKeyDown(reload) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GameProgress.PlayerScore = 0;
            PlayerPrefs.SetInt("replayed", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}