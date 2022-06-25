using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public HouseRooms ItemRoom { get; }

    public void Interact();

    public void ScaleAnimation();
}
