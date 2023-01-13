using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int Round => _round;
    private int _round = 1;

    public void CompleteRound()
    {
        _round++;
    }

}
