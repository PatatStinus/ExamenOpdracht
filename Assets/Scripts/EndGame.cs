using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;

    public void OpenEndScreen()
    {
        //Show who won first
        //After tapping left, show extra stats
        //MAYBE: Another tap show leaderboards.
        //Last slide, prompt another tap to go back to the main menu.
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
