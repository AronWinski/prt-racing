// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""42738b89-96be-4e58-adc0-c099763d82e9"",
            ""actions"": [
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""70b7c13a-3a04-436a-b208-8381240b29b2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""86f6dac4-86b2-450b-9c83-38894d75632d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""deccelerate"",
                    ""type"": ""Value"",
                    ""id"": ""fc843faa-3236-49dc-a398-e96080e1d93e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""break"",
                    ""type"": ""Button"",
                    ""id"": ""3b94688d-783d-447f-94d7-a75e79b11ca9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6555370f-093e-4464-be45-a8037aa252fa"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df7fb838-b454-4dc2-aa37-17476b55f2aa"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""503b6c10-7648-483a-a4b8-4ed4d6aab6e4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""deccelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6979b95f-a74e-46d7-8ff8-920695411523"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.3)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""break"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Turn = m_Gameplay.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay_accelerate = m_Gameplay.FindAction("accelerate", throwIfNotFound: true);
        m_Gameplay_deccelerate = m_Gameplay.FindAction("deccelerate", throwIfNotFound: true);
        m_Gameplay_break = m_Gameplay.FindAction("break", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Turn;
    private readonly InputAction m_Gameplay_accelerate;
    private readonly InputAction m_Gameplay_deccelerate;
    private readonly InputAction m_Gameplay_break;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Turn => m_Wrapper.m_Gameplay_Turn;
        public InputAction @accelerate => m_Wrapper.m_Gameplay_accelerate;
        public InputAction @deccelerate => m_Wrapper.m_Gameplay_deccelerate;
        public InputAction @break => m_Wrapper.m_Gameplay_break;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Turn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTurn;
                @accelerate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @accelerate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @accelerate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAccelerate;
                @deccelerate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeccelerate;
                @deccelerate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeccelerate;
                @deccelerate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDeccelerate;
                @break.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
                @break.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
                @break.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBreak;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @accelerate.started += instance.OnAccelerate;
                @accelerate.performed += instance.OnAccelerate;
                @accelerate.canceled += instance.OnAccelerate;
                @deccelerate.started += instance.OnDeccelerate;
                @deccelerate.performed += instance.OnDeccelerate;
                @deccelerate.canceled += instance.OnDeccelerate;
                @break.started += instance.OnBreak;
                @break.performed += instance.OnBreak;
                @break.canceled += instance.OnBreak;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnTurn(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDeccelerate(InputAction.CallbackContext context);
        void OnBreak(InputAction.CallbackContext context);
    }
}
