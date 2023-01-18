using UnityEngine;

public class AndroidFrameRate : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
}