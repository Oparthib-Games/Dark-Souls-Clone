using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OP {
    public class InputHandler : MonoBehaviour {
        public float H;
        public float V;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        PlayerCtrls inputActions;

        Vector2 movementInput;
        Vector2 cameraInput;

        public void OnEnable() {
            if(inputActions == null) {
                inputActions = new PlayerCtrls();
                inputActions.PlayerMovement.Movement.performed += cntx01 => movementInput = cntx01.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += cntx02 => cameraInput = cntx02.ReadValue<Vector2>();
            }

            inputActions.Enable();
        }
        public void OnDisable() {
            inputActions.Disable();
        }

        public void TickInput(float delta) {
            MoveInput(delta);
        }
        public void MoveInput(float delta) {
            H = movementInput.x;
            V = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(H) + Mathf.Abs(V));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }
    }
}
