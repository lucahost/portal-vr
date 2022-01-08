using UnityEngine;

namespace Assets.Scripts
{
    public class VRAnimatorController : MonoBehaviour
    {
        public float speedThreshold = 0.1f;
        [Range(0, 1)]
        public float smoothing = 0.2f;

        private Animator _animator;

        private Vector3 _previousPos;

        private VRRig _vrRig;
        private static readonly int DirectionX = Animator.StringToHash("directionX");
        private static readonly int DirectionY = Animator.StringToHash("directionY");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _vrRig = GetComponent<VRRig>();
            _previousPos = _vrRig.head.vrTarget.position;
        }

        // Update is called once per frame
        private void Update()
        {
            // Compute the speed
            var position = _vrRig.head.vrTarget.position;
            var headSetSpeed = (position - _previousPos) / Time.deltaTime;
            headSetSpeed.y = 0;

            // Local Speed
            var headSetLocalSpeed = transform.InverseTransformDirection(headSetSpeed);
            _previousPos = position;

            // Set animator values
            var previousDirectionX = _animator.GetFloat(DirectionX);
            var previousDirectionY = _animator.GetFloat(DirectionY);
            var isMoving = headSetLocalSpeed.magnitude > speedThreshold;
            //print($"IsMoving: {isMoving}. magnitude: {headSetLocalSpeed.magnitude}");
            _animator.SetBool(IsMoving, isMoving);
            _animator.SetFloat(DirectionX, Mathf.Lerp(previousDirectionX, Mathf.Clamp(headSetLocalSpeed.x, -1 , 1), smoothing));
            _animator.SetFloat(DirectionY, Mathf.Lerp(previousDirectionY, Mathf.Clamp(headSetLocalSpeed.z, -1 , 1), smoothing));

        
        }
    }
}