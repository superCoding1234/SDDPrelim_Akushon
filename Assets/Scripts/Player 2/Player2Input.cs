//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player 2/Player2Input.inputactions
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

public partial class @Player2Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player2Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player2Input"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""5a3c6ff6-e4c2-4548-b9a3-109f5412015c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1c049b95-fbd5-4a93-892b-3a5465449f95"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""8ce80e0a-ad29-4b2e-9514-f46cf24b501e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""aaca07d3-531b-4d98-8856-8fcbaa33e089"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""48187813-cc68-4fb1-b3ee-9eb110791673"",
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
                    ""id"": ""dfe9d5e2-8f05-4435-b10b-ed2fe12eabd6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50b4bd17-378d-4578-bd37-0e345f714f88"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc67575f-ac2a-4357-932b-8b93b00e7430"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""572cc562-9fbc-4599-a762-900abac972b3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b84712a-561d-4526-9ff9-a3bf89c5c9f0"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da41dc8b-40d5-4756-8a64-f7242a16eaf2"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ability"",
            ""id"": ""f2c66b71-0cba-443d-af8c-ae9212d3ff19"",
            ""actions"": [
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""764ae5a8-0b83-4065-aa9a-fec937271c24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseAbility"",
                    ""type"": ""Button"",
                    ""id"": ""fe22165c-da63-4817-a725-4a325dc5ecff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CycleAbility"",
                    ""type"": ""Value"",
                    ""id"": ""65217422-56c4-4842-9137-6d64d8631b69"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a355f512-5037-45ec-bfee-a8b0a8aac763"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b091e96-b567-42be-85ff-bd9da5a0314a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""cf2e4132-1b42-4179-8f4d-de3cab346cac"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAbility"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c12c48de-bbca-4dd3-9924-4a02e2925456"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""39abbd36-4a4c-4733-b71e-31c598c1101b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_Dash = m_PlayerMovement.FindAction("Dash", throwIfNotFound: true);
        m_PlayerMovement_Ability = m_PlayerMovement.FindAction("Ability", throwIfNotFound: true);
        // Ability
        m_Ability = asset.FindActionMap("Ability", throwIfNotFound: true);
        m_Ability_Ability = m_Ability.FindAction("Ability", throwIfNotFound: true);
        m_Ability_UseAbility = m_Ability.FindAction("UseAbility", throwIfNotFound: true);
        m_Ability_CycleAbility = m_Ability.FindAction("CycleAbility", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_Dash;
    private readonly InputAction m_PlayerMovement_Ability;
    public struct PlayerMovementActions
    {
        private @Player2Inputs m_Wrapper;
        public PlayerMovementActions(@Player2Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Dash => m_Wrapper.m_PlayerMovement_Dash;
        public InputAction @Ability => m_Wrapper.m_PlayerMovement_Ability;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Dash.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnDash;
                @Ability.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAbility;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Ability
    private readonly InputActionMap m_Ability;
    private IAbilityActions m_AbilityActionsCallbackInterface;
    private readonly InputAction m_Ability_Ability;
    private readonly InputAction m_Ability_UseAbility;
    private readonly InputAction m_Ability_CycleAbility;
    public struct AbilityActions
    {
        private @Player2Inputs m_Wrapper;
        public AbilityActions(@Player2Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability => m_Wrapper.m_Ability_Ability;
        public InputAction @UseAbility => m_Wrapper.m_Ability_UseAbility;
        public InputAction @CycleAbility => m_Wrapper.m_Ability_CycleAbility;
        public InputActionMap Get() { return m_Wrapper.m_Ability; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilityActions set) { return set.Get(); }
        public void SetCallbacks(IAbilityActions instance)
        {
            if (m_Wrapper.m_AbilityActionsCallbackInterface != null)
            {
                @Ability.started -= m_Wrapper.m_AbilityActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_AbilityActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_AbilityActionsCallbackInterface.OnAbility;
                @UseAbility.started -= m_Wrapper.m_AbilityActionsCallbackInterface.OnUseAbility;
                @UseAbility.performed -= m_Wrapper.m_AbilityActionsCallbackInterface.OnUseAbility;
                @UseAbility.canceled -= m_Wrapper.m_AbilityActionsCallbackInterface.OnUseAbility;
                @CycleAbility.started -= m_Wrapper.m_AbilityActionsCallbackInterface.OnCycleAbility;
                @CycleAbility.performed -= m_Wrapper.m_AbilityActionsCallbackInterface.OnCycleAbility;
                @CycleAbility.canceled -= m_Wrapper.m_AbilityActionsCallbackInterface.OnCycleAbility;
            }
            m_Wrapper.m_AbilityActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
                @UseAbility.started += instance.OnUseAbility;
                @UseAbility.performed += instance.OnUseAbility;
                @UseAbility.canceled += instance.OnUseAbility;
                @CycleAbility.started += instance.OnCycleAbility;
                @CycleAbility.performed += instance.OnCycleAbility;
                @CycleAbility.canceled += instance.OnCycleAbility;
            }
        }
    }
    public AbilityActions @Ability => new AbilityActions(this);
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
    }
    public interface IAbilityActions
    {
        void OnAbility(InputAction.CallbackContext context);
        void OnUseAbility(InputAction.CallbackContext context);
        void OnCycleAbility(InputAction.CallbackContext context);
    }
}