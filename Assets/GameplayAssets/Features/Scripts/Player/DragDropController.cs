using UnityEngine;
using UnityEngine.InputSystem;

namespace EmptyTheGarage.Player.ItemsDraging
{
    public class DragDropController : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 offset = new Vector3(0.5f, 0.5f, 0f);
        [SerializeField]
        protected float rayLength = 500f;

        protected InputSystem inputSystem = default;
        protected Ray ray = default;
        protected RaycastHit hit = default;
        protected IDragable draggableObject = default;
        protected bool isDraging = false;

        protected virtual void Awake()
        {
            inputSystem = new InputSystem();
            inputSystem.Enable();
        }

        protected virtual void OnEnable()
        {
            inputSystem.GameplayPC.LeftButtonPressed.performed += RaycastForward;
            inputSystem.GameplayPC.LeftButtonPressed.canceled += RaycastForward;
        }

        protected virtual void Update()
        {
            ray = Camera.main.ViewportPointToRay(offset);
            Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

            if (draggableObject != null)
            {
                draggableObject.OffHighlight();
            }
           

            if (!isDraging && Physics.Raycast(ray, out hit, rayLength))
            {
                if (hit.collider.TryGetComponent(out draggableObject))
                {
                    draggableObject.OnHighlight();
                }
            }
            
        }

        protected virtual void OnDisable()
        {
            inputSystem.GameplayPC.LeftButtonPressed.performed -= RaycastForward;
            inputSystem.GameplayPC.LeftButtonPressed.canceled -= RaycastForward;
        }

        protected virtual void RaycastForward(InputAction.CallbackContext context)
        {
            if (context.performed)
            { 
                if (draggableObject != null)
                {
                    draggableObject.Drag(Camera.main.transform, hit.distance);
                    isDraging = true;
                }
            }
            else if (context.canceled)
            {
                if (draggableObject != null)
                {
                    draggableObject.Drop();
                    isDraging = false;
                }
            }
        }
    }
}