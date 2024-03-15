using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PlayerMovement movement;
    public PlayerMouseLook mouseLook;
    public PlayerShoot shoot;

    PlayerControls controls;
    PlayerControls.FloorMoveActions floorMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake() {
        controls = new PlayerControls();
        floorMovement = controls.FloorMove;

        floorMovement.HorizontalMove.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        floorMovement.Jump.performed += _ => movement.onJump();
        floorMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        floorMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        floorMovement.Shoot.performed += _ => shoot.onShoot();
    }

    private void OnEnable() {controls.Enable();}
    private void OnDestroy() {controls.Disable();}

    void Start() {}

    void Update() {
        movement.receiveInput(horizontalInput);
        mouseLook.receiveInput(mouseInput);
    }
}
