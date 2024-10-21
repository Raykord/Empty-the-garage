using EmptyTheGarage.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerMoveController))]
public class PlayerInputManager : MonoBehaviour
{
    protected InputSystem inputSystem = default;
    protected PlayerMoveController playerMoveController = default;
    protected Vector2 input = Vector2.zero;

    void Awake()
    {
        inputSystem = new InputSystem();
        inputSystem.Enable();
        playerMoveController = GetComponent<PlayerMoveController>();
    }

    
    void Update()
    {
        input = inputSystem.GameplayPC.Movement.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        playerMoveController.Move(input);
    }
}
