using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndLoad : MonoBehaviour
{
    public KeyCode quit = KeyCode.Escape;
    public KeyCode reload = KeyCode.Return;
    public bool clearScoreOnStart = true;

    private void Awake()
    {
        if (clearScoreOnStart)
            GameProgress.PlayerScore = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(quit))
            Application.Quit();
        if (Input.GetKeyDown(reload))
        {
            GameProgress.PlayerScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}