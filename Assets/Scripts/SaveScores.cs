using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

public class SaveScores : MonoBehaviour
{
    public Scores MudBathScores;
    public Scores RunAndCatchScores;
    public Scores AnimalBoxingScores;

    private void Awake()
    {
        LoadFromJson();
    }

    public void SaveToJson()
    {
        string filePath = Application.persistentDataPath + "/MudBathScores.json";
        string scoreData = JsonUtility.ToJson(MudBathScores);
        File.WriteAllText(filePath, Convert.ToBase64String(Encoding.UTF8.GetBytes(scoreData)));
        filePath = Application.persistentDataPath + "/RunAndCatchScores.json";
        scoreData = JsonUtility.ToJson(RunAndCatchScores);
        File.WriteAllText(filePath, Convert.ToBase64String(Encoding.UTF8.GetBytes(scoreData)));
        filePath = Application.persistentDataPath + "/AnimalBoxingScores.json";
        scoreData = JsonUtility.ToJson(AnimalBoxingScores);
        File.WriteAllText(filePath, Convert.ToBase64String(Encoding.UTF8.GetBytes(scoreData)));
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/MudBathScores.json";

        if (!File.Exists(filePath))
            SaveToJson();


        MudBathScores = JsonUtility.FromJson<Scores>(Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(filePath))));

        filePath = Application.persistentDataPath + "/RunAndCatchScores.json";

        RunAndCatchScores = JsonUtility.FromJson<Scores>(Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(filePath))));

        filePath = Application.persistentDataPath + "/AnimalBoxingScores.json";

        AnimalBoxingScores = JsonUtility.FromJson<Scores>(Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(filePath))));
    }
}

[System.Serializable]
public class Scores
{
    public List<string> name;
    public List<float> score;
}
