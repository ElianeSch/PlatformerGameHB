using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    public ParticleSystem dust;

    public AudioClip soundStepL;
    public AudioClip soundStepR;
    public AudioClip soundJump;
    public AudioClip soundLanding;

    public bool right = false;
    public int u = 0;

    [Header("Horizontal Movement")]
     public float maxMoveSpeed = 6;
    public float movementAcceleration = 50;
     public float horizontalMovement;
    public float verticalMovement;
     private Vector3 velocity = Vector3.zero;
     private bool facingRight = true;
    public bool isFreezed = false;

     [Header("Jump")]
     public float jumpSpeed;
     public Transform groundCheck;
     public float groundCheckRadius;
     public LayerMask collisionLayer;
     public bool isJumping; // Est-ce que le joueur est en train de sauter
     public bool isGrounded; // Est-ce que le personnage touche le sol (ie est-ce qu'il peut sauter ?)
     private float jumpPressedRememberTime = 0.2f;
     private float jumpPressedRemember = 0f;
     private float groundedRememberTime = 0.1f;
     private float groundedRemember = 0f;
     public bool jumpMushroom = false;
     public bool isInAir = false;

    [Header("Climb")]
    public bool isClimbing;
    public float climbSpeed = 10f;


    [Header("Physics")]
     public float linearDrag = 10;
     public float airLinearDrag = 2.5f;
     public float fallMultiplier = 8;
     public float lowJumpFallMultiplier = 5f;


     [Header("Slopes")]
    public float slopeCheckDistance;
    private float slopeDownAngle;
    private Vector2 slopeNormalPerp;
    public bool isOnSlope;
    private float slopeDownAngleOld;
    private float slopeSideAngle;
    public float slopeSpeed;
    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D fullFriction;
    public float maxSlopeAngle;
    public bool canWalkOnSlope;
    public float wallAngle;
    public float damping;

    [Header("Components")]
     public Rigidbody2D rb; // Référence au rigidbody du personnage
     public Animator animator; // Référence à l'animator
     
     



    private void Awake()
    {
        instance = this;
    }


    private void Update()
     {

        if (isOnSlope)
        {
            isInAir = false;
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        if (Input.GetKey("right"))
        {
            horizontalMovement = 1;
        }

        else if (Input.GetKey("left"))
        {
            horizontalMovement = -1;
        }

        else
        {
            horizontalMovement = 0;
        }


        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        // Si le personnage est freezé, il ne peut plus bouger du tout.
        if (isFreezed)
        {
            horizontalMovement = 0;
            verticalMovement = 0;

        }

        // Pour pouvoir sauter si on vient de quitter une plateforme
        groundedRemember -= Time.deltaTime;
        if (isGrounded)
        {
            groundedRemember = groundedRememberTime;
        }



        // Pour pouvoir sauter un chouïa avant de toucher le sol
        jumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressedRemember = jumpPressedRememberTime;
        }



        if (jumpPressedRemember > 0 && groundedRemember > 0 && isFreezed == false && jumpMushroom == false && Mathf.Abs(slopeDownAngle) <= maxSlopeAngle)
        {
            jumpPressedRemember = 0;
            groundedRemember = 0;
            isJumping = true;
        }

        else if(jumpPressedRemember > 0 && groundedRemember > 0 && isFreezed == false && jumpMushroom == false && isOnSlope == false)
        {
            jumpPressedRemember = 0;
            groundedRemember = 0;
            isJumping = true;
        }

        if (isClimbing)
        {
            horizontalMovement = 0;
        }


    }

    


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);

        if (isOnSlope && Mathf.Abs(slopeDownAngle) <= maxSlopeAngle)
        {
            isGrounded = true;

        }

        if (isGrounded == false && isOnSlope == false)
        {
            if (!isInAir) isInAir = !isInAir;
        }

        else
        {
            if(isInAir == true && isOnSlope == false)
            {
                isInAir = false;
                AudioManager.instance.PlayClipAt(soundLanding, transform.position);
            }
        }



        if (isGrounded == false && isClimbing == false && isOnSlope == false)
        {
            animator.SetBool("isJumping", true);
            isInAir = true;
        }

        if (isGrounded || isClimbing) 
        {
            jumpMushroom = false;
            animator.SetBool("isJumping", false);
        }


        slopeCheck();
        moveCharacter();
        modifyPhysics();
    }



    private void slopeCheck()
    {
        Vector2 checkPos = new Vector2(groundCheck.position.x, groundCheck.position.y) + new Vector2(groundCheckRadius, groundCheckRadius);
        Debug.DrawRay(checkPos, Vector2.up, Color.white);
        slopCheckHorizontal(checkPos);
        slopCheckVertical(checkPos);
    }


    private void slopCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, collisionLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, collisionLayer);

        if (slopeHitFront && (Vector2.Angle(slopeHitFront.normal, Vector2.up) < wallAngle))
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }

        else if (slopeHitBack && (Vector2.Angle(slopeHitFront.normal, Vector2.up) < wallAngle))
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }

        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }


    private void slopCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit1 = Physics2D.Raycast(checkPos, new Vector2(0.5f,-0.5f), slopeCheckDistance, collisionLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(checkPos, new Vector2(0.0f, -1f), slopeCheckDistance, collisionLayer);

        if (hit1)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit1.normal.normalized).normalized;
            slopeDownAngle = Vector2.Angle(hit1.normal.normalized, Vector2.up);

            if (Mathf.Abs(slopeDownAngle) <1)
            {
                isOnSlope = false;
            }


            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            var desiredRt = Quaternion.FromToRotation(Vector3.up, hit2.normal) * Quaternion.Euler(0, facingRight ? 0 : 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRt, Time.deltaTime * damping);


            if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
            {
                Flip();
            }

            Debug.DrawRay(hit1.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit1.point, hit1.normal, Color.green);
        }

        else if(hit2)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit2.normal.normalized).normalized;
            slopeDownAngle = Vector2.Angle(hit2.normal.normalized, Vector2.up);

            if (Mathf.Abs(slopeDownAngle) < 1)
            {
                isOnSlope = false;
            }


            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;


            var desiredRt = Quaternion.FromToRotation(Vector3.up, hit2.normal) * Quaternion.Euler(0, facingRight ? 0 : 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRt, Time.deltaTime * damping);

            if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
            {
                Flip();
            }

            Debug.DrawRay(hit2.point, slopeNormalPerp, Color.white);
            Debug.DrawRay(hit2.point, hit2.normal, Color.green);
        }



        else
        {
            isOnSlope = false;
        }


        if (Mathf.Abs(slopeDownAngle) > maxSlopeAngle || slopeSideAngle > maxSlopeAngle)
        {
            canWalkOnSlope = false;
        }

        else
        {
            canWalkOnSlope = true;
        }



        if (isOnSlope && horizontalMovement == 0 && canWalkOnSlope)
        {
            rb.sharedMaterial = fullFriction;
        }

        else
        {
            rb.sharedMaterial = noFriction;
        }

    }








    private void moveCharacter()
    {
        if (!isClimbing)
        {


            if (isJumping)
            {
                Jump();
            }

            if (!isOnSlope)
            {
                rb.AddForce(new Vector2(horizontalMovement, 0f) * movementAcceleration);
            }

            else if (isOnSlope && canWalkOnSlope)
            {
                rb.AddForce(new Vector2(slopeSpeed* slopeNormalPerp.x * -horizontalMovement*1.5f, slopeSpeed * slopeNormalPerp.y * -verticalMovement*1.5f));
            }



            if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
            {
                Flip();
            }

            if (Mathf.Abs(rb.velocity.x) > maxMoveSpeed && isOnSlope == false)
            {
                rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
            }

        }

        else // if is Climbing
        {
            // Déplacement vertical
            rb.AddForce(new Vector2(0, verticalMovement) * climbSpeed);
        }

    }



    void Flip()
    {
        CreateDust();
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);

    }

    void modifyPhysics()
     {

        // Si on est au sol ou sur une échelle, alors on utilise une résistance liée au sol
         if (isGrounded || isClimbing || isJumping || isOnSlope)
         {
            ApplyLinearDrag();
         }

        // Si on saute, on applique la résistance de l'air ainsi que le fall mutliplier
        else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }

    }


    public void ApplyLinearDrag()
    {
        bool changingDirection = ((rb.velocity.x < 0f && horizontalMovement > 0f) || (rb.velocity.x > 0f && horizontalMovement < 0f));

        if (Mathf.Abs(horizontalMovement) < 0.3f || changingDirection)
        {
            rb.drag = linearDrag;
        }

        else
        {
            rb.drag = 0f;
        }

    }

    public void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;

    }

    public void ApplyAirLinearDragMushroom()
    {
        rb.drag = airLinearDrag*1.5f;

    }


    public void FallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && jumpMushroom == false) // Limiter le saut à un "petit" saut quand on appuie rapidement sur la barre d'espace
        {
            rb.gravityScale = lowJumpFallMultiplier;
        }

        else
        {
            rb.gravityScale = 1f;
        }
    }

    public void FallMultiplierMushroom()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier*10;
        }

        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void FreezePlayer()
    {
        isFreezed = true;
    }
 

    void Jump()
     {
        CreateDust();
        AudioManager.instance.PlayClipAt(soundJump, transform.position);
        if (Mathf.Abs(rb.velocity.x) > 0.3f)
         {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);

        }
        
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpSpeed*1.5f, ForceMode2D.Impulse);

        }
        isJumping = false;
    }


     private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
     }

   
    void CreateDust()
    {
        dust.Play();
    }
}
