using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]protected float _moveSpeed = 5f;
    
    public enum Players { PlayerOne, PlayerTwo, PlayerThree, PlayerFour }
    public Players PlayerType;
    [SerializeField] protected float _mudSpeed;
    

    string horizontalAxis;
    string verticalAxis;

    private void Awake()
    {
       
        _mudSpeed = _moveSpeed - 2;
    }

    void Start()
    {
        
        if (PlayerType == Players.PlayerOne)
        {
            verticalAxis = "Vertical player1";
            horizontalAxis = "Horizontal player1";
        }
        else if(PlayerType == Players.PlayerTwo) 
        {
            horizontalAxis = "Horizontal player2";
            verticalAxis = "Vertical player2";
        }
        else if (PlayerType == Players.PlayerThree)
        {
            horizontalAxis = "Horizontal player3";
            verticalAxis = "Vertical player3";
        }
        else if (PlayerType == Players.PlayerFour) 
        {
            verticalAxis = "Vertical player4";
            horizontalAxis = "Horizontal player4";
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
        transform.Translate(movement);
    }
    
    
    

}
