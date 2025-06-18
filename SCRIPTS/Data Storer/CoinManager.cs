using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using TMPro; // Grants access to Text Mesh Pro functions
using UnityEngine; // Grants access to Unity's core features 

public class CoinManager : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    public TextMeshProUGUI displayedScore; // Refers to the Score Board in the Game Scene
    public int coinCount; // Keeps track of the coins collected
    public int currentLevelAt; // Stores what current level you are and base the display format on the current level

    public Transform playerTransformValue; // Reference to the player's transform current value 

    // ------------------------- FUNCTIONS -------------------------
    private void Start() // Start is called before the first frame update
    {
        playerTransformValue = GameObject.FindGameObjectWithTag("Player").transform; // Finds a gameObject that tagged as "Player" and stores its transform value
    }

    void Update() // Update is called once per frame 
    {
        if (currentLevelAt == 3)
        {
            // stores how high you've reached = (get the date from your y value - the offset since the character was not on the origin which is 0) * 1 unit per estimated feet which is 3.28)
            int heightReached = Mathf.RoundToInt((playerTransformValue.position.y - (-3.25f)) * 3.28f); // Displays the height you already reached on level 3 and displays it in integer
            displayedScore.text = $"{heightReached} feet"; // Displays the points to the Game Scene 
        }
        else
        {
            displayedScore.text = $"Score:{coinCount}"; // Displays the collected coins to the Game Scene 
        }
    }
}
