using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private List<string> _playerNames = new List<string>();

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
        List<string> names = new List<string>();


        for (int j= 0; j < scores.Count; j++)
        {
            for (int i = 0; i < TotalScores.Scores.Length; i++)
            {
                if (scores[j] == TotalScores.Scores[i])
                    names.Add(_playerNames[i]);
            }
        }

        for (int i = 0; i < _winningPlayersScoreText.Count; i++)
        {
            _winningPlayersText[i].text = names[i];
            _winningPlayersScoreText[i].text = scores[i].ToString();
        }

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
        _playerNameStats[0].text = _playerNames[indexMostWon];
        _playerScoreStats[1].text = Stats.MostLostPlayers[indexMostLost].ToString();
        _playerNameStats[1].text = _playerNames[indexMostLost];
        _playerScoreStats[2].text = Stats.TimeInMud.ToString("0.00");
        _playerNameStats[2].text = _playerNames[Stats.PlayerMostInMud];
        _playerScoreStats[3].text = Stats.DefendedAmount.ToString();
        _playerNameStats[3].text = _playerNames[Stats.PlayerMostDefended];
        _playerScoreStats[4].text = Stats.SpeedTreeHit.ToString("0.00");
        _playerNameStats[4].text = _playerNames[Stats.PlayerHardestTree];
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
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_activeScreenIndex == 1)
            {
                //TO MAIN MENU, clear all stats.
                CardGrabbing.PlayedGames.Clear();
                Stats.MostLostPlayers.Clear();
                Stats.MostWonPlayers.Clear();
                Stats.PlayerMostInMud = 0;
                Stats.TimeInMud = 0;
                Stats.DefendedAmount = 0;
                Stats.SpeedTreeHit = 0;
                Stats.PlayerHardestTree = 0;
                Stats.PlayerMostDefended = 0;
                Cursor.visible = true;
                SceneManager.LoadScene(0);
                return;
            }
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
