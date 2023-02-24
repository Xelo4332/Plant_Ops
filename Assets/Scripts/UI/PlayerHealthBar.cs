using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerHealthBar : MonoBehaviour
{
    //Deni
    private Player _player;
    private Image _image;


    //here we will find our components, and subcribe an event for player health update.
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

    //If player is getting hit, it will make player screen become more red and red. 
    //I made a safety measure, while player health is bigger than 50, it will activate the method, I don't want to screen becomes to red.
    private void OnPlayerHealthUpdate()
    {
        if (_player._health > 50)
        {
            var newColor = _image.color;
            newColor.a = 1-(float)_player._health / 100;
            _image.color = newColor;
        }

    }

    //UnSubscribes the event.
    private void OnDestroy()
    {
        _player.OnhealthUpdate -= OnPlayerHealthUpdate;
    }
}
