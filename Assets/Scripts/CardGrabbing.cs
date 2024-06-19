using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardGrabbing : MonoBehaviour
{
    [SerializeField] private int _round = 1;
    [SerializeField] private GameObject _cursor;
    [SerializeField] private LayerMask _cardLayer;
    [SerializeField] private Transform _desiredCardPos;
    private int _sceneIndex;


    private void Update()
    {
        string horizontal = "";
        string vertical = "";

        //Verschillende spelers kunnen elke ronde een kaart pakken.
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

        //Verplaats de cursor
        _cursor.transform.Translate(new Vector3(Input.GetAxis(horizontal) * Time.deltaTime * 300, Input.GetAxis(vertical) * Time.deltaTime * 300, 0));

        //TODO: Verander GetMouseButtonDown naar de interact knop van de spelers
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(_cursor.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000, _cardLayer))
            {
                //Check welke kaarttype opgepakt is.
                Card card = hit.transform.GetComponent<Card>();
                if (card.CardType == Card.Cards.MudRunner)
                    _sceneIndex = 1;
                else if (card.CardType == Card.Cards.CatchAndRun)
                    _sceneIndex = 3;
                else if (card.CardType == Card.Cards.AnimalBoxing)
                    _sceneIndex = 4;

                //Start animatie om kaart te laten zien
                StartCoroutine(ShowCard(hit.transform.gameObject));
            }
        }
    }

    IEnumerator ShowCard(GameObject card)
    {
        float time = 0;
        Vector3 orgCardPos = card.transform.position;
        Quaternion orgCardRot = card.transform.rotation;

        while(time < 2)
        {
            card.transform.position = Vector3.Lerp(orgCardPos, _desiredCardPos.position, time / 2f);
            card.transform.rotation = Quaternion.Slerp(orgCardRot, _desiredCardPos.rotation, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;
        while (time < 2) 
        {
            time += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(_sceneIndex);
    }
}
