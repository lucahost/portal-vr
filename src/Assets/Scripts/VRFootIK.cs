using UnityEngine;

namespace Assets.Scripts
{
    public class VRFootIK : MonoBehaviour
    {
        private Animator _animator;
        [Range(0,1)]
        public float rightFootPosWeight = 1;
        [Range(0,1)]
        public float rightFootRotWeight = 1;
        [Range(0,1)]
        public float leftFootPosWeight = 1;
        [Range(0,1)]
        public float leftFootRotWeight = 1;

        public Vector3 footOffset;

        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void OnAnimatorIK(int layerIndex)
        {
            var rightFootPos = _animator.GetIKPosition(AvatarIKGoal.RightFoot);

            var hasHit = Physics.Raycast(rightFootPos + Vector3.up, Vector3.down, out var hit);
            if (hasHit)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootPosWeight);
                _animator.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + footOffset);

                var rightFootRotation =
                    Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);

                _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootRotWeight);
                _animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,0);
            }

            var leftFootPos = _animator.GetIKPosition(AvatarIKGoal.LeftFoot);

            hasHit = Physics.Raycast(leftFootPos + Vector3.up, Vector3.down, out hit);
            if (hasHit)
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootPosWeight);
                _animator.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + footOffset);

                var leftFootRotation =
                    Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);

                _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootRotWeight);
                _animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,0);
            }
        }
    }
}