// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControls.inputactions'

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
            ""name"": ""Gun"",
            ""id"": ""bdecd6fd-5310-4f7d-8b6b-ba5fda45d5a3"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""716dd6ec-16e8-48fe-ae65-1c0dd702a1f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40a0a78f-84f5-4d72-8eab-6b9b921b95a8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gun
        m_Gun = asset.FindActionMap("Gun", throwIfNotFound: true);
        m_Gun_Shoot = m_Gun.FindAction("Shoot", throwIfNotFound: true);
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

    // Gun
    private readonly InputActionMap m_Gun;
    private IGunActions m_GunActionsCallbackInterface;
    private readonly InputAction m_Gun_Shoot;
    public struct GunActions
    {
        private @PlayerControls m_Wrapper;
        public GunActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gun_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Gun; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GunActions set) { return set.Get(); }
        public void SetCallbacks(IGunActions instance)
        {
            if (m_Wrapper.m_GunActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GunActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GunActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GunActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_GunActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public GunActions @Gun => new GunActions(this);
    public interface IGunActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
