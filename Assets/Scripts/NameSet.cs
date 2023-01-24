using TMPro;
using UnityEngine;

public class NameSet : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private void Awake()
    {
        GameProgress.PlayerName = PlayerPrefs.GetString("PlayerNameInput");
        nameText.text = GameProgress.PlayerName;
    }
}