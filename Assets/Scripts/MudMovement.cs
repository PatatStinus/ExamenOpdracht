using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMovement : PlayerMovement
{
    public bool _isInMud;
    private float _mudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _mudSpeed = _moveSpeed % 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnCollisionEnter(Collider collider)
    {
        if (_isInMud)
        {
            _moveSpeed = _mudSpeed;
        }
    }
    
}
