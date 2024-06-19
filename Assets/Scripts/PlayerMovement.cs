using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]protected float _moveSpeed = 5f;
    


    public enum Players { PlayerOne, PlayerTwo, PlayerThree, PlayerFour }
    public Players PlayerType;

    
    public bool isOut;

    protected string horizontalAxis;
    protected string verticalAxis;

   

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
        if(Input.GetAxis(horizontalAxis) != 0 || Input.GetAxis(verticalAxis) != 0)
            MovePlayer(); 
    }

    public virtual void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
    }




}
