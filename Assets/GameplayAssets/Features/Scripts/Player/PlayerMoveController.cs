using UnityEngine;

namespace EmptyTheGarage.Feature.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField, Min(1f)]
        protected float speed = 5f;
        [SerializeField]
        protected Transform cameraTransform = default;

        protected Rigidbody rigidbody = default;
        protected Vector3 direction = Vector3.zero;
        protected float verticalCameraVector = 0f;
        protected float horizontalCameraVector = 0f;

        protected virtual void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        protected virtual void Start() => rigidbody = GetComponent<Rigidbody>();

        protected virtual void LateUpdate() => transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraTransform.transform.eulerAngles.y, 0f);

        public virtual void Move(Vector2 input)
        {
            direction = new Vector3(input.x, 0, input.y);

            rigidbody.velocity = transform.TransformDirection(direction) * speed * Time.fixedDeltaTime;
        }    
    }
}

