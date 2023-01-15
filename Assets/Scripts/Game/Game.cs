using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    public event Action OnRoundUpdated;
    public int Round => _round;
    private int _round = 1;

    public void CompleteRound()
    {
        _round++;
        OnRoundUpdated?.Invoke();
    }


}
