using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesScore : MonoBehaviour
{
    public CatchAndRunManager CarM;
    private void Awake()
    {
        CarM = FindObjectOfType<CatchAndRunManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {

            if (collision.gameObject.tag == "Player")
            {
                CarM.CatchApples(collision.gameObject.GetComponent<PlayerMovement>());
                // score te voegen
                Destroy(gameObject);
                
            }
    }
}
