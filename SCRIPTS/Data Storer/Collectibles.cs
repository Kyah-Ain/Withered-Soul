using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class Collectibles : MonoBehaviour 
{
    // ------------------------- VARIABLES -------------------------
    public AudioSource[] soundEffects; // Placeholder for the sound effects

    public CoinManager coinManagerScript; // Gives access to the data of the "CoinManager" Script
    public HealthManager healthManagerScript; // Gives access to the data of the "healthManager" Script

    // ------------------------- FUNCTIONS -------------------------
    void OnTriggerEnter2D(Collider2D other) // Trigger to when there's collision happened (Unity Built In Function that you cant rename)
    {
        if (other.gameObject.CompareTag("GoldCoin")) // Filters gameObjects to only accepts colliding with coins as a point
        {
             Destroy(other.gameObject); // Destroys already collected coins
             coinManagerScript.coinCount++; // Increments the "coinCount" variable from the "CoinManager" Script
             healthManagerScript.Heal(10f); // Triggers the Health function to restore player's health
        
            foreach (AudioSource audio in soundEffects) // Plays all the sound effects
            {
                audio.Play(); // Plays the sound effect
            }
            //Debug.Log(coinManagerScript.coinCount);
        }
    }
}
