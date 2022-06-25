using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private Flower _flower;

    [SerializeField]
    private GameObject _petal;

    [SerializeField]
    private Transform _petalPosition;

    [SerializeField]
    private Transform _manager;
    
    public void ShowEspecialItem()
    {
        var obj = Instantiate(_petal, _petalPosition, _manager);

        var petal = obj.GetComponent<Petal>();

        if(petal != null)
        {
            petal.Glow();
        }
    }
}
