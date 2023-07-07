//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player 1/Player1Input.inputactions
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

public partial class @Player1Inputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player1Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player1Input"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""fbbd1305-c1d9-475d-8764-cb862d937505"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""20d16e86-ab89-4878-ba93-9efd13a44fd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""fcfa9e72-2151-4429-985d-78dce8b1ce2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""29f35f3d-5695-4d52-93d4-e29e0f123b9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df282258-4739-430a-8a3c-9510b0c3c22c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a639720-05fd-4a71-86dd-3de38452d101"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""93be2eb7-fa5c-4a08-b3bd-9f4128acd2c1"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""98c97114-0215-4616-8ff1-5479d3e6619c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""5518f427-5e17-4446-96aa-08aa675c66fc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""9950b742-6e3b-4da4-8989-6bec08d5dcc4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""ddf8562b-10c8-4baa-a725-72d02643c240"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Ability"",
            ""id"": ""2f2d6c08-2a5e-48d6-be85-e45ed975605d"",
            ""actions"": [
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""bc174b82-6431-4431-bde1-a0d40387bb34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseAbility"",
                    ""type"": ""Button"",
                    ""id"": ""fd2fc1ce-837e-4dd8-ab58-c1f7008cc46d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CycleAbility"",
                    ""type"": ""Value"",
                    ""id"": ""4509035c-6431-4c58-84da-00203da17613"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3079d1b6-f004-4565-915a-de973333a51d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15fc38c7-61da-49c5-a2b1-8528977c2e98"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e0a04ad9-2a64-4748-9e9c-357dd98ca4d3"",
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
                    ""id"": ""d88ab66b-da44-4eb6-a7d6-024deaa19c87"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9eb1f95-4d89-4d02-ac85-44f858ae7fb3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Death"",
            ""id"": ""9cc37134-11ea-49a6-889f-cb4007bb85e9"",
            ""actions"": [
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""8631c1fc-58a4-4509-befd-db4689dc622c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""094eeef1-ae45-475b-aa7e-8610de1bd77d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        // Death
        m_Death = asset.FindActionMap("Death", throwIfNotFound: true);
        m_Death_Reset = m_Death.FindAction("Reset", throwIfNotFound: true);
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
        private @Player1Inputs m_Wrapper;
        public PlayerMovementActions(@Player1Inputs wrapper) { m_Wrapper = wrapper; }
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
        private @Player1Inputs m_Wrapper;
        public AbilityActions(@Player1Inputs wrapper) { m_Wrapper = wrapper; }
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

    // Death
    private readonly InputActionMap m_Death;
    private IDeathActions m_DeathActionsCallbackInterface;
    private readonly InputAction m_Death_Reset;
    public struct DeathActions
    {
        private @Player1Inputs m_Wrapper;
        public DeathActions(@Player1Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Reset => m_Wrapper.m_Death_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Death; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DeathActions set) { return set.Get(); }
        public void SetCallbacks(IDeathActions instance)
        {
            if (m_Wrapper.m_DeathActionsCallbackInterface != null)
            {
                @Reset.started -= m_Wrapper.m_DeathActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_DeathActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_DeathActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_DeathActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public DeathActions @Death => new DeathActions(this);
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
    public interface IDeathActions
    {
        void OnReset(InputAction.CallbackContext context);
    }
}
