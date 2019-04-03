using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Input;

public class PlayerControl : MonoBehaviour
{
    [Header("Control")]
    public KeyCode Attack = KeyCode.J;
    public KeyCode Jump = KeyCode.Space;
    
    [Header("Attribute")]
    public float MovingSpeed;
    public float JumpingSpeed;
    public int ComboFrameRange;
    public int MaxAttackStage;
    public float HitRecover;
    public LayerMask groundLayer;

    private Vector2 SpeedH = new Vector2(0, 0);
    private Vector2 SpeedV = new Vector2(0, 0);
    private Rigidbody2D rb;

    [Header("Game Stat")]
    public Animator animator;
    public bool FacingRight = true;
    public int AttackStage;
    public int ComboBar;
    public bool injured;
    public bool retreating;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpeedH.Set(MovingSpeed, 0);
        SpeedV.Set(0, JumpingSpeed);
    }
    
    void Update()
    {
        //Check for Grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * 0.6f, groundLayer);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }        
                
        //Injured
        if (injured && !retreating)
        {
            animator.SetBool("Injured", true);
            rb.velocity *= -1;
            if (rb.velocity.y > 0)
            {
               Vector2 magnify = rb.velocity;
               magnify.y = JumpingSpeed;
               rb.velocity = magnify;
            }            
            retreating = true;
            Invoke("Recover", HitRecover);
        }

        if (!injured)
        {
            //Walk
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MovingSpeed, rb.velocity.y);
            if (grounded && rb.velocity.x != 0)
            {
                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            } 
                    
            //Jump & Fall
            animator.SetBool("Jump", false);
            if (grounded && Input.GetKeyDown(Jump))
            {
                rb.velocity += SpeedV;
                animator.SetBool("Jump", true);
            }
    
            if (rb.velocity.y > 0)
            {
                animator.SetBool("Rising", true);
            }
            else
            {
                animator.SetBool("Rising", false);
            } 
            
            if (rb.velocity.y < 0)
            {
                animator.SetBool("Falling", true);
            }
            else
            {
                animator.SetBool("Falling", false);
            }
            
            //Flip
            if (!injured && ((rb.velocity.x < 0 && FacingRight) || (rb.velocity.x > 0 && !FacingRight)))
            {
                FacingRight = !FacingRight;
                Vector3 CharScale = transform.localScale;
                CharScale.x *= -1;
                transform.localScale = CharScale;        
            }        
        }

        
        //Attack        
        if (ComboBar > 0)
        {
            ComboBar--;
            if (ComboBar == 0)
            {
                AttackStage = 0;
                animator.SetInteger("AttackStage", AttackStage);
            }
        }

        if (!injured && Input.GetKeyDown(Attack) && AttackStage < MaxAttackStage && ComboBar < 30)
        {
            AttackStage++;
            animator.SetInteger("AttackStage", AttackStage);
            ComboBar += ComboFrameRange;        
        }
    }

    void Recover()
    {
        injured = false;
        animator.SetBool("Injured", false);
        retreating = false;
    }
}
