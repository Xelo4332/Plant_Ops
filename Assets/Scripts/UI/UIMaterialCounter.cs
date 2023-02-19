using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterialCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _player.OnMaterialUpdate += OnMaterialChanged;
    }

    private void OnMaterialChanged()
    {
        _textComponent.text = $" {_player.Material}";
    }

    private void OnDestroy()
    {
        _player.OnMaterialUpdate -= OnMaterialChanged;
    }


}
