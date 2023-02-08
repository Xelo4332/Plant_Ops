using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuyShow : InteractibleItem
{
    [SerializeField] private GameObject _UICanvas;
    [SerializeField]
 
    private new void OnTriggerEnter2D(Collider2D col)
    {

        if (col.TryGetComponent(out Player player))
        {
            _UICanvas.SetActive(true);

        }
    }

    private new void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.TryGetComponent(out Player player))
        {
            _UICanvas.SetActive(false);
            Debug.Log("test2");
        }
    }


}
