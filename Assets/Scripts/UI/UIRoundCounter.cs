using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoundCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Game _roundSettings;

    //We will find our game script and subscribe to the OnRoundChanged event.
    private void Awake()
    {
        _roundSettings = FindObjectOfType<Game>();
        _roundSettings.OnRoundUpdated += OnRoundChanged;
    }

    //We will make that our text commponent will become the round counter UI display.
    private void OnRoundChanged()
    {
        _textComponent.text = $" {_roundSettings.Round}";
    }

    //Here will unsubscribes the event.
    private void OnDestroy()
    {
        _roundSettings.OnRoundUpdated -= OnRoundChanged;
    }
}

