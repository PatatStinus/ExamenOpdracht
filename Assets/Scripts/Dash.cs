using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash: PlayerMovement
{
    bool _HasDashed;
    float _DashCooldown;
    [SerializeField]private LayerMask playerLayer;
    public float dashSpeed = 20f;        
    public float dashDuration = 0.2f;
    private void Update()
    {
        if (PlayerType == Players.PlayerOne)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerTwo)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerThree)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerFour)
        {
            if (Input.GetButtonDown("Fire4"))
            {
                StartCoroutine(PerformDash());
            }

        }

    }
    private IEnumerator PerformDash()
    {
        _HasDashed = true;  

        
        Vector3 dashDirection = transform.forward;
        float startTime = 0;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.zero, out hit, playerLayer))
        {
            Debug.Log("The ray hit: " + hit.transform.name);
            hit.transform.GetComponent<PlayerMovement>().isOut = true;
        }
        while ( startTime <= dashDuration)
        {
            startTime += Time.deltaTime;
            // Move de player in de dash direction.
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            yield return null; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}