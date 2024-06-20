using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAndRunManager : MinigameParent
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
         base.Update();
        
        
    }
    public void CatchApples(PlayerMovement player)
    {
        //als een player een apple pakt maak score +10
        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i] == player)
            {
                Score[i] += 10;
            }
        }
    }

    protected override void EndGame()
    {
        base.EndGame();

        int hardestHit = 0;
        float speedHit = (Players[0] as ConstantRun).HardestHitSpeed;

        for (int i = 1; i < Players.Count; i++)
        {
            if ((Players[i] as ConstantRun).HardestHitSpeed > (Players[hardestHit] as ConstantRun).HardestHitSpeed)
            {
                hardestHit = i;
                speedHit = (Players[i] as ConstantRun).HardestHitSpeed;
            }
        }

        Stats.PlayerHardestTree = hardestHit;
        Stats.SpeedTreeHit = speedHit;
    }

}
