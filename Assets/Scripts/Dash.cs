using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash: PlayerMovement
{
    bool _HasDashed;
    float _DashCooldown = 0;
    [SerializeField]private LayerMask playerLayer;
    public float dashSpeed = 20f;        
    public float dashDuration = 0.2f;
    public BoxCollider box;
    private AnimalBoxingManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<AnimalBoxingManager>();
    }

    private void Update()
    {
        if (PlayerType == Players.PlayerOne)
        {
            if (Input.GetButtonDown("Fire1") && _DashCooldown == 0)
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerTwo)
        {
            if (Input.GetButtonDown("Fire2") && _DashCooldown == 0)
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerThree)
        {
            if (Input.GetButtonDown("Fire3") && _DashCooldown == 0)
            {
                StartCoroutine(PerformDash());
            }

        }
        if (PlayerType == Players.PlayerFour)
        {
            if (Input.GetButtonDown("Fire4") && _DashCooldown == 0)
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

        _DashCooldown = 0.5f;

        while (_DashCooldown > 0)
        {
            _DashCooldown -= Time.deltaTime;
            yield return null;
        }

        _DashCooldown = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_HasDashed && collision.gameObject.TryGetComponent(out PlayerMovement hitPlayer))
            _manager.PlayerHit(this, hitPlayer);
        if (collision.gameObject == box && _HasDashed)
        {
            _HasDashed = false;
        }
    }
}
