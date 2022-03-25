using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int _minPoolCapacity;
    [SerializeField] private PoolObject _poolObjectPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand;

    private List<PoolObject> _poolObjects;
    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _poolObjects = new List<PoolObject>(_minPoolCapacity);
        for (int i = 0; i < _minPoolCapacity; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool defaultSetActive = false)
    {
        var element = Instantiate(_poolObjectPrefab, _container);
        element.gameObject.SetActive(defaultSetActive);
        _poolObjects.Add(element);
        return element;
    }

    private bool TryGetElement(out PoolObject element)
    {
        foreach (var elem in _poolObjects)
        {
            if (!elem.gameObject.activeInHierarchy)
            {
                element = elem;
                elem.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    public PoolObject GetFreeElement()
    {
        if(TryGetElement(out PoolObject element))
            return element;
        if (_autoExpand)
            return CreateElement(true);
        else
            throw new Exception("Pull is over");
    }
    public PoolObject GetFreeElement(Vector3 pos)
    {
        var element = GetFreeElement();
        element.transform.position = pos;
        return element;
    }
    public PoolObject GetFreeElement(Vector3 pos, Quaternion rotation)
    {
        var element = GetFreeElement(pos);
        element.transform.rotation = rotation;
        return element;
    }
}
