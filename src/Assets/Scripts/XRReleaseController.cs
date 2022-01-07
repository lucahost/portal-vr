using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Scripts
{
    public class XRReleaseController : XRController
    {
        bool _mSelected;

        bool _mActive;

        protected void LateUpdate()
        {
            XRControllerState state = currentControllerState;

            var selectState = state.selectInteractionState;

            if (_mSelected)
            {
                if (!_mActive)
                {
                    selectState.activatedThisFrame = true;
                    selectState.active = true;
                    _mActive = true;
                }
            }
            else
            {
                if (_mActive)
                {
                    selectState.deactivatedThisFrame = true;
                    selectState.active = false;
                    _mActive = false;
                }
            }

            state.selectInteractionState = selectState;
            currentControllerState = state;

            _mSelected = false;
        }

        public void Select()
        {
            _mSelected = true;
        }
    }
}