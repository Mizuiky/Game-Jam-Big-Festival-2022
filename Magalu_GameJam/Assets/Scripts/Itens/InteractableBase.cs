using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Serializable Fields

    [SerializeField]
    private SO_ItemData _data;

    [SerializeField]
    private SO_Dialog _dialog;

    [SerializeField]
    private SpriteRenderer _itemIcon;

    #endregion

    #region Private Fields

    protected string _itemName;

    private HouseRooms _itemRoom;

    #endregion

    #region Properties

    public HouseRooms ItemRoom
    {
        get => _itemRoom;
    }

    #endregion

    public void Start()
    {
        Init();
    }   

    protected virtual void Init()
    {
        _itemName = _data.itemName;
        _itemRoom = _data.itemRoom;
        _itemIcon.sprite = _data.itemIcon;
    }

    public virtual void Interact() 
    {
        ScaleAnimation();

        DialogManager.Instance.Initialize(_dialog, _itemName);   
    }

    public void ScaleAnimation()
    {
        //this.transform.DOScale(5, 0.3f);
    }
}
