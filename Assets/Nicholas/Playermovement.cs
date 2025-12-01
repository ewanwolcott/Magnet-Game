using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Playermovement : MonoBehaviour
{
    [Header("Player Component Refrences")]
    public  Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;

    [Header("Player Settings")]
    public float acceleration;
    public float topSpeed;
    [SerializeField] float jumpingPower;

    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    private float horizontal;
    private float vertical;
    private Color32 polarityColor;
    public int polarity;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float directionx;
    private float directiony;

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.AddForceX(horizontal * acceleration);
        if (rb.gravityScale == 0)
        {
            rb.AddForceY(vertical * acceleration);
        }
        

        sr.color = polarityColor;
        if(rb.linearVelocityX < -topSpeed)
        {
            rb.linearVelocityX = -topSpeed;
        }
        else if(rb.linearVelocityX > topSpeed)
        {
            rb.linearVelocityX = topSpeed;
        }
        else if (rb.linearVelocityY > topSpeed)
        {
            rb.linearVelocityY = topSpeed;
        }
        else if (rb.linearVelocityY > topSpeed)
        {
            rb.linearVelocityY = topSpeed;
        }

    }
    private void Update()
    {
        if (Input.GetMouseButton(0)) // when left mouse button down
        {
            polarity = 1;
            polarityColor = new Color32(255,0,0,255);
        }
        else if (Input.GetMouseButton(1)) // when right mouse button is down
        {
            polarity = -1;
            polarityColor = new Color32(0, 0, 255, 255);
        }
        else
        {
            polarity = 0;
            polarityColor = new Color32(255, 255, 255, 255);
        }
    }

    #region PLAYER_CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
        if (horizontal != 0)
        {
            directionx = horizontal;
        }
        if (vertical != 0)
        {
            directiony = vertical;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(canDash && context.performed)
        {
            StartCoroutine(Dash());
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
    private IEnumerator Dash ()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(directionx * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
            return
    ;   Physics2D.BoxCast(transform.position, new Vector2(1.5f, 1.5f), 0, Vector2.zero);
    }
    #endregion


}
