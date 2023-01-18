using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}