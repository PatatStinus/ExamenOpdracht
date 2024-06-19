using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBoxingManager : MinigameParent
{
    protected override void Update()
    {
        base.Update();
        int allOutPlayers = 0;
        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i].isOut)
                allOutPlayers++;
            
            //All players out
            if (i == 3 && allOutPlayers == 3)
                EndGame();
        }
    }

    public void PlayerHit(PlayerMovement attacker, PlayerMovement defender)
    {
        for (int i = 0; i < Players.Count; i++)
        {
            //Add score to attacker depending on how much time has passed.
            if(Players[i] == attacker)
                Score[i] += (int)(_timer / 2f);

            //Remove defender from game.
            if (Players[i] == defender) 
            {
                Players[i].isOut = true;
                Players[i].gameObject.SetActive(false);
            }
        }
    }
}
