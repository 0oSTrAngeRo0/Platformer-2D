using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Enviroment.Platform
{
    public class BrokenPlatform : MonoBehaviour
    {
        private StateBase _CurrentState;
        private TextMeshPro _Text;
        private Collider2D _Collider;

        private ShakeState _ShakeState;
        private FractureState _FractureState;
        private ReadyState _ReadyState;
        private RestoreState _RestoreState;

        [Header("Config")]
        [SerializeField] private float _ShakeTime;
        [SerializeField] private float _RestoreTime;
        [SerializeField] public LayerMask CheckerMask;
        [SerializeField] private List<GameObject> HideObjects;

        [Header("Information")]
        [SerializeField, ReadOnly] private bool isShake;
        public bool IsShake
        {
            get { return isShake; }
            set
            {
                if(isShake != value)
                {
                    isShake = value;
                }
            }
        }

        void Start()
        {
            _Collider = GetComponent<Collider2D>();
            _Text = transform.Find("Debug Information").transform.Find("Text").GetComponent<TextMeshPro>();
            _ShakeState = new(this);
            _ReadyState = new(this);
            _FractureState = new(this);
            _RestoreState = new(this);
            SwitchState(_ReadyState);
        }
        void Update()
        {
            _CurrentState.Update();
            _Text.text = _CurrentState.DebugInformation();
        }
        private void SwitchState(StateBase state)
        {
            _CurrentState = state;
            state.Enter();
        }
        private void SetChildActive(bool active)
        {
            _Collider.enabled = active;
            for (int i = 0; i < HideObjects.Count; i++)
            {
                HideObjects[i].SetActive(active);
            }
        }

        private class StateBase
        {
            protected BrokenPlatform _Father;
            public StateBase(BrokenPlatform father)
            {
                _Father = father;
            }
            public virtual void Enter() { }
            public virtual void Update() { }
            public virtual string DebugInformation() { return ""; }
        }
        private class ShakeState : StateBase
        {
            private float _ShakeBuffer;
            public ShakeState(BrokenPlatform father):base(father) { }
            public override void Enter()
            {
                _ShakeBuffer = _Father._ShakeTime;
            }
            public override void Update()
            {
                if (_ShakeBuffer > 0)
                {
                    _ShakeBuffer -= Time.deltaTime;
                }
                else
                {
                    _Father.SwitchState(_Father._FractureState);
                }
            }
            public override string DebugInformation()
            {
                return string.Format("Shake: {0:F}", _ShakeBuffer);
            }
        }
        private class FractureState : StateBase
        {
            public FractureState(BrokenPlatform father):base(father) { }
            public override void Enter()
            {
                _Father.SetChildActive(false);
                _Father.SwitchState(_Father._RestoreState);
            }
            public override string DebugInformation()
            {
                return "Fracture";
            }
        }
        private class ReadyState : StateBase
        {
            public ReadyState(BrokenPlatform father) : base(father) { }
            public override void Enter()
            {
                _Father.IsShake = false;
            }
            public override void Update()
            {
                if (_Father.IsShake)
                {
                    _Father.SwitchState(_Father._ShakeState);
                }
            }
            public override string DebugInformation()
            {
                return "Ready";
            }
        }
        private class RestoreState : StateBase
        {
            private float _RestoreBuffer;
            public RestoreState(BrokenPlatform father) : base(father) { }
            public override void Enter()
            {
                _RestoreBuffer = _Father._RestoreTime;
            }
            public override void Update()
            {
                if (_RestoreBuffer > 0)
                {
                    _RestoreBuffer -= Time.deltaTime;
                }
                else
                {
                    _Father.SetChildActive(true);
                    _Father.SwitchState(_Father._ReadyState);
                }
            }
            public override string DebugInformation()
            {
                return string.Format("Restore: {0:F}", _RestoreBuffer);
            }
        }
    }
}
