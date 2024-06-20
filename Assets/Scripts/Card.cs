using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Card : MonoBehaviour
{
    public enum Cards { MudRunner, CatchAndRun, AnimalBoxing}
    public Cards CardType = Cards.MudRunner;
}
