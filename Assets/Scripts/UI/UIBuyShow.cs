using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyShow : InteractibleItem
{
    //Deni
    [SerializeField] private GameObject _UICanvas;
    [SerializeField] private GameObject _outLineDoor;
    //Here we will set our uicanvas true and turn on sprite online when he will enter the collider.
    private new void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            _UICanvas.SetActive(true);
            _outLineDoor.SetActive(true);

        }
    }
    //When will exit from the collider, then we will turn canvas and outline.
    private new void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.TryGetComponent(out Player player))
        {
            _UICanvas.SetActive(false);
            _outLineDoor.SetActive(false);
            Debug.Log("test2");
        }
    }


}
