using System;
using System.Collections;
using System.Collections.Generic;
using State.PlayerControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CrouchChargeBar : MonoBehaviour
    {
        [SerializeField] private CrouchChargeState m_CrouchChargeState;
        [SerializeField] private Paramaters m_Paramaters;
        [SerializeField, ReadOnly] private TextMeshProUGUI m_Text;
        [SerializeField, ReadOnly] private Slider m_Slider;
        [SerializeField, ReadOnly] private float m_HoldTime;
        [SerializeField, ReadOnly] private float m_HoldTimeLimitation;

        private void Start()
        {
            m_Slider = GetComponentInChildren<Slider>();
            m_Text = transform.Find("Value").GetComponentInChildren<TextMeshProUGUI>();
            m_HoldTimeLimitation = m_CrouchChargeState.HoldTimeLimitation;
        }

        private void Update()
        {
            m_HoldTime = m_CrouchChargeState.HoldTime;
            m_Text.text = string.Format("{0:F}", m_HoldTime);
            m_Slider.value = m_HoldTime / m_HoldTimeLimitation;
        }
    }
}
