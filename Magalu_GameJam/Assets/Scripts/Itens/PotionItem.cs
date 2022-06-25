using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : InteractableBase
{
    public override void Interact()
    {
        Debug.Log("Interact with: " + this._itemName);
        base.Interact();
    }
}
