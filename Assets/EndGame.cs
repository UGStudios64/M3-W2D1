using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;

        if (count == 1)
        { Debug.Log("In Attesa dell'altro giocatore"); }
        else if (count == 2)
        { Debug.Log("LIVELLO COMPLETATO"); }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        Debug.Log("Un giocatore é uscito dall'area");
        if (count == 1)
        { Debug.Log("In Attesa dell'altro giocatore"); }
    }
}
