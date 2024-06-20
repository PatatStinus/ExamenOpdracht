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
    public float HardestHitSpeed { get { return _hardestHitSpeed; } }
    private float _hardestHitSpeed = 0;
    
    [SerializeField] private List <Vector3> spawnpoints = new List<Vector3>();

    void OnCollisionEnter(Collision collision)
    {
        // Controleer of de botsing met een muur is
        if (collision.gameObject.tag == "boom")  
        {
           // Stop met rennen als je een muur raakt
        }
        if (collision.gameObject.tag == "boom" && isRunning == true)
        {
           
             int applesToInstantiate = 0;

            if(_moveSpeed > _hardestHitSpeed)
                _hardestHitSpeed = _moveSpeed;

                // Determine number of apples to instantiate based on _moveSpeed
                if (_moveSpeed >= 23)
                {
                    applesToInstantiate = 5;
                }
                else if (_moveSpeed >= 20)
                {
                    applesToInstantiate = 4;
                }
                else if (_moveSpeed >= 15)
                {
                    applesToInstantiate = 3;
                }
                else if (_moveSpeed >= 10)
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
            _moveSpeed = 5;

           

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

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);

        if (isRunning)
        {
            moveHorizontal = 0;
            moveVertical = 0;
        }
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * _moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    IEnumerator Run()
    {
        isRunning = true;
        while (isRunning)
        {
            Vector3 forward = transform.forward * _moveSpeed * Time.deltaTime;
            transform.Translate(forward, Space.World);
            _moveSpeed += _scaleSpeed * Time.deltaTime;
            if (_moveSpeed >= 25f)
            {
                _moveSpeed = 25f; 
            }

            yield return null; 
        }
    }

}
