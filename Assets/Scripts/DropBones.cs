using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropBones : MonoBehaviour
{
    [SerializeField] private GameObject _bone;

    private int _minBonesDrops = 2;
    private int _maxBonesDrops = 6;

    public void Create(Vector3 dropPosition)
    {
        int numbersOfDrops = Random.Range(_minBonesDrops, _maxBonesDrops + 1);

        for (int i = 0; i < numbersOfDrops; i++)
        {
            Instantiate(_bone,dropPosition, Quaternion.identity);          
        }
    }
}
