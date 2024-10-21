using EmptyTheGarage.Feature.ItemsDraging;
using EmptyTheGarage.Feature.Movement;
using UnityEngine;

namespace EmptyTheGarage.Features.Input
{
    [RequireComponent(typeof(PlayerMoveController), typeof(DragDropController))]
    public class PlayerInputManager : MonoBehaviour
    {
        protected InputSystem inputSystem = default;
        protected PlayerMoveController playerMoveController = default;
        protected DragDropController dragDropController = default;
        protected Vector2 input = Vector2.zero;

        void Awake()
        {
            inputSystem = new InputSystem();
            inputSystem.Enable();
            playerMoveController = GetComponent<PlayerMoveController>();
            dragDropController = GetComponent<DragDropController>();
        }

        protected virtual void OnEnable()
        {
            inputSystem.GameplayPC.LeftButtonPressed.performed += dragDropController.RaycastForward;
            inputSystem.GameplayPC.LeftButtonPressed.canceled += dragDropController.RaycastForward;
        }

        void Update() => input = inputSystem.GameplayPC.Movement.ReadValue<Vector2>();

        private void FixedUpdate() => playerMoveController.Move(input);

        protected virtual void OnDisable()
        {
            inputSystem.GameplayPC.LeftButtonPressed.performed -= dragDropController.RaycastForward;
            inputSystem.GameplayPC.LeftButtonPressed.canceled -= dragDropController.RaycastForward;
        }
    }
}