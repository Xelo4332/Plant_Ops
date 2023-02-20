using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaterialCounter : MonoBehaviour
{
    [SerializeField] private Text _textComponent;
    private Player _player;

    //Here we will find our player script and will subcribe to the event.
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _player.OnMaterialUpdate += OnMaterialChanged;
    }

    //Text component will display current count of material we will have.
    private void OnMaterialChanged()
    {
        _textComponent.text = $" {_player.Material}";
    }

    //Here we will unsubcribe from the event.
    private void OnDestroy()
    {
        _player.OnMaterialUpdate -= OnMaterialChanged;
    }


}
