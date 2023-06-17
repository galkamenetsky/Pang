using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TMP_Text text;
    private float horizontal;
    private bool isFacingRight;
    private InputAction inputAction;
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions.FindAction("Move");
    }
    void Update()
    {
        //horizontal = playerInput.actions["Move"].ReadValue<Vector2>().x;
       // Debug.Log(horizontal);
        Flip();
    }
    private void FixedUpdate()
    {
       // horizontal = inputAction.ReadValue<Vector2>().x;
      //  Debug.Log(horizontal);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void Move(float hor)
    {
        horizontal = hor;
    }
    public void StopMove()
    {
        horizontal = 0f;
    }
    public void MoveCallback(CallbackContext context)
    {
        Move(context.ReadValue<Vector2>().x);
    }
}
