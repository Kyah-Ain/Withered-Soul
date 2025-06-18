using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class EnemyPatrol : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    // Enemy NPC's Patrol Pathfinding
    private Rigidbody2D enemyNPC; // Contains "Physics" Body of the Enemy
    private Animator animations; // Contains "Animations" of the enemy
    public float speed; // Movement speed of the NPC

    public GameObject pointA; // First point for the NPC to go to
    public GameObject pointB; // Next point for the NPC to go to
    private Transform currentPoint; // Current target point the NPC is moving towards
    public float radius; // Size of the point location

    // ------------------------- FUNCTIONS -------------------------

    void Start() // Called before the first frame update
    {
        enemyNPC = GetComponent<Rigidbody2D>(); // Gets reference to the Rigidbody2D component for physics-based movement
        animations = GetComponent<Animator>(); // Gets reference to the Animator component for controlling animations

        currentPoint = pointA.transform; // Sets the initial target position to pointA

        animations.SetBool("isMoving", true); // Enables the moving animation when the NPC starts patrolling
    }

    void Update() // Called once per frame
    {
        Vector2 point = currentPoint.position - transform.position; // Calculates the direction towards the current target point

        if (currentPoint == pointB.transform) // If NPC is moving towards pointB
        {
            enemyNPC.velocity = new Vector2(speed, 0); // Moves NPC to the right
        }
        else // If NPC is moving towards pointA
        {
            enemyNPC.velocity = new Vector2(-speed, 0); // Moves NPC to the left
        }

        // Check if NPC has reached pointB, then switch target to pointA
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            EnemyFlip(); // Flips NPC's facing direction
            currentPoint = pointA.transform; // Sets new target to pointA
        }
        // Check if NPC has reached pointA, then switch target to pointB
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            EnemyFlip(); // Flips NPC's facing direction
            currentPoint = pointB.transform; // Sets new target to pointB
        }
    }

    // Flips the NPC sprite to face the opposite direction
    void EnemyFlip() // Flips the NPC sprite by inverting its local scale on the x-axis
    {
        Vector3 localScale = transform.localScale; // Gets current local scale
        localScale.x *= -1; // Flips the sprite by inverting the x-axis scale
        transform.localScale = localScale; // Applies the new scale
    }

    private void OnDrawGizmos() // Debugging tool: Draws visual indicators for patrol points
    {
        Gizmos.color = Color.red; // Sets the Gizmos color to red

        // Draws wireframe spheres at pointA and pointB to visualize their positions
        Gizmos.DrawWireSphere(pointA.transform.position, radius);
        Gizmos.DrawWireSphere(pointB.transform.position, radius);

        // Draws a line between pointA and pointB to represent the patrol path
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
