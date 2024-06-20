using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMovement : PlayerMovement
{  
    [SerializeField] protected float _mudSpeed = 2;
    public float TimeInMud { 
        get { return _timeInMud; }
    }
    private float _timeInMud;

    private void OnTriggerEnter(Collider other)
    {
        //als de player over de moddle heen gaan word de movement langzamer gamaakt

        if (other.gameObject.CompareTag("Mud"))
            _moveSpeed = _mudSpeed;
        
        if (other.gameObject.CompareTag("Finish"))
            isOut = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Mud"))
            _timeInMud += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        //als player uit de modder is is het de normale snelheid terug 
        if (other.gameObject.CompareTag("Mud"))
            _moveSpeed = 5f;

        if (other.gameObject.CompareTag("Finish"))
            isOut = true;
    }
}
