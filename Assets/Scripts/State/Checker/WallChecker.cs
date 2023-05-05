using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.PlayerControl;

public class WallChecker : MonoBehaviour
{
    private Paramaters _Patamaters;
    [SerializeField] private bool IsRightSideWall;
    [SerializeField] private LayerMask ColliderMask;

    #if UNITY_EDITOR
    [SerializeField, ReadOnly] private bool isWall;
    #endif
    
    void Start()
    {
        _Patamaters = GetComponentInParent<PlayerController>()._Paramaters;
    }

    #if UNITY_EDITOR
    private void Update()
    {
        isWall = _Patamaters.IsWall;
    }
    #endif
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1<<collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsWall = true;
            _Patamaters.IsRightSideWall = IsRightSideWall;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if((1<<collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsWall = false;
        }
    }
}
