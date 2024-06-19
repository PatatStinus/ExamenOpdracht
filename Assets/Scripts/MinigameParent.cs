using System;
using System.Collections.Generic;
using UnityEngine;
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
        if (!_gameEnded)
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


        /*else if ()
        {

        }
        else if ()
        {

        }*/
        
        //TODO: Geef game review en stuur iedereen terug naar kaart pak scene, tenzij alle kaarten al gepakt zijn.
    }

    private void SaveGame() 
    {
        //Sla scores op naar het scorebord.
    }

    public virtual void StartGame()
    {

    }
}
