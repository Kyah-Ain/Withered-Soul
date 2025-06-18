using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class PlatformMovement : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    public Transform pointA, pointB; // Destination options of the platform
    public GameObject characterParent; // Original parent of the player
    private Vector3 nextPosition; // Current destination goal of the platform

    public float moveSpeed = 2f; // Speed of the platform
    public float radius; // Size of the point location

    // ------------------------- FUNCTIONS -------------------------

    void Start() // Start is called before the first frame update
    {
        nextPosition = pointA.position; // Choses B as the starting destination 
    }

    void FixedUpdate() // Fixed Update is called once per frame
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime); // Moves the platform from its current position to the nextPosition at a speed of moveSpeed

        if (transform.position == nextPosition) // Checks if the platform has reached its current destination
        {
            nextPosition = (nextPosition == pointA.position) ? pointB.position : pointA.position; // Switches the destination between pointA and pointB
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Triggers when a gameObject enters a collision with something that have this script
    {
        if (collision.gameObject.CompareTag("Player")) // Specifies the collision to execute the code when collided with Player
        {
            collision.gameObject.transform.parent = transform; // Makes the player a child of the platform so it moves with the platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Triggers when a gameObject exits a collision with something that have this script
    {
        if (collision.gameObject.CompareTag("Player")) // Specifies the collision to execute the code when collided with Opassum 
        {
            collision.gameObject.transform.parent = characterParent.transform; // Removes the player as a child of the platform so it no longer moves with the platform
        }
    }

    private void OnDrawGizmos() // Adds highlight markings to whatever unseen system range detector (THIS TOOL IS JUST FOR DEBUGGING)
    {
        // Color of the Enemy NPC's point paths
        Gizmos.color = Color.red;

        // Point Paths Wireframe
        Gizmos.DrawWireSphere(pointA.transform.position, radius); // Draws a red wireframe sphere at pointA's position
        Gizmos.DrawWireSphere(pointB.transform.position, radius); // Draws a red wireframe sphere at pointB's position
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position); // Draws a red wireframe sphere at pointA's to pointB's position
    }
}
