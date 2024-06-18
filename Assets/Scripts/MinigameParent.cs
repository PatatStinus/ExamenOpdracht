using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameParent : MonoBehaviour
{
    protected float timer = 123;
    public List<int> Score { get; set; }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
            EndGame();
    }


    protected virtual void EndGame()
    {

    }

    private void SaveGame() 
    {
        //Sla scores op naar het scorebord.
    }

    public virtual void StartGame()
    {

    }
}
