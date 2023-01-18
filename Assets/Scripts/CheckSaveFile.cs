using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CheckSaveFile : MonoBehaviour
{
    private void Awake()
    {
        var filePath = Application.persistentDataPath + "/PlayerData.json";
        if (File.Exists(filePath))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}