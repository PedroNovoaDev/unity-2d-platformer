using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public Rigidbody2D myRigidbody;
    public Vector2 velocity;
    public float speed;
    #endregion

    #region Methods

    // *Player Movement explanation*
    // The ideia is that we move the player through the input of the arrows.
    // We use GetKey instead of GetKeyDown because the latter gets only the first event.
    // Once an arrow is pressed we move the player, we can do this through his position or through his velocity.
    // In case of position we normalize the movement with Time.deltaTime.

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        }
    }
    #endregion
}
