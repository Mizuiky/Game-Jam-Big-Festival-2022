using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Serializable Fields

    [Header("Animation Scale")]

    [SerializeField]
    private float _scale;

    [SerializeField]
    private float _timeToScale;

    [SerializeField]
    private SO_ItemData _data;

    [SerializeField]
    private SO_Dialog _dialog;

    [SerializeField]
    private SpriteRenderer _itemIcon;

    [SerializeField]
    private Transform _model;

    [SerializeField]
    private Ease _ease;

    [SerializeField]
    private bool _hasItem;

    #endregion

    #region Private Fields

    protected string _itemName;

    private HouseRooms _itemRoom;

    private Vector3 _originalScale;

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

    public void OnMouseEnter()
    {
        ScaleAnimation();
    }

    public void OnMouseExit()
    {
        ResetScale();
    }

    protected virtual void Init()
    {
        _itemName = _data.itemName;
        _itemRoom = _data.itemRoom;
        _itemIcon.sprite = _data.itemIcon;

        _originalScale = _model.localScale;
    }

    public virtual void Interact() 
    {
        DialogManager.Instance.Initialize(_dialog, _itemName, _hasItem);   
    }

    public void ScaleAnimation()
    {
        _model.DOScale(_scale, _timeToScale).SetLoops(2, LoopType.Yoyo).SetEase(_ease);
    }

    public void ResetScale()
    {
        _model.localScale = _originalScale;
    }
}
