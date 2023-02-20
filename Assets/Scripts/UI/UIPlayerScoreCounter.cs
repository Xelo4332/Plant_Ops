using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Player _playerScore;

    //Here we will find our player script and will subcribe to the event.
    private void Awake()
    {
        _playerScore = FindObjectOfType<Player>();
        _playerScore.OnScoreUpdate += OnScoreChanged;
    }
    //We will make that unity will know that the text will diplay what score int is current is.
    private void OnScoreChanged()
    {
        _textComponent.text = $" {_playerScore._score}";
    }
    //Here we will unsubcribe the event.
    private void OnDestroy()
    {
         _playerScore.OnScoreUpdate -= OnScoreChanged;
    }

}
