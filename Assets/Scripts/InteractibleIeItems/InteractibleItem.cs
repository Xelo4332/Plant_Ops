using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleItem : MonoBehaviour
{
      //We will create here a virtual method so we could override it in other scripts.
    //In this method we will subscribe an event if a object collides with a player and will have this script or inheritance it to other script.
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact += OnPlayerInteracted;
        }
    }
    //Same as upper script, but here we unsubscribes from the event.
    protected virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact -= OnPlayerInteracted;
        }
    }
    //We will override this method in other script. 
    protected virtual void OnPlayerInteracted()
    {

    }

}
