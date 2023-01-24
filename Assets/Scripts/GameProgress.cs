using System;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int playerScore;
    public string playerName;

    public void ClearData()
    {
        playerScore = 0;
        playerName = "Player";
    }
}

public class GameProgress : MonoBehaviour
{
    public static string PlayerName;
    public static int PlayerScore;

    private void Awake()
    {
        LoadGame();
    }

    private void OnDestroy()
    {
        SaveGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public static void LoadGame()
    {
        var filePath = $"{Application.persistentDataPath}/PlayerData.json";
        if (!File.Exists(filePath)) return;
        var jsonData = File.ReadAllText(filePath);
        var data = JsonUtility.FromJson<PlayerData>(jsonData);
        PlayerScore = data.playerScore;
        PlayerName = data.playerName;
    }

    public static void SaveGame()
    {
        var data = new PlayerData { playerName = PlayerName, playerScore = PlayerScore };
        var jsonData = JsonUtility.ToJson(data);
        var filePath = $"{Application.persistentDataPath}/PlayerData.json";
        File.WriteAllText(filePath, jsonData);
    }
}