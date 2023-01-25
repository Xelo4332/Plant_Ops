using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleItem : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact += OnPlayerInteracted;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact -= OnPlayerInteracted;
        }
    }

    protected virtual void OnPlayerInteracted()
    {

    }

}
