using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMovement : PlayerMovement
{  
    [SerializeField] protected float _mudSpeed = 2;

    private void OnTriggerEnter(Collider other)
    {
        //als de player over de moddle heen gaan word de movement langzamer gamaakt

        if (other.gameObject.CompareTag("Mud"))
               _moveSpeed = _mudSpeed;
        
        if (other.gameObject.CompareTag("Finish"))
            isOut = true;
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
