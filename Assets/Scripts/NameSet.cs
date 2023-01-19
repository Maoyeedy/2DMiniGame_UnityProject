using UnityEngine;
using TMPro;

public class NameSet : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private void Awake()
    {
        GameProgress.PlayerName = PlayerPrefs.GetString("PlayerNameInput");
        nameText.text = GameProgress.PlayerName;
    }
}