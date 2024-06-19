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

    private void Awake()
    {
        Score = new int[4];
    }

    protected virtual void Update()
    {
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
        Debug.Log("Game Ended");
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
