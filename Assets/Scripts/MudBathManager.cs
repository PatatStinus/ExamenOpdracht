using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBathManager : MinigameParent
{
    private void Update()
    {
        //Change scores
        for (int i = 0; i < Players.Count; i++)
        {
            if (!Players[i].isOut) Score[i] = (int)Mathf.Ceil(_timer);
        }

        for (int i = 0; i < Players.Count; i++) 
        {
            if (!Players[i].isOut) break;
            
            //All players reached finish
            if(i == 3)
                EndGame();
        }
    }
}
