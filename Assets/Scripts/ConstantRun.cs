using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRun : PlayerMovement
{
    [SerializeField] private float _scaleSpeed = 5;
    [SerializeField] private float time;
    [SerializeField] private bool _constantRunIsPressed;
    private bool isRunning;
    public GameObject Apples;
    
    [SerializeField] private List <Vector3> spawnpoints = new List<Vector3>();

    void OnCollisionEnter(Collision collision)
    {
        // Controleer of de botsing met een muur is
        if (collision.gameObject.tag == "boom")  
        {
           // Stop met rennen als je een muur raakt
            _moveSpeed = 5;
        }
        if (collision.gameObject.tag == "boom" && isRunning == true)
        {
           
             int applesToInstantiate = 0;

                // Determine number of apples to instantiate based on _moveSpeed
                if (_moveSpeed >= 13)
                {
                    applesToInstantiate = 5;
                }
                else if (_moveSpeed >= 11)
                {
                    applesToInstantiate = 4;
                }
                else if (_moveSpeed >= 9)
                {
                    applesToInstantiate = 3;
                }
                else if (_moveSpeed >= 7)
                {
                    applesToInstantiate = 2;
                }
                else if (_moveSpeed >= 5)
                {
                    applesToInstantiate = 1;
                }
            // Loop to instantiate the determined number of apples
            for (int i = 0; i < applesToInstantiate; i++)
                {
                    GameObject apple = Instantiate(Apples, collision.gameObject.transform);
                    apple.transform.localPosition = spawnpoints[i];
                }
                isRunning = false;  

           

        }
    }
    
    private void Update()
    {
        if (PlayerType == Players.PlayerOne)
        { 
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Run());
            }

        }
        if (PlayerType == Players.PlayerTwo)
        {   
            if (Input.GetButtonDown("Fire2"))
            {
                StartCoroutine(Run());
            }

        }
        if (PlayerType == Players.PlayerThree)
        {
             if (Input.GetButtonDown("Fire3"))
             {
                 StartCoroutine(Run());
             }

        }
        if (PlayerType == Players.PlayerFour)
        {     
            if (Input.GetButtonDown("Fire4"))
            {
                 StartCoroutine(Run());
            }

        }
       

    }
    public override void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);
        if (isRunning) moveVertical = 0;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
    }

    IEnumerator Run()
    {
        isRunning = true;
        while (isRunning)
        {
            Vector3 forward = transform.forward * _moveSpeed * Time.deltaTime;
            transform.Translate(forward, Space.World);
            _moveSpeed += _scaleSpeed * Time.deltaTime;
            if (_moveSpeed >= 15f)
            {
                _moveSpeed = 15f; 
            }

            yield return null; 
        }
    }

}
