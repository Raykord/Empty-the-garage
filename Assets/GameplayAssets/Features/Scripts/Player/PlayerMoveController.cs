using UnityEngine;



namespace EmptyTheGarage.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField, Min(1f)]
        protected float speed = 5f;
        [SerializeField]
        protected Transform cameraTransform = default;

        protected InputSystem inputSystem = default;
        protected Rigidbody rigidbody = default;
        protected Vector3 direction = Vector3.zero;
        protected Vector2 input = Vector2.zero;
        protected float verticalCameraVector = 0f;
        protected float horizontalCameraVector = 0f;

        protected virtual void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            inputSystem = new InputSystem();
            inputSystem.Enable();
        }

        protected virtual void Start() => rigidbody = GetComponent<Rigidbody>();

        protected virtual void Update() => Move();

        protected virtual void LateUpdate() => transform.eulerAngles = new Vector3( transform.eulerAngles.x, cameraTransform.transform.eulerAngles.y, 0f);

        protected virtual void Move()
        {
            input = inputSystem.GameplayPC.Movement.ReadValue<Vector2>();
            direction = new Vector3(input.x, 0, input.y);

            rigidbody.MovePosition(transform.position + transform.TransformDirection(direction) * speed * Time.deltaTime);
        }    
    }
}

