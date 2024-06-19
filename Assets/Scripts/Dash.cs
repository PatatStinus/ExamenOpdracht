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

    private AnimalBoxingManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<AnimalBoxingManager>();
    }

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

        //in deze loop word een hoevang de dash duurd
        while ( startTime <= dashDuration)
        {
            startTime += Time.deltaTime;
            // Move de player in de dash richting.
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            yield return null; 
        }
        _HasDashed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_HasDashed && collision.gameObject.TryGetComponent(out PlayerMovement hitPlayer))
            _manager.PlayerHit(this, hitPlayer);
    }
}
