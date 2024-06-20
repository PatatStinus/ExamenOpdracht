using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
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
