using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameParent : MonoBehaviour
{
    protected float _timer = 123;
    public int[] Score { get; set; }
    public List<PlayerMovement> Players;
    protected bool _gameEnded = false;

    [SerializeField] protected Text _timerText;
    [SerializeField] protected List<Text> _scorePlayersText;

    public SaveScores SaveData;

    private void Awake()
    {
        Score = new int[4];
    }

    protected virtual void Update()
    {
        if (_gameEnded) return;

        _timer -= Time.deltaTime;
        
        if(_timer < 0)
            EndGame();

        _timerText.text = _timer.ToString("0.00");
        for(int i = 0; i < Score.Length; i++)
            _scorePlayersText[i].text = Score[i].ToString();
    }


    protected virtual void EndGame()
    {
        if (_gameEnded)
            return;
        
        _gameEnded = true;

        //Add scores to total
        StartCoroutine(AddScores());

        
        //Check welke minigame er nu gespeeld wordt.
        if(this as MudBathManager)
        {
            for(int j = 0; j < Players.Count; j++)
            {
                int index = 0;
                for(int i = 0;  i < SaveData.MudBathScores.score.Count; i++)
                {
                    if (Score[j] > SaveData.MudBathScores.score[i])
                    {
                        index = i;
                        break;
                    }
                    if (i == 9)
                        index = 10;
                    if (i == SaveData.MudBathScores.score.Count - 1)
                        index = i + 1;
                }


                if (index >= 10) return;

                SaveData.MudBathScores.score.Insert(index, Score[j]);
                SaveData.MudBathScores.name.Insert(index, "PlaceHolder");
                SaveData.SaveToJson();
            }
        }
        else if (this as AnimalBoxingManager)
        {
            for (int j = 0; j < Players.Count; j++)
            {
                int index = 0;
                for (int i = 0; i < SaveData.AnimalBoxingScores.score.Count; i++)
                {
                    if (Score[j] > SaveData.AnimalBoxingScores.score[i])
                    {
                        index = i;
                        break;
                    }
                    if (i == 9)
                        index = 10;
                    if (i == SaveData.AnimalBoxingScores.score.Count - 1)
                        index = i + 1;
                }


                if (index >= 10) return;

                SaveData.AnimalBoxingScores.score.Insert(index, Score[j]);
                SaveData.AnimalBoxingScores.name.Insert(index, "PlaceHolder");
                SaveData.SaveToJson();
            }
        }
        /*else if ()
        {

        }*/


        
        //TODO: Geef game review en stuur iedereen terug naar kaart pak scene, tenzij alle kaarten al gepakt zijn.
    }

    private IEnumerator AddScores()
    {
        float time = 0;

        for (int i = 0; i < _scorePlayersText.Count; i++)
            _scorePlayersText[i].text = TotalScores.Scores[i].ToString();

        //Moet zo geassigned worden vanwege array gedoe
        int[] orgScores = new int[4];

        int score1 = TotalScores.Scores[0];
        int score2 = TotalScores.Scores[1];
        int score3 = TotalScores.Scores[2];
        int score4 = TotalScores.Scores[3];

        orgScores[0] = score1;
        orgScores[1] = score2;
        orgScores[2] = score3;
        orgScores[3] = score4;

        yield return new WaitForSeconds(1);

        while (time <= 3)
        {
            for(int i = 0; i < _scorePlayersText.Count; i++)
            {
                _scorePlayersText[i].text = TotalScores.Scores[i].ToString();
                TotalScores.Scores[i] = orgScores[i] + (int)(Score[i] * (time / 3f));
            }

            time += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < _scorePlayersText.Count; i++)
        {
            TotalScores.Scores[i] = orgScores[i] + Score[i];
            _scorePlayersText[i].text = TotalScores.Scores[i].ToString();
        }

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    private void SaveGame() 
    {
        //Sla scores op naar het scorebord.
    }

    public virtual void StartGame()
    {

    }
}
