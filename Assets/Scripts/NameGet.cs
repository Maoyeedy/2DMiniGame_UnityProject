using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetString("PlayerNameInput", inputField.text);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}