using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyShow : MonoBehaviour
{
    [SerializeField] private GameObject _buyImage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _buyImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _buyImage.SetActive(false);
    }


}
