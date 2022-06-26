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
    private Transform _model;

    [SerializeField]
    private Ease _ease;

    #endregion

    #region Private Fields

    protected string _itemName;

    private HouseRooms _itemRoom;

    private bool _hasEspecialItem;

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
        _hasEspecialItem = _data.hasEspecialItem;

        _originalScale = _model.localScale;
    }

    public virtual void Interact() 
    {
        DialogManager.Instance.Initialize(_dialog, _hasEspecialItem, _itemName);

        if(_hasEspecialItem)
            _hasEspecialItem = false;
    }

    public void ScaleAnimation()
    {
        _model.DOScale(_scale, _timeToScale).SetLoops(2, LoopType.Yoyo).SetEase(_ease);
    }

    public void ResetScale()
    {
        _model.DOKill();
        _model.localScale = _originalScale;
        
    }
}
