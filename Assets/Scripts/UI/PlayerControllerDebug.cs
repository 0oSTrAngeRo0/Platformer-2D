using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.PlayerControl;
using TMPro;

public class PlayerControllerDebug : MonoBehaviour
{
    [Header("Information")]
    [SerializeField, ReadOnly] private StateMachine _StateMachine;
    [SerializeField, ReadOnly] private TextMeshPro _StateNameTMP;
    [SerializeField, ReadOnly] private Material _CharactorMaterial;

    private void Start()
    {
        _StateMachine = GetComponentInParent<PlayerController>()._StateMachine;
        _StateNameTMP = transform.Find("State Name").GetComponent<TextMeshPro>();
        _CharactorMaterial = GameObject.Find("Player").transform.Find("Charactor").GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        _StateNameTMP.text = _StateMachine._CurrentState._StateName;
        _CharactorMaterial.color = _StateMachine._CurrentState._DebugColor;
    }
}
