using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSaveFile : MonoBehaviour
{
    private void Awake()
    {
        var filePath = $"{Application.persistentDataPath}/PlayerData.json";
        if (File.Exists(filePath))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
