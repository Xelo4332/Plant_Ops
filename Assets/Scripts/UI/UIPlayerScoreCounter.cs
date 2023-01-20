using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Player _playerScore;

    private void Awake()
    {
        _playerScore = FindObjectOfType<Player>();
        _playerScore.OnScoreUpdate += OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _textComponent.text = $" {_playerScore._score}";
    }

    private void OnDestroy()
    {
                _playerScore.OnScoreUpdate -= OnScoreChanged;
    }

}
