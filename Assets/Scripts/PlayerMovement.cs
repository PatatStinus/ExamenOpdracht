using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected float _moveSpeed = 5f;
    public enum Players { PlayerOne, PlayerTwo, PlayerThree, PlayerFour }
    public Players PlayerType;

    public GameObject player;

    string horizontalAxis;
    string verticalAxis;

    void Start()
    {
        if (PlayerType == Players.PlayerOne)
        {
            horizontalAxis = "Horizontal player1";
        }
        else if(PlayerType == Players.PlayerTwo) 
        {
            horizontalAxis = "Horizontal player2";
        }
        else if (PlayerType == Players.PlayerThree)
        {
            horizontalAxis = "Horizontal player3";
        }
        else if (PlayerType == Players.PlayerFour) 
        {
            horizontalAxis = "Horizontal player4";
        }
       
        if (PlayerType == Players.PlayerOne)
        {
            verticalAxis = "Vertical player1";
        }
        else if (PlayerType == Players.PlayerTwo)
        {
            verticalAxis = "Vertical player2";
        }
        else if (PlayerType == Players.PlayerThree)
        {
            verticalAxis = "Vertical player3";
        }
        else if (PlayerType == Players.PlayerFour)
        {
            verticalAxis = "Vertical player4";
        }

    }

    void FixedUpdate()
    {
        MovePlayer();
        
    }

    public void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        player.transform.Translate(movement);
    }
}
