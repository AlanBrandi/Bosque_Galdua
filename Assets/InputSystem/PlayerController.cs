// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""397f9413-c40f-4c17-a257-aa298200c3d2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4df68aae-f640-4144-a70b-a064206d6cfc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""86e2f7bd-d834-461a-a407-93f8834f8f02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""00b86959-1e3d-452f-8a45-bb4f13441d88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_Shift"",
                    ""type"": ""Button"",
                    ""id"": ""5a2d6ffd-ab02-4577-b4a8-663d41433a20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_H"",
                    ""type"": ""Button"",
                    ""id"": ""a6e69afe-6de0-4553-97a8-1a6c84b9487b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_D"",
                    ""type"": ""Button"",
                    ""id"": ""194a3dbc-a216-4cc8-b6d9-3fe890b6dbe3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_K"",
                    ""type"": ""Button"",
                    ""id"": ""a1a7673d-8df3-4fa4-aa7b-90ccfd42ffa3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_Z"",
                    ""type"": ""Button"",
                    ""id"": ""87572223-068f-45e7-805e-75a476f14f25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_F3"",
                    ""type"": ""Button"",
                    ""id"": ""3f8af632-fe27-4c36-9098-0648ef532208"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_Mouse3"",
                    ""type"": ""Button"",
                    ""id"": ""b95bb6e8-ff53-4f90-a88f-9d8d23fdb990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""b66717f0-fcc3-41dd-9388-789dbe1df0c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug_E"",
                    ""type"": ""Button"",
                    ""id"": ""605ac094-50e4-4620-a548-d6009a8fbea9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d8f1a95e-08ba-4211-a809-05c9f9d35938"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""331e04ae-f522-41b3-994f-69f49b2fdab0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""84d08f23-c484-4c18-8c84-98b9ee0346d5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dbd8e630-21ee-4cfd-9a67-8d617d204b24"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6855c6fd-b032-4e11-b99e-b33c8348cc40"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Analog"",
                    ""id"": ""c8ef0c20-41cd-4216-a50c-170cdff4ee5b"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a8e3799-7454-4cfe-9b07-11b836de0abd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5bdcd16d-97c0-41cb-a0c9-4c7b6b3c34c0"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0ef4511c-b5f0-4069-ba69-360370537b35"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""83bd2bd5-99c8-4785-a450-bd45616ea418"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7eac299c-7089-4c5f-8b89-035c90284779"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a652d007-eab1-43b3-aee4-548921a6d3bf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3919703-21ef-4898-b77e-720191943e2c"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d85633c8-67e1-4ca6-86da-d4467b26e87e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c50e7e37-523e-421e-884b-f9a7e310dcc1"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_Shift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40c8167c-a43a-40ac-9939-27078f962e2f"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_H"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44502d33-0386-4644-91d4-e7fea0f61d19"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""178f9a3f-8054-4f70-8182-c989ec3be493"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_K"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34b3faf1-9d27-4984-b4e9-aa60ccedd88b"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_F3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a99f9620-a190-45f5-af56-07f006e61278"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_Mouse3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c84b47c-18d8-4f98-a312-355b35c1e9ab"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46c97ae1-5b66-48e3-93fd-14176936829b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48767330-08cf-4293-b432-885f60f31a36"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug_E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dbce2a6-a85d-416a-b552-b120f3f86182"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Debug_Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        }
    ]
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Jump = m_InGame.FindAction("Jump", throwIfNotFound: true);
        m_InGame_Attack = m_InGame.FindAction("Attack", throwIfNotFound: true);
        m_InGame_Debug_Shift = m_InGame.FindAction("Debug_Shift", throwIfNotFound: true);
        m_InGame_Debug_H = m_InGame.FindAction("Debug_H", throwIfNotFound: true);
        m_InGame_Debug_D = m_InGame.FindAction("Debug_D", throwIfNotFound: true);
        m_InGame_Debug_K = m_InGame.FindAction("Debug_K", throwIfNotFound: true);
        m_InGame_Debug_Z = m_InGame.FindAction("Debug_Z", throwIfNotFound: true);
        m_InGame_Debug_F3 = m_InGame.FindAction("Debug_F3", throwIfNotFound: true);
        m_InGame_Debug_Mouse3 = m_InGame.FindAction("Debug_Mouse3", throwIfNotFound: true);
        m_InGame_Escape = m_InGame.FindAction("Escape", throwIfNotFound: true);
        m_InGame_Debug_E = m_InGame.FindAction("Debug_E", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Jump;
    private readonly InputAction m_InGame_Attack;
    private readonly InputAction m_InGame_Debug_Shift;
    private readonly InputAction m_InGame_Debug_H;
    private readonly InputAction m_InGame_Debug_D;
    private readonly InputAction m_InGame_Debug_K;
    private readonly InputAction m_InGame_Debug_Z;
    private readonly InputAction m_InGame_Debug_F3;
    private readonly InputAction m_InGame_Debug_Mouse3;
    private readonly InputAction m_InGame_Escape;
    private readonly InputAction m_InGame_Debug_E;
    public struct InGameActions
    {
        private @PlayerController m_Wrapper;
        public InGameActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Jump => m_Wrapper.m_InGame_Jump;
        public InputAction @Attack => m_Wrapper.m_InGame_Attack;
        public InputAction @Debug_Shift => m_Wrapper.m_InGame_Debug_Shift;
        public InputAction @Debug_H => m_Wrapper.m_InGame_Debug_H;
        public InputAction @Debug_D => m_Wrapper.m_InGame_Debug_D;
        public InputAction @Debug_K => m_Wrapper.m_InGame_Debug_K;
        public InputAction @Debug_Z => m_Wrapper.m_InGame_Debug_Z;
        public InputAction @Debug_F3 => m_Wrapper.m_InGame_Debug_F3;
        public InputAction @Debug_Mouse3 => m_Wrapper.m_InGame_Debug_Mouse3;
        public InputAction @Escape => m_Wrapper.m_InGame_Escape;
        public InputAction @Debug_E => m_Wrapper.m_InGame_Debug_E;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttack;
                @Debug_Shift.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Shift;
                @Debug_Shift.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Shift;
                @Debug_Shift.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Shift;
                @Debug_H.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_H;
                @Debug_H.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_H;
                @Debug_H.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_H;
                @Debug_D.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_D;
                @Debug_D.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_D;
                @Debug_D.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_D;
                @Debug_K.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_K;
                @Debug_K.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_K;
                @Debug_K.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_K;
                @Debug_Z.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Z;
                @Debug_Z.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Z;
                @Debug_Z.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Z;
                @Debug_F3.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_F3;
                @Debug_F3.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_F3;
                @Debug_F3.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_F3;
                @Debug_Mouse3.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Mouse3;
                @Debug_Mouse3.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Mouse3;
                @Debug_Mouse3.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_Mouse3;
                @Escape.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnEscape;
                @Debug_E.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_E;
                @Debug_E.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_E;
                @Debug_E.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnDebug_E;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Debug_Shift.started += instance.OnDebug_Shift;
                @Debug_Shift.performed += instance.OnDebug_Shift;
                @Debug_Shift.canceled += instance.OnDebug_Shift;
                @Debug_H.started += instance.OnDebug_H;
                @Debug_H.performed += instance.OnDebug_H;
                @Debug_H.canceled += instance.OnDebug_H;
                @Debug_D.started += instance.OnDebug_D;
                @Debug_D.performed += instance.OnDebug_D;
                @Debug_D.canceled += instance.OnDebug_D;
                @Debug_K.started += instance.OnDebug_K;
                @Debug_K.performed += instance.OnDebug_K;
                @Debug_K.canceled += instance.OnDebug_K;
                @Debug_Z.started += instance.OnDebug_Z;
                @Debug_Z.performed += instance.OnDebug_Z;
                @Debug_Z.canceled += instance.OnDebug_Z;
                @Debug_F3.started += instance.OnDebug_F3;
                @Debug_F3.performed += instance.OnDebug_F3;
                @Debug_F3.canceled += instance.OnDebug_F3;
                @Debug_Mouse3.started += instance.OnDebug_Mouse3;
                @Debug_Mouse3.performed += instance.OnDebug_Mouse3;
                @Debug_Mouse3.canceled += instance.OnDebug_Mouse3;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Debug_E.started += instance.OnDebug_E;
                @Debug_E.performed += instance.OnDebug_E;
                @Debug_E.canceled += instance.OnDebug_E;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDebug_Shift(InputAction.CallbackContext context);
        void OnDebug_H(InputAction.CallbackContext context);
        void OnDebug_D(InputAction.CallbackContext context);
        void OnDebug_K(InputAction.CallbackContext context);
        void OnDebug_Z(InputAction.CallbackContext context);
        void OnDebug_F3(InputAction.CallbackContext context);
        void OnDebug_Mouse3(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnDebug_E(InputAction.CallbackContext context);
    }
}
