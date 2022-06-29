// GENERATED AUTOMATICALLY FROM 'Assets/UserController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UserController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9cd74597-5e3b-4db0-bf4d-c67866cf010b"",
            ""actions"": [
                {
                    ""name"": ""Skill00"",
                    ""type"": ""Button"",
                    ""id"": ""aaee5e95-dbb2-4a39-af2e-c2e611f2c726"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b0d887d8-1e22-484f-9f75-3f200f6083f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill01"",
                    ""type"": ""Button"",
                    ""id"": ""68fbd800-bec3-4e75-935a-00ddf33c5c84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Skill02"",
                    ""type"": ""Button"",
                    ""id"": ""31a3f979-5d0f-4759-a7bc-64015a4cf64a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill03"",
                    ""type"": ""Button"",
                    ""id"": ""7398cf85-9017-4de6-aa8e-2a2adb6eda5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ed05abb-27e2-49db-979e-4cdb02b031a4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill00"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebe37e45-90d7-49f9-b059-a86bbe953694"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8eca29a8-be95-40d2-95ee-16c57facbcba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cf2099d-0e43-42e1-8b51-16d683d4e9cf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9b3a3e4-10f3-49cd-8f76-a4b8a80f53fa"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill03"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Skill00 = m_Player.FindAction("Skill00", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Skill01 = m_Player.FindAction("Skill01", throwIfNotFound: true);
        m_Player_Skill02 = m_Player.FindAction("Skill02", throwIfNotFound: true);
        m_Player_Skill03 = m_Player.FindAction("Skill03", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Skill00;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Skill01;
    private readonly InputAction m_Player_Skill02;
    private readonly InputAction m_Player_Skill03;
    public struct PlayerActions
    {
        private @UserController m_Wrapper;
        public PlayerActions(@UserController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Skill00 => m_Wrapper.m_Player_Skill00;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Skill01 => m_Wrapper.m_Player_Skill01;
        public InputAction @Skill02 => m_Wrapper.m_Player_Skill02;
        public InputAction @Skill03 => m_Wrapper.m_Player_Skill03;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Skill00.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill00;
                @Skill00.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill00;
                @Skill00.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill00;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Skill01.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill01;
                @Skill01.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill01;
                @Skill01.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill01;
                @Skill02.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill02;
                @Skill02.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill02;
                @Skill02.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill02;
                @Skill03.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill03;
                @Skill03.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill03;
                @Skill03.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill03;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Skill00.started += instance.OnSkill00;
                @Skill00.performed += instance.OnSkill00;
                @Skill00.canceled += instance.OnSkill00;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Skill01.started += instance.OnSkill01;
                @Skill01.performed += instance.OnSkill01;
                @Skill01.canceled += instance.OnSkill01;
                @Skill02.started += instance.OnSkill02;
                @Skill02.performed += instance.OnSkill02;
                @Skill02.canceled += instance.OnSkill02;
                @Skill03.started += instance.OnSkill03;
                @Skill03.performed += instance.OnSkill03;
                @Skill03.canceled += instance.OnSkill03;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnSkill00(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSkill01(InputAction.CallbackContext context);
        void OnSkill02(InputAction.CallbackContext context);
        void OnSkill03(InputAction.CallbackContext context);
    }
}
