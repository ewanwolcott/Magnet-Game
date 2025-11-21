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
    private Color32 polarityColor;
    public int polarity;
    public bool magnetised;
    private void FixedUpdate()
    {
        rb.AddForceX(horizontal * acceleration);
        sr.color = polarityColor;
        if(rb.linearVelocityX < -topSpeed)
        {
            rb.linearVelocityX = -topSpeed;
        }
        else if(rb.linearVelocityX > topSpeed)
        {
            rb.linearVelocityX = topSpeed;
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


    #endregion
}
