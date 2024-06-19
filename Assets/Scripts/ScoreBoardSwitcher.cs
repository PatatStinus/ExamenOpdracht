using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoardSwitcher : MonoBehaviour
{
    public enum ScoreGameModes { MudBath, RunAndCatch, AnimalBoxing }
    public ScoreGameModes ScoreType = ScoreGameModes.MudBath;
    public SaveScores Data;
    public Text Names;
    public Text Scores;
    public Text GameName;

    private void Update()
    {
        //Change scoreboard on arrow press.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ScoreType == ScoreGameModes.MudBath)
            {
                ScoreType = ScoreGameModes.AnimalBoxing;
                GameName.text = "Animal Boxing";
            }
            else if (ScoreType == ScoreGameModes.RunAndCatch)
            {
                ScoreType = ScoreGameModes.MudBath;
                GameName.text = "Mud Bath";
            }
            else if (ScoreType == ScoreGameModes.AnimalBoxing)
            {
                ScoreType = ScoreGameModes.RunAndCatch;
                GameName.text = "Run And Catch";
            }
            SetScore();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ScoreType == ScoreGameModes.MudBath)
            {
                ScoreType = ScoreGameModes.RunAndCatch;
                GameName.text = "Run And Catch";
            }
            else if (ScoreType == ScoreGameModes.RunAndCatch)
            {
                ScoreType = ScoreGameModes.AnimalBoxing;
                GameName.text = "Animal Boxing";
            }
            else if (ScoreType == ScoreGameModes.AnimalBoxing)
            {
                ScoreType = ScoreGameModes.MudBath;
                GameName.text = "Mud Bath";
            }
            SetScore();
        }
    }

    private void Start()
    {
        SetScore();
    }

    private void SetScore()
    {
        GetScore(ScoreType, out List<float> scores, out List<string> names);
        Names.text = "";
        Scores.text = "";
        for (int i = 0; i < scores.Count; i++)
        {
            if (i >= 10) break;
            Names.text += names[i];
            Names.text += "\n";
            Scores.text += scores[i];
            Scores.text += "\n";
        }
    }

    public void GetScore(ScoreGameModes mode, out List<float> scores, out List<string> names)
    {
        scores = new();
        names = new();
        switch (mode)
        {
            case ScoreGameModes.MudBath:
                names = Data.MudBathScores.name;
                scores = Data.MudBathScores.score;
                break;
            case ScoreGameModes.RunAndCatch:
                names = Data.RunAndCatchScores.name;
                scores = Data.RunAndCatchScores.score;
                break;
            case ScoreGameModes.AnimalBoxing:
                names = Data.AnimalBoxingScores.name;
                scores = Data.AnimalBoxingScores.score;
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Array.Clear(TotalScores.Scores, 0, TotalScores.Scores.Length);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

