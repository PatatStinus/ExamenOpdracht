using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRun : PlayerMovement
{
    [SerializeField] private float _scaleSpeed = 5;
    [SerializeField] private float time;
    [SerializeField] private bool _constantRunIsPressed;
    private bool isRunning;
    void OnCollisionEnter(Collision collision)
    {
        // Controleer of de botsing met een muur is
        if (collision.gameObject.tag == "Wall")  
        {
            isRunning = false;  // Stop met rennen als je een muur raakt
            _moveSpeed = 5;
        }
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Run());
        }
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Run());
        }
        if (Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(Run());
        }
        if (Input.GetButtonDown("Fire4"))
        {
            StartCoroutine(Run());
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
