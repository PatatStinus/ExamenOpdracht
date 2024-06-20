using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private List<Text> _winningPlayersText = new List<Text>();
    private List<Text> _winningPlayersScoreText = new List<Text>();

    private void Awake()
    {
        for (int i = 0; i < _winningPlayersText.Count; i++)
        {
            _winningPlayersScoreText.Add(_winningPlayersText[i].transform.GetChild(0).GetComponent<Text>());
            Stats.MostLostPlayers.Add(0);
            Stats.MostWonPlayers.Add(0);
        }
    }

    public void OpenEndScreen()
    {
        //Show who won first
        //After tapping left, show extra stats
        //MAYBE: Another tap show leaderboards.
        //Last slide, prompt another tap to go back to the main menu.

        _endScreen.SetActive(true);
        bool listSorted = false;

        List<int> scores = new List<int>();
        foreach(int score in TotalScores.Scores)
            scores.Add(score);

        scores.Sort();
        scores.Reverse();
        for (int i = 0; i < _winningPlayersScoreText.Count; i++)
        {
            Debug.Log(scores[i]);
            _winningPlayersScoreText[i].text = scores[i].ToString();
        }
    }
}

public static class Stats
{
    public static List<int> MostWonPlayers = new List<int>();
    public static List<int> MostLostPlayers = new List<int>();
    public static int PlayerMostInMud;
    public static float TimeInMud;
    public static int PlayerHardestTree;
    public static float SpeedTreeHit;
    public static int PlayerMostDefended;
    public static int DefendedAmount;
}
