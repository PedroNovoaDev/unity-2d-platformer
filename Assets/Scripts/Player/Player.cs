using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public Rigidbody2D myRigidbody;
    //public Vector2 velocity;
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;

    [Header("Jump")]
    public float forceJump = 2;

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

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.x > 0)
            myRigidbody.velocity += friction;
        else if (myRigidbody.velocity.x < 0)
            myRigidbody.velocity -= friction;
    }

    public void HandleJump() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
            myRigidbody.velocity = Vector2.up * forceJump;
    }
    #endregion
}
