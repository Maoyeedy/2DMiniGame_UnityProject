using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputFieldController : MonoBehaviour
{
    public TMP_InputField inputField;
    // private bool _isMobile;
    //
    // private void Start()
    // {
    //     _isMobile = Application.platform is RuntimePlatform.Android or RuntimePlatform.IPhonePlayer;
    // }

    private void Update()
    {
        if (inputField.text != "Enter Player Name")
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Return))
            {
                PlayerPrefs.SetString("PlayerNameInput", inputField.text);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
    }
}