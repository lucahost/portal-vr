using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class VRMap
    {
        public Transform vrTarget;
        public Transform rigTarget;
        public Vector3 trackingPositionOffset;
        public Vector3 trackingRotationOffset;

        public void Map()
        {
            rigTarget.SetPositionAndRotation(
                vrTarget.TransformPoint(trackingPositionOffset), 
                vrTarget.rotation * Quaternion.Euler(trackingRotationOffset));
        }
    }

    public class VRRig : MonoBehaviour
    {
        public float turnSmoothness = 1f;
        public VRMap head;
        public VRMap leftHand;
        public VRMap rightHand;

        public Transform headConstraint;
        private Vector3 _headBodyOffset;

        // Start is called before the first frame update
        private void Start()
        {
            _headBodyOffset = transform.position - headConstraint.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            var vrRigTransform = transform;
            vrRigTransform.position = headConstraint.position + _headBodyOffset;
            transform.forward = Vector3.Lerp(vrRigTransform.forward,
                Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

            head.Map();
            leftHand.Map();
            rightHand.Map();
        }
    }
}