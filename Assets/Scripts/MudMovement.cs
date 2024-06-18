using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudMovement : PlayerMovement
{  
    public bool _isInMud;
   
    [SerializeField] private GameObject _mud;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
            _isInMud = true;  

         if (other.gameObject.CompareTag("Mud"))
         { 
            
           
               _moveSpeed = _mudSpeed;
            

         }
    }
    private void OnTriggerExit(Collider other)
    {
            _isInMud = false;
        if (other.gameObject.CompareTag("Mud"))
        {
           
                _moveSpeed = 5f;
            

        }
    }
    

}
