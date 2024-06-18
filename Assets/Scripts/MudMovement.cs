using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMovement : PlayerMovement
{  
    public bool _isInMud;
   [SerializeField] protected float _mudSpeed = 2;
    [SerializeField] private GameObject _mud;

    private void OnTriggerEnter(Collider other)
    {
        //als de player over de moddle heen gaan word de movement langzamer gamaakt
            _isInMud = true;  

         if (other.gameObject.CompareTag("Mud"))
         { 
            
           
               _moveSpeed = _mudSpeed;
            

         }
    }
    private void OnTriggerExit(Collider other)
    {
        //als player uit de modder is is het de normale snelheid terug 
            _isInMud = false;
        if (other.gameObject.CompareTag("Mud"))
        {
           
                _moveSpeed = 5f;
            

        }
    }
    

}
