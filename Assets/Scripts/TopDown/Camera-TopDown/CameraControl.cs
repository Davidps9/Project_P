//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/TopDown/Camera-TopDown/CameraControl.inputactions
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

public partial class @CameraControl : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraControl"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""c1d24a8b-c94d-4611-8b52-03274190735d"",
            ""actions"": [
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Button"",
                    ""id"": ""0e461abb-2bee-4901-bad8-2b694a37d913"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDelta"",
                    ""type"": ""Value"",
                    ""id"": ""9246135f-97fd-43a0-9861-0b5637e93699"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseScroll"",
                    ""type"": ""Value"",
                    ""id"": ""38b81452-b713-41bb-9e9d-273a0ee78ab3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f5c1cdfb-757c-43a9-9a43-71285561eddb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchZoom"",
                    ""type"": ""Button"",
                    ""id"": ""2a2141bf-6c00-4ef8-acb5-89b65b60daba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition0"",
                    ""type"": ""Value"",
                    ""id"": ""1532e9a5-fef0-477e-82fa-a3f98d5bd55a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchPosition1"",
                    ""type"": ""Value"",
                    ""id"": ""6cc6c7d3-2a50-4410-884b-d999058c3fdd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PointerPosition"",
                    ""type"": ""Value"",
                    ""id"": ""80653d9d-7b35-437c-a04f-d1027250b379"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f5d15ba-62eb-4277-bc76-553eb45cb3ef"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d385d50-a635-4a63-9667-77c640e51396"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c224794-8c20-4ad2-bbf5-3b04b8354ef4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999b4096-b0e8-46f4-8ae6-5ff39d2d4b19"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54e3093f-10ec-4b25-a99f-49555c6a0753"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab230f0d-570f-4a58-8b26-c8f2b940ea41"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""c6dabb77-3010-4b95-9931-3eaaafd6998d"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5419beff-0d0b-4640-af87-a986ce87c2fc"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""c0e1a046-ef6a-4af0-b972-74cc9e042440"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c585aac6-7d99-46fa-9fc2-7ff9ceaac107"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c93ce867-b698-4912-8f55-bc1af72ace84"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""435b729c-ccd8-4259-a94e-c49b6ddea761"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62397608-67b3-44d9-b762-b8499c4babf0"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_CameraMovement = m_Main.FindAction("CameraMovement", throwIfNotFound: true);
        m_Main_MoveDelta = m_Main.FindAction("MoveDelta", throwIfNotFound: true);
        m_Main_MouseScroll = m_Main.FindAction("MouseScroll", throwIfNotFound: true);
        m_Main_MousePosition = m_Main.FindAction("MousePosition", throwIfNotFound: true);
        m_Main_TouchZoom = m_Main.FindAction("TouchZoom", throwIfNotFound: true);
        m_Main_TouchPosition0 = m_Main.FindAction("TouchPosition0", throwIfNotFound: true);
        m_Main_TouchPosition1 = m_Main.FindAction("TouchPosition1", throwIfNotFound: true);
        m_Main_PointerPosition = m_Main.FindAction("PointerPosition", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_CameraMovement;
    private readonly InputAction m_Main_MoveDelta;
    private readonly InputAction m_Main_MouseScroll;
    private readonly InputAction m_Main_MousePosition;
    private readonly InputAction m_Main_TouchZoom;
    private readonly InputAction m_Main_TouchPosition0;
    private readonly InputAction m_Main_TouchPosition1;
    private readonly InputAction m_Main_PointerPosition;
    public struct MainActions
    {
        private @CameraControl m_Wrapper;
        public MainActions(@CameraControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraMovement => m_Wrapper.m_Main_CameraMovement;
        public InputAction @MoveDelta => m_Wrapper.m_Main_MoveDelta;
        public InputAction @MouseScroll => m_Wrapper.m_Main_MouseScroll;
        public InputAction @MousePosition => m_Wrapper.m_Main_MousePosition;
        public InputAction @TouchZoom => m_Wrapper.m_Main_TouchZoom;
        public InputAction @TouchPosition0 => m_Wrapper.m_Main_TouchPosition0;
        public InputAction @TouchPosition1 => m_Wrapper.m_Main_TouchPosition1;
        public InputAction @PointerPosition => m_Wrapper.m_Main_PointerPosition;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @CameraMovement.started -= m_Wrapper.m_MainActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnCameraMovement;
                @MoveDelta.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveDelta;
                @MoveDelta.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveDelta;
                @MoveDelta.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMoveDelta;
                @MouseScroll.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseScroll;
                @MouseScroll.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseScroll;
                @MouseScroll.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMouseScroll;
                @MousePosition.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMousePosition;
                @TouchZoom.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchZoom;
                @TouchZoom.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchZoom;
                @TouchZoom.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchZoom;
                @TouchPosition0.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition0;
                @TouchPosition0.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition0;
                @TouchPosition0.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition0;
                @TouchPosition1.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition1;
                @TouchPosition1.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition1;
                @TouchPosition1.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTouchPosition1;
                @PointerPosition.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPointerPosition;
                @PointerPosition.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPointerPosition;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @MoveDelta.started += instance.OnMoveDelta;
                @MoveDelta.performed += instance.OnMoveDelta;
                @MoveDelta.canceled += instance.OnMoveDelta;
                @MouseScroll.started += instance.OnMouseScroll;
                @MouseScroll.performed += instance.OnMouseScroll;
                @MouseScroll.canceled += instance.OnMouseScroll;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @TouchZoom.started += instance.OnTouchZoom;
                @TouchZoom.performed += instance.OnTouchZoom;
                @TouchZoom.canceled += instance.OnTouchZoom;
                @TouchPosition0.started += instance.OnTouchPosition0;
                @TouchPosition0.performed += instance.OnTouchPosition0;
                @TouchPosition0.canceled += instance.OnTouchPosition0;
                @TouchPosition1.started += instance.OnTouchPosition1;
                @TouchPosition1.performed += instance.OnTouchPosition1;
                @TouchPosition1.canceled += instance.OnTouchPosition1;
                @PointerPosition.started += instance.OnPointerPosition;
                @PointerPosition.performed += instance.OnPointerPosition;
                @PointerPosition.canceled += instance.OnPointerPosition;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnMoveDelta(InputAction.CallbackContext context);
        void OnMouseScroll(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnTouchZoom(InputAction.CallbackContext context);
        void OnTouchPosition0(InputAction.CallbackContext context);
        void OnTouchPosition1(InputAction.CallbackContext context);
        void OnPointerPosition(InputAction.CallbackContext context);
    }
}
