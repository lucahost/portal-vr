using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    internal class AlignmentTrigger : MonoBehaviour
    {
        public enum Mode
        {
            View,
            World
        }

        [System.Serializable]
        public class AxisMatch
        {
            public Mode externalAxisMode;
            public Vector3 localAxis;
            public Vector3 externalAxis;
            [Range(0.0f, 1.0f)]
            public float tolerance = 0.3f;
        }

        public AxisMatch[] requiredMatch;
        public UnityEvent onEnterAligned;
        public UnityEvent onExitAligned;

        bool _mWasAligned;

        // Update is called once per frame
        void Update()
        {
            if (MainController.Instance == null || MainController.Instance.Rig == null)
            {
                return;
            }

            var rig = MainController.Instance.Rig;

            bool allMatch = true;

            for (int i = 0; i < requiredMatch.Length && allMatch; ++i)
            {
                AxisMatch match = requiredMatch[i];
            
                Vector3 worldLocal = transform.TransformVector(match.localAxis);
                Vector3 worldExternal;


                if (match.externalAxisMode == Mode.View)
                {
                    worldExternal =  rig.Camera.transform.TransformVector(match.externalAxis);
                }
                else
                {
                    worldExternal = match.externalAxis;
                }

                float dot = Vector3.Dot(worldLocal, worldExternal);

                allMatch &= dot > 1.0f - match.tolerance;
            }

            if (allMatch)
            {
                if (!_mWasAligned)
                {
                    onEnterAligned.Invoke();
                    _mWasAligned = true;
                }
            }
            else
            {
                if (_mWasAligned)
                {
                    onExitAligned.Invoke();
                    _mWasAligned = false;
                }
            }
        }
    }
}
