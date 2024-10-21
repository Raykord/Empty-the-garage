using UnityEngine;
using UnityEngine.InputSystem;

namespace EmptyTheGarage.Feature.ItemsDraging
{
    public class DragDropController : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 offset = new Vector3(0.5f, 0.5f, 0f);
        [SerializeField]
        protected float rayLength = 500f;

        protected Ray ray = default;
        protected RaycastHit hit = default;
        protected IDragable draggableObject = default;
        protected bool isDraging = false;

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

        public virtual void RaycastForward(InputAction.CallbackContext context)
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