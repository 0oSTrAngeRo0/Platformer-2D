using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.PlayerControl;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class DashCDBar : MonoBehaviour
    {
        [SerializeField] private Paramaters Paramaters;
        [SerializeField] private DashState DashState;

        [SerializeField, ReadOnly] private float CoolTime;
        [SerializeField, ReadOnly] private float RestTime;

        [SerializeField, ReadOnly] private TextMeshProUGUI Text;
        [SerializeField, ReadOnly] private Slider Slider;

        private void Start()
        {
            Text = transform.Find("Value").GetComponent<TextMeshProUGUI>();
            Slider = transform.Find("Slider").GetComponent<Slider>();
            CoolTime = DashState._CoolTime;
        }
        private void Update()
        {
            RestTime = CoolTime - (Paramaters.DashCoolBuffer<0?0:Paramaters.DashCoolBuffer);
            Text.text = Paramaters.DashCoolBuffer<0 ? "" : string.Format("{0:F}", RestTime);
            Slider.value = RestTime / CoolTime;
        }
    }
}
