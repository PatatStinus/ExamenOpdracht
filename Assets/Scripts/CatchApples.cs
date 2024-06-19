using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchApples : MonoBehaviour
{
    public GameObject Apples;
    public GameObject Applesspawner;
    // Start is called before the first frame update
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            if (Applesspawner)
            {
                Instantiate(Apples);

            }
            
        }
    }
}
