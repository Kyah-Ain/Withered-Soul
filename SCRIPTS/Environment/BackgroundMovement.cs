using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class BackgroundMovement : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    public CoinManager coinManagerScript; // Reference to the CoinManager.cs script to check the current level

    private float startPos, length, width; // Stores the initial position ,length and width of the background
    public GameObject cam; // Reference to the main camera to track its movement
    public float parallaxEffect; // Determines how much the background moves in relation to the camera movement

    // ------------------------- FUNCTIONS -------------------------

    void Start() // Called before the first frame update
    {
        if (coinManagerScript.currentLevelAt == 3) // Checks if the current level is 3 (vertical scrolling)
        {
            startPos = transform.position.y; // Stores the initial y-position of the background
            width = GetComponent<SpriteRenderer>().bounds.size.y; // Gets the width of the background sprite
        }
        else
        {
            startPos = transform.position.x; // Stores the initial x-position of the background
            length = GetComponent<SpriteRenderer>().bounds.size.x; // Gets the length of the background sprite
        }
            
    }

    void FixedUpdate() // Called at fixed intervals (better for physics-based movement)
    {
        if (coinManagerScript.currentLevelAt == 3) // Checks if the current level is 3 (vertical scrolling)
        {
            // 0 = moves with the camera || 1 = static || 0.5 = moves at half speed of the camera
            float distance = cam.transform.position.y * parallaxEffect; // Calculates how far the background should move
            float movement = cam.transform.position.y * (1 - parallaxEffect); // Adjusts movement speed based on effect factor

            transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z); // Moves background

            // If the background moves past its length, reposition it for seamless looping (infinite scrolling effect)
            if (movement > startPos + width) // Checks if the background has moved past its initial position plus its width
            {
                startPos += width; // Adjusts the start position forward
            }
            else if (movement < startPos - width) // Checks if the background has moved past its initial position minus its width   
            {
                startPos -= width; // Adjusts the start position backward
            }
        }
        else
        {
            // 0 = moves with the camera || 1 = static || 0.5 = moves at half speed of the camera
            float distance = cam.transform.position.x * parallaxEffect; // Calculates how far the background should move
            float movement = cam.transform.position.x * (1 - parallaxEffect); // Adjusts movement speed based on effect factor

            transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z); // Moves background

            // If the background moves past its length, reposition it for seamless looping (infinite scrolling effect)
            if (movement > startPos + length) // Checks if the background has moved past its initial position plus its length
            {
                startPos += length; // Adjusts the start position forward
            }
            else if (movement < startPos - length) // Checks if the background has moved past its initial position minus its length
            {
                startPos -= length; // Adjusts the start position backward
            }
        }
    }
}
