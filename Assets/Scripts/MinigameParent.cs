using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameParent : MonoBehaviour
{
    protected float _timer = 123;
    public List<int> Score { get; set; }
    public List<PlayerMovement> Players;
    protected bool _gameEnded = false;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if(_timer < 0 && !_gameEnded)
            EndGame();
    }


    protected virtual void EndGame()
    { 
        _gameEnded = true;

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
