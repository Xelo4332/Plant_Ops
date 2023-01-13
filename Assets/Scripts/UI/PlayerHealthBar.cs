using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerHealthBar : MonoBehaviour
{
    private Player _player;
    private Image _image;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        if (_player == null)
        {
            Debug.LogError($"Player not found in {name} class!");
            return;
        }
        _image = GetComponent<Image>();
        _player.OnhealthUpdate += OnPlayerHealthUpdate;
        OnPlayerHealthUpdate();
    }

    private void OnPlayerHealthUpdate()
    {
        if (_player.Health > 50)
        {
            var newColor = _image.color;
            newColor.a = 1-(float)_player.Health / 100;
            _image.color = newColor;
        }

    }

    private void OnDestroy()
    {
        _player.OnhealthUpdate -= OnPlayerHealthUpdate;
    }
}
