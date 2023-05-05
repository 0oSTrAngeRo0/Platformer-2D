using System;
using State.PlayerControl;
using UnityEngine;

public class TopChecker : MonoBehaviour
{
    private Paramaters _Patamaters;
    [SerializeField] private LayerMask ColliderMask;
    #if UNITY_EDITOR
    [SerializeField, ReadOnly] private bool isTopBlocked;
    #endif

    void Start()
    {
        _Patamaters = GetComponentInParent<PlayerController>()._Paramaters;
    }

    #if UNITY_EDITOR
    private void Update()
    {
        isTopBlocked = _Patamaters.IsTopBlocked;
    }
    #endif
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsTopBlocked = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & ColliderMask.value) != 0)
        {
            _Patamaters.IsTopBlocked = false;
        }
    }
}

