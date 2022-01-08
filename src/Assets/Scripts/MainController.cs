using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

namespace Assets.Scripts
{
    internal class MainController : MonoBehaviour
    {
        static MainController _sInstance;
        public static MainController Instance => _sInstance;

        public XROrigin Rig => _mRig;

        [Header("Setup")]
        public bool disableSetupForDebug;
        public Transform startingPosition;
        public GameObject teleporterParent;

        [Header("Reference")]
        public XRRayInteractor rightTeleportInteractor;
        public XRRayInteractor leftTeleportInteractor;

        public XRDirectInteractor rightDirectInteractor;
        public XRDirectInteractor leftDirectInteractor;

        public MagicTractorBeam rightTractorBeam;
        public MagicTractorBeam leftTractorBeam;

        XROrigin _mRig;

        InputDevice _mLeftInputDevice;
        InputDevice _mRightInputDevice;

        XRInteractorLineVisual _mRightLineVisual;
        XRInteractorLineVisual _mLeftLineVisual;

        HandPrefab _mRightHandPrefab;
        HandPrefab _mLeftHandPrefab;

        XRReleaseController _mRightController;
        XRReleaseController _mLeftController;

        bool _mPreviousRightClicked;
        bool _mPreviousLeftClicked;

        bool _mLastFrameRightEnable;
        bool _mLastFrameLeftEnable;

        InteractionLayerMask _mOriginalRightMask;
        InteractionLayerMask _mOriginalLeftMask;

        private static readonly int Pointing = Animator.StringToHash("Pointing");

        void Awake()
        {
            _sInstance = this;
            _mRig = GetComponent<XROrigin>();

        }

        void OnEnable()
        {
            InputDevices.deviceConnected += RegisterDevices;
        }

        void OnDisable()
        {
            InputDevices.deviceConnected -= RegisterDevices;
        }
       
        void RegisterDevices(InputDevice connectedDevice)
        {
            if (connectedDevice.isValid)
            {
                if ((connectedDevice.characteristics & InputDeviceCharacteristics.HeldInHand) == InputDeviceCharacteristics.HeldInHand)
                {
                    if ((connectedDevice.characteristics & InputDeviceCharacteristics.Left) == InputDeviceCharacteristics.Left)
                    {
                        _mLeftInputDevice = connectedDevice;
                    }
                    else if ((connectedDevice.characteristics & InputDeviceCharacteristics.Right) == InputDeviceCharacteristics.Right)
                    {
                        _mRightInputDevice = connectedDevice;
                    }
                }
            }
        }

        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
                Application.Quit();
        }
    }

}
