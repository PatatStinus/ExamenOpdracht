using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class ApplesScore : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject)
            {
                // score te voegen
                Destroy(gameObject); 
            }
    }
}
