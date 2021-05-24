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
<<<<<<< HEAD
            ""name"": ""Player"",
            ""id"": ""923268ab-696d-45cd-bebf-942f5d0b60a4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""54c44e94-f32c-4711-9138-888607ef8468"",
                    ""expectedControlType"": ""Vector2"",
=======
            ""name"": ""Gun"",
            ""id"": ""bdecd6fd-5310-4f7d-8b6b-ba5fda45d5a3"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""716dd6ec-16e8-48fe-ae65-1c0dd702a1f2"",
                    ""expectedControlType"": ""Button"",
>>>>>>> Test-branch
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
<<<<<<< HEAD
                    ""name"": ""WASD"",
                    ""id"": ""d729f558-d3ec-49f0-8558-ce2341f8dec6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad919674-3542-4556-90ca-8f529fb776a2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e75fbf18-284f-4f9d-a0e4-f8eb77f8bedc"",
                    ""path"": """",
=======
                    ""name"": """",
                    ""id"": ""40a0a78f-84f5-4d72-8eab-6b9b921b95a8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""f96605ab-f3ca-4e22-8aac-cd3081b669da"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d9194431-0cdd-49b3-b356-c2c8c1be0040"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""UseTeleporter"",
                    ""type"": ""Button"",
                    ""id"": ""9235cda0-dc7d-4eeb-bed9-7a2b4a00a0d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9f01ae40-17d5-4ba0-8d09-9903e4e53f94"",
                    ""path"": ""2DVector"",
>>>>>>> Test-branch
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
<<<<<<< HEAD
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6120a521-f78b-4541-bd38-b8df09423bea"",
=======
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6f9a6947-cafb-4f49-97a5-60804c7b5f7d"",
>>>>>>> Test-branch
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
<<<<<<< HEAD
                    ""id"": ""ee436c10-117c-41ef-80bb-c2ff11f17ac3"",
=======
                    ""id"": ""56262589-1f5e-462f-a62a-9a9e151bdb2e"",
>>>>>>> Test-branch
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
<<<<<<< HEAD
=======
                },
                {
                    ""name"": """",
                    ""id"": ""99cbe3d8-fad8-4e9e-ad3b-7973e904b170"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseTeleporter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
>>>>>>> Test-branch
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
<<<<<<< HEAD
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
=======
        // Gun
        m_Gun = asset.FindActionMap("Gun", throwIfNotFound: true);
        m_Gun_Shoot = m_Gun.FindAction("Shoot", throwIfNotFound: true);
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_UseTeleporter = m_Player.FindAction("UseTeleporter", throwIfNotFound: true);
>>>>>>> Test-branch
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

<<<<<<< HEAD
=======
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

>>>>>>> Test-branch
    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
<<<<<<< HEAD
=======
    private readonly InputAction m_Player_UseTeleporter;
>>>>>>> Test-branch
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
<<<<<<< HEAD
=======
        public InputAction @UseTeleporter => m_Wrapper.m_Player_UseTeleporter;
>>>>>>> Test-branch
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
<<<<<<< HEAD
=======
                @UseTeleporter.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseTeleporter;
                @UseTeleporter.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseTeleporter;
                @UseTeleporter.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseTeleporter;
>>>>>>> Test-branch
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
<<<<<<< HEAD
=======
                @UseTeleporter.started += instance.OnUseTeleporter;
                @UseTeleporter.performed += instance.OnUseTeleporter;
                @UseTeleporter.canceled += instance.OnUseTeleporter;
>>>>>>> Test-branch
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
<<<<<<< HEAD
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
=======
    public interface IGunActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnUseTeleporter(InputAction.CallbackContext context);
>>>>>>> Test-branch
    }
}
