using UnityEngine;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private void Awake()
    {
        GameProgress.PlayerName = PlayerPrefs.GetString("PlayerNameInput");
        nameText.text = GameProgress.PlayerName;
    }
}