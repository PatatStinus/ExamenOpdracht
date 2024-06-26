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

    private Rigidbody rb;

    private bool _waitingForStart = true;
    private Vector3 _orgPos;
   

    IEnumerator Start()
    {
        //input voor de 4 players

        rb = GetComponent<Rigidbody>();
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

        _orgPos = transform.position;
        float time = 0;
        while (time < 3)
        {
            time += Time.deltaTime;
            transform.position = _orgPos;
            yield return null;
        }

        _waitingForStart = false;
    }

    private void Update()
    {
        if (!isOut && !_waitingForStart)
            _orgPos = transform.position;
        if(isOut)
            transform.position = _orgPos;
    }

    void FixedUpdate()
    {
        if(Input.GetAxis(horizontalAxis) != 0 || Input.GetAxis(verticalAxis) != 0)
            MovePlayer(); 
    }

    public virtual void MovePlayer()
    {
        // de input voor horizontal en vertical
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);
        
        //de movement berekenen
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
    }




}
