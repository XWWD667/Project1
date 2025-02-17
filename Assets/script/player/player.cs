using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;
    private Animator[] animators;
    private bool isMoving;
    private bool inputDisable;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        animators = GetComponentsInChildren<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.MoveToPosition += OnMoveToPosition;
    }

    private void OnDisable()
    {
        EventHandler.MoveToPosition -= OnMoveToPosition;
    }

    private void OnMoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
    private void Update()
    { 
        if(inputDisable==false)
        PlayerInput();
        SwitchAnimation();
    }
    private void FixedUpdate()
    {
       Movement();
    }
    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 && inputY != 0)
        {
            inputX = inputX * 0.6f;
            inputY = inputY * 0.6f;
        }

        movementInput = new Vector2(inputX, inputY);

        isMoving = movementInput != Vector2.zero;
    }
     
   private void Movement()
    {
        rb.MovePosition(rb.position+movementInput*speed*Time.deltaTime);
    }

   private void SwitchAnimation()
    {
        foreach (var anim in animators)
        {
            anim.SetBool("IsMoving", isMoving);
            if (isMoving)
            {
                anim.SetFloat("InputX", inputX);
                anim.SetFloat("InputY", inputY);
            }
        }    
    } 
}
