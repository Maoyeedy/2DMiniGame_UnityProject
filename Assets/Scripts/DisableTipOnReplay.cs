using UnityEngine;

public class DisableTipOnReplay : MonoBehaviour
{
    private void Awake()
    {
        if(PlayerPrefs.GetInt("replayed") == 1)
            gameObject.SetActive(false);
    }
}