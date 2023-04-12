using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public Rigidbody2D myRigidbody;
    public Animator animator;
    public HealthBase healthBase;
    public Vector2 friction = new Vector2(-.1f, 0);
    public float timeToDestroy = 1.5f;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    private float _currentSpeed;
    #endregion

    #region Methods

    // *Player Movement explanation*
    // The ideia is that we move the player through the input of the arrows.
    // We use GetKey instead of GetKeyDown because the latter gets only the first event.
    // Once an arrow is pressed we move the player, we can do this through his position or through his velocity.
    // In case of position we normalize the movement with Time.deltaTime.
    // Because we removed the friction with the material in Unity so the player couldn't get attached to the wall we need to add friction through the code.
    // In order for the player to have the option to run we set 2 different speed variables and we check if the run key is pressed or not to alternate between the speed variables.

    // *Player Jump explanation*
    // The ideia is that the player jumps through the input of the space bar.
    // Once the space bar is pressed a force is added to the Vector2 of the player.

    // *Player Jump Scale explanation*
    // The ideia is that when the player jumps we add a little animation so it feels more natural.
    // To do that we tweak with the scale of the player.

    // *Player Run explanation*
    // The ideia is that when the player runs we set the animation of running to true.
    // And a little extra is the animation to swipe the sprite to the correct direction.

    private void Awake()
    {
        if (healthBase != null)
            healthBase.onKill += OnPlayerKill;
    }

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
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

        if (myRigidbody.velocity.x > 0)
            myRigidbody.velocity += friction;
        else if (myRigidbody.velocity.x < 0)
            myRigidbody.velocity -= friction;
    }

    private void HandleJump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.jumpAnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);

    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;
        animator.SetTrigger(soPlayerSetup.triggerDeath);
        Destroy(gameObject, timeToDestroy);
    }
    #endregion
}
