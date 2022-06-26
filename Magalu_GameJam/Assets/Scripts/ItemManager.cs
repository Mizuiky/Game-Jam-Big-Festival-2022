using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System.Linq;

public class ItemManager : Singleton<ItemManager>
{
    #region Serializable Field

    [SerializeField]
    private Flower _flower;

    [SerializeField]
    private GameObject _petal;

    [SerializeField]
    private Transform _petalPosition;

    [SerializeField]
    private Transform _manager;

    [SerializeField]
    private int _maxPetalNumber;

    #endregion

    #region Private Fields

    private int _currentPetalIndex;

    private List<int> _indexList;

    #endregion

    private void Start()
    {
        Init();
    }

    #region Petal Item

    public void ShowEspecialItem()
    {
        GetRandomPetalIndex();

        var obj = Instantiate(_petal, _petalPosition, _manager);

        var petal = obj.GetComponent<Petal>();

        if(petal != null)
            petal.Glow();
    }

    public void ShowPetal()
    {
        if(_indexList.Count > 0)
        {
            _flower.EnablePetal(_indexList[_currentPetalIndex]);

            _indexList.RemoveAt(_currentPetalIndex);
        }      
    }

    private void GetRandomPetalIndex()
    {
        if(_indexList.Count == 1)
        {
            _currentPetalIndex = 0;
            return;
        }

        var randomIndex = Random.Range(0, _indexList.Count - 1);

        _currentPetalIndex = randomIndex;
    }

    #endregion

    private void Init()
    {
        FindFlower();

        _indexList = new List<int>();

        _currentPetalIndex = -1;

        for (int i = 0; i < _maxPetalNumber; i++)
        {
            _indexList.Add(i);
        }

        _indexList.Shuffle();
    }

    private void FindFlower()
    {
        if (_flower == null)
            _flower = FindObjectOfType<Flower>();
    }

    public void OnDisable()
    {
        _indexList.Clear();
    }
}
