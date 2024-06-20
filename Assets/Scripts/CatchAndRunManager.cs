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
        for (int i = 0; i < Players.Count; i++)
        {
            if (Players[i] == player)
            {
                Score[i] += 10;
            }
        }
    }

}
