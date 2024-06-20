using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardGrabbing : MonoBehaviour
{
    [SerializeField] private int _round = 1;
    [SerializeField] private GameObject _cursor;
    [SerializeField] private LayerMask _cardLayer;
    [SerializeField] private Transform _desiredCardPos;
    [SerializeField] private List<Text> _scoreText;
    [SerializeField] private List<Card> _cards;
    [SerializeField] private EndGame _endGame;
    private int _sceneIndex;
    public static List<bool> PlayedGames = new List<bool>();
    private bool _endingGame = true;

    private void Start()
    {
        Cursor.visible = false;
        for (int i = 0; i < _scoreText.Count; i++)
            _scoreText[i].text = TotalScores.Scores[i].ToString();

        if(PlayedGames.Count < 3)
        {
            PlayedGames.Add(false);
            PlayedGames.Add(false);
            PlayedGames.Add(false);
        }

        //Randomize de kaarten
        int n = _cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            var value = _cards[k];
            _cards[k] = _cards[n];
            _cards[n] = value;
        }

        _cards[0].CardType = Card.Cards.MudRunner;
        _cards[1].CardType = Card.Cards.CatchAndRun;
        _cards[2].CardType = Card.Cards.AnimalBoxing;

        for (int i = 0; i < _cards.Count; i++)
        {
            if (PlayedGames[i])
                Destroy(_cards[i].gameObject);

            //Als alle games gespeeld zijn, eindig de game
            if (!PlayedGames[i])
                _endingGame = false;
        }

        if(_endingGame)
        {
            //End de game
            _endGame.OpenEndScreen();
        }
    }

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
                {
                    _sceneIndex = 2;
                    PlayedGames[0] = true;
                }
                else if (card.CardType == Card.Cards.CatchAndRun)
                {
                    _sceneIndex = 3;
                    PlayedGames[1] = true;
                }
                else if (card.CardType == Card.Cards.AnimalBoxing)
                {
                    _sceneIndex = 4;
                    PlayedGames[2] = true;
                }

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
