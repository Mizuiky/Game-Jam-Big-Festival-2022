using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_ItemData : ScriptableObject
{
    public string itemName;

    public Sprite itemIcon;

    public HouseRooms itemRoom;

    public bool hasEspecialItem;
}

[SerializeField]
public enum HouseRooms
{
    Bedroom,
    Kitchen,
    LivingRoom,
    Garden
}
