using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Bassicly a event script that will send signal to our UIRound and save the current round count for the spawner script.
public class Game : MonoBehaviour
{
    public event Action OnRoundUpdated;
    public int Round => _round;
    private int _round = 1;

    //Adds +1 to the current round and invokes the event.
    public void CompleteRound()
    {
        _round++;
        OnRoundUpdated?.Invoke();
    }


}
