//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/InputSystem/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""5fba3132-87fb-482a-9acf-e666bfed39ce"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""21bc1174-5fb6-4993-8c59-d3be66d5ec78"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveY"",
                    ""type"": ""Value"",
                    ""id"": ""53ea31a2-0f7d-41e5-b28e-17beecbbb177"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""5c8bc7f7-f76c-4ac9-b9c6-5681b95f597a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""45155b35-91a1-4b78-ab6f-4c0ed62ea2d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Held"",
                    ""type"": ""Button"",
                    ""id"": ""4d16c80a-009d-4179-9ca3-8c0f011535d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Value"",
                    ""id"": ""9657759d-61e9-408f-b337-06af42d7e06d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2,StickDeadzone"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""92dbd532-dce0-4c6a-8c8a-d0745200153b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b05f4990-e5e1-4055-8cef-feb73f88e4a5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9bbdcbf9-5c00-4a64-b3d0-fe1598ae4fe8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""459cdf20-cf14-46fc-9df3-c56181a04b3e"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""672d8ea6-b03c-48d0-8f0b-d55fd1b62f4e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23aba453-88cd-4563-9b2e-ddd86875a7b9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""416ac340-256d-4974-ad79-2daa6161777b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4ddef85-6bb6-40d5-a3e4-76497ee43b6c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e116284-5561-4122-973b-5e0b48917217"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""ef9719a9-d428-4017-93f1-828f63ad5fcd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7e9cd58b-dab7-4d97-a2d7-4ecf2c4b25fd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f4d0c692-40eb-4eca-85f9-cdf352cbd35c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0aea8579-bb5b-42c7-b419-82542eebd20f"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75e3a246-ab22-4f1d-a77f-1c1165ae142f"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoradAndMouse"",
                    ""action"": ""Held"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0954613-038a-46fd-a0e0-f32eb11de9ad"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Held"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88a7e1a7-a2de-48ea-88bd-c51be23cc8be"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""GamePad"",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyBoradAndMouse"",
            ""bindingGroup"": ""KeyBoradAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // GamePlay
            m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
            m_GamePlay_MoveX = m_GamePlay.FindAction("MoveX", throwIfNotFound: true);
            m_GamePlay_MoveY = m_GamePlay.FindAction("MoveY", throwIfNotFound: true);
            m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
            m_GamePlay_Dash = m_GamePlay.FindAction("Dash", throwIfNotFound: true);
            m_GamePlay_Held = m_GamePlay.FindAction("Held", throwIfNotFound: true);
            m_GamePlay_Grab = m_GamePlay.FindAction("Grab", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // GamePlay
        private readonly InputActionMap m_GamePlay;
        private List<IGamePlayActions> m_GamePlayActionsCallbackInterfaces = new List<IGamePlayActions>();
        private readonly InputAction m_GamePlay_MoveX;
        private readonly InputAction m_GamePlay_MoveY;
        private readonly InputAction m_GamePlay_Jump;
        private readonly InputAction m_GamePlay_Dash;
        private readonly InputAction m_GamePlay_Held;
        private readonly InputAction m_GamePlay_Grab;
        public struct GamePlayActions
        {
            private @PlayerInputActions m_Wrapper;
            public GamePlayActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveX => m_Wrapper.m_GamePlay_MoveX;
            public InputAction @MoveY => m_Wrapper.m_GamePlay_MoveY;
            public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
            public InputAction @Dash => m_Wrapper.m_GamePlay_Dash;
            public InputAction @Held => m_Wrapper.m_GamePlay_Held;
            public InputAction @Grab => m_Wrapper.m_GamePlay_Grab;
            public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
            public void AddCallbacks(IGamePlayActions instance)
            {
                if (instance == null || m_Wrapper.m_GamePlayActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GamePlayActionsCallbackInterfaces.Add(instance);
                @MoveX.started += instance.OnMoveX;
                @MoveX.performed += instance.OnMoveX;
                @MoveX.canceled += instance.OnMoveX;
                @MoveY.started += instance.OnMoveY;
                @MoveY.performed += instance.OnMoveY;
                @MoveY.canceled += instance.OnMoveY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Held.started += instance.OnHeld;
                @Held.performed += instance.OnHeld;
                @Held.canceled += instance.OnHeld;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }

            private void UnregisterCallbacks(IGamePlayActions instance)
            {
                @MoveX.started -= instance.OnMoveX;
                @MoveX.performed -= instance.OnMoveX;
                @MoveX.canceled -= instance.OnMoveX;
                @MoveY.started -= instance.OnMoveY;
                @MoveY.performed -= instance.OnMoveY;
                @MoveY.canceled -= instance.OnMoveY;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Dash.started -= instance.OnDash;
                @Dash.performed -= instance.OnDash;
                @Dash.canceled -= instance.OnDash;
                @Held.started -= instance.OnHeld;
                @Held.performed -= instance.OnHeld;
                @Held.canceled -= instance.OnHeld;
                @Grab.started -= instance.OnGrab;
                @Grab.performed -= instance.OnGrab;
                @Grab.canceled -= instance.OnGrab;
            }

            public void RemoveCallbacks(IGamePlayActions instance)
            {
                if (m_Wrapper.m_GamePlayActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGamePlayActions instance)
            {
                foreach (var item in m_Wrapper.m_GamePlayActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GamePlayActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GamePlayActions @GamePlay => new GamePlayActions(this);
        private int m_KeyBoradAndMouseSchemeIndex = -1;
        public InputControlScheme KeyBoradAndMouseScheme
        {
            get
            {
                if (m_KeyBoradAndMouseSchemeIndex == -1) m_KeyBoradAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyBoradAndMouse");
                return asset.controlSchemes[m_KeyBoradAndMouseSchemeIndex];
            }
        }
        private int m_GamePadSchemeIndex = -1;
        public InputControlScheme GamePadScheme
        {
            get
            {
                if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
                return asset.controlSchemes[m_GamePadSchemeIndex];
            }
        }
        public interface IGamePlayActions
        {
            void OnMoveX(InputAction.CallbackContext context);
            void OnMoveY(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnHeld(InputAction.CallbackContext context);
            void OnGrab(InputAction.CallbackContext context);
        }
    }
}