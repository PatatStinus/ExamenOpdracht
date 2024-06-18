using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGrabbing : MonoBehaviour
{
    [SerializeField] private int _round = 1;
    [SerializeField] private GameObject _cursor;

    private void Update()
    {
        string horizontal = "";
        string vertical = "";

        if(_round == 1)
        {
            horizontal = "Horizontal player1";
            vertical = "Vertical player1";
        }
        else if (_round == 2) 
        {
            horizontal = "Horizontal player2";
            vertical = "Vertical player2";
        }
        else if (_round == 3)
        {
            horizontal = "Horizontal player3";
            vertical = "Vertical player3";
        }

        _cursor.transform.Translate(new Vector3(Input.GetAxis(horizontal) * Time.deltaTime * 300, Input.GetAxis(vertical) * Time.deltaTime * 300, 0));
    }
}
