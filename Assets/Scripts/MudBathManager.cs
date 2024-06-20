using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBathManager : MinigameParent
{
    protected override void Update()
    {
        base.Update();
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

    protected override void EndGame()
    {
        base.EndGame();

        int longestInMud = 0;
        float longestTimeInMud = (Players[0] as MudMovement).TimeInMud;
        
        for (int i = 1; i < Players.Count; i++)
        {
            if ((Players[i] as MudMovement).TimeInMud > (Players[longestInMud] as MudMovement).TimeInMud)
            {
                longestInMud = i;
                longestTimeInMud = (Players[i] as MudMovement).TimeInMud;
            }
        }

        Stats.PlayerMostInMud = longestInMud;
        Stats.TimeInMud = longestTimeInMud;
    }
}
