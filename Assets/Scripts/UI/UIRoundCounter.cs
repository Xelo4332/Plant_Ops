using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoundCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Game _roundSettings;

    private void Awake()
    {
        _roundSettings = FindObjectOfType<Game>();
        _roundSettings.OnRoundUpdated += OnRoundChanged;
    }

    private void OnRoundChanged()
    {
        _textComponent.text = $" {_roundSettings.Round}";
    }

    private void OnDestroy()
    {
        _roundSettings.OnRoundUpdated -= OnRoundChanged;
    }
}

