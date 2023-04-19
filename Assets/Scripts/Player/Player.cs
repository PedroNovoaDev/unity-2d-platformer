using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Player Variables")]
    public Rigidbody2D myRigidbody;
    public Animator animator;
    public HealthBase healthBase;
    public Vector2 friction = new Vector2(-.1f, 0);

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    public float distToGround;
    public float spaceToGround = .1f;

    private float _currentSpeed;
    private bool _isDead;
    #endregion

    #region Methods

    // *Player explanation*
    // Here we'll have all the methods to control the player.

    private void Awake()
    {
        if (healthBase != null)
            healthBase.onKill += OnPlayerKill;

        if (collider2D != null)
            distToGround = collider2D.bounds.extents.y;

        _isDead = false;
        UIInGameManager.Instance.TooglePlayerDeathScreen(false);
    }

    void Update()
    {
        // In the Update we'll check if the Player in grounded to enable the jump or not.
        // And we'll also process the movement and jump here.

        IsGrounded();

        if (!_isDead)
        {
            HandleMovement();
            HandleJump();
        }
    }

    private void HandleMovement()
    {

        // The ideia is that we move the player through the input of the arrows.
        // We use GetKey instead of GetKeyDown because the latter gets only the first event.
        // Once an arrow is pressed we move the player, we can do this through his position or through his velocity.
        // In case of position we normalize the movement with Time.deltaTime.

        // Run movement
        // In order for the player to have the option to run we set 2 different speed variables and we check if the run key is pressed or not to alternate between the speed variables.
        // The ideia is that when the player runs we set the animation of running to true.
        // And a little extra is the animation to swipe the sprite to the correct direction.

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            animator.speed = 1;
        }

        // Normal movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);

            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);

            animator.SetBool(soPlayerSetup.boolRun, true);
        } else
            animator.SetBool(soPlayerSetup.boolRun, false);

        // Because we removed the friction with the material in Unity so the player couldn't get attached to the wall we need to add friction through the code.
        if (myRigidbody.velocity.x > 0)
            myRigidbody.velocity += friction;
        else if (myRigidbody.velocity.x < 0)
            myRigidbody.velocity -= friction;
    }

    private void HandleJump() 
    {

        // The ideia is that the player jumps through the input of the space bar.
        // Once the space bar is pressed a force is added to the Vector2 of the player.
        // To check if the player can jump we use a RayCast to the ground.

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) { 
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
            PlayJumpVFX();
        }
    }

    private void HandleScaleJump()
    {

        // The ideia is that when the player jumps we add a little animation so it feels more natural.
        // To do that we tweak with the scale of the player, scaling it a little bit.

        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);

    }

    private void OnPlayerKill()
    {
        _isDead = true;
        healthBase.onKill -= OnPlayerKill;
        animator.SetTrigger(soPlayerSetup.triggerDeath);
        AudioManager.Instance.PlayPlayerDeathSound();
        UIInGameManager.Instance.TooglePlayerDeathScreen(true);
    }

    private bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector2.up,Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
    }
    #endregion
}
