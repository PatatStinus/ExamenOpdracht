using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ScoreBoardSwitcher;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private List<Text> _winningPlayersText = new List<Text>();
    private List<Text> _winningPlayersScoreText = new List<Text>();
    private bool _endScreenOn = false;
    private int _activeScreenIndex = 0;
    [SerializeField] private List<GameObject> _screens = new List<GameObject>();
    [SerializeField] private List<Text> _playerNameStats = new List<Text>();
    [SerializeField] private List<Text> _playerScoreStats = new List<Text>();

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
        //After tapping left, show extra stats
        //MAYBE: Another tap show leaderboards.
        //Last slide, prompt another tap to go back to the main menu.

        _endScreen.SetActive(true);
        _endScreenOn = true;

        List<int> scores = new List<int>();
        foreach(int score in TotalScores.Scores)
            scores.Add(score);

        scores.Sort();
        scores.Reverse();
        for (int i = 0; i < _winningPlayersScoreText.Count; i++)
            _winningPlayersScoreText[i].text = scores[i].ToString();

        int indexMostWon = 0;
        int indexMostLost = 0;

        for (int i = 1; i < Stats.MostWonPlayers.Count; i++)
        {
            if (Stats.MostWonPlayers[indexMostWon] < Stats.MostWonPlayers[i])
                indexMostWon = i;
            if (Stats.MostLostPlayers[indexMostLost] > Stats.MostLostPlayers[i])
                indexMostLost = i;
        }

        _playerScoreStats[0].text = Stats.MostWonPlayers[indexMostWon].ToString();
        _playerScoreStats[1].text = Stats.MostLostPlayers[indexMostLost].ToString();
        _playerScoreStats[2].text = Stats.TimeInMud.ToString("0.00");
        _playerScoreStats[3].text = Stats.DefendedAmount.ToString();
        _playerScoreStats[4].text = Stats.SpeedTreeHit.ToString("0.00");
    }

    private void Update()
    {
        if (!_endScreenOn) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && _activeScreenIndex != 0)
        {
            _screens[_activeScreenIndex].SetActive(false);
            _activeScreenIndex--;
            _screens[_activeScreenIndex].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _activeScreenIndex != 1)
        {
            _screens[_activeScreenIndex].SetActive(false);
            _activeScreenIndex++;
            _screens[_activeScreenIndex].SetActive(true);
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
