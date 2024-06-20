using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public class Card : MonoBehaviour
{
    public enum Cards { MudRunner, CatchAndRun, AnimalBoxing}
    public Cards CardType = Cards.MudRunner;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);

        string gameName = "";

        if (CardType == Cards.MudRunner) gameName = "Mud Bath";
        else if (CardType == Cards.CatchAndRun) gameName = "Catch And Run";
        else if (CardType == Cards.AnimalBoxing) gameName = "Animal Boxing";

        transform.GetChild(0).GetComponent<TextMeshPro>().text = gameName;
    }
}
