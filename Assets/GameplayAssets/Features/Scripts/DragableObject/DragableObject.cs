using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmptyTheGarage.Player.ItemsDraging
{
    [RequireComponent(typeof(Rigidbody), typeof(Outline))]
    public class DragableObject : MonoBehaviour, IDragable
    {
        protected bool isDraged = false;
        protected Coroutine dragCoroutine = default;
        protected Rigidbody body = default;
        protected Outline outline = default;
        protected Transform playerCamera = default;
        protected float holdDistance = 0f;

        protected virtual void Start()
        {
            body = GetComponent<Rigidbody>();
            outline = GetComponent<Outline>();
        }

        public void OnHighlight() => outline.enabled = true;
        public void OffHighlight() => outline.enabled = false;

        public void Drag(Transform camera, float holdDistance)
        {
            Debug.Log($"{gameObject.name} draged");
            isDraged = true;
            body.isKinematic = true;
            this.holdDistance = holdDistance;
            playerCamera = camera;
            dragCoroutine = StartCoroutine(StartDraging());
        }

        public void Drop()
        {
            Debug.Log($"{gameObject.name} droped");
            dragCoroutine = null;
            isDraged= false;
            body.isKinematic = false;
        }

        protected virtual IEnumerator StartDraging()
        {
            while(isDraged && isActiveAndEnabled)
            {
                Vector3 nextPosition = playerCamera.position + playerCamera.forward * holdDistance;
                transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * 10);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}