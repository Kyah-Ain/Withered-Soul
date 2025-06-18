using System.Collections; // Grants access to collections and data structures like ArrayList
using System.Collections.Generic; // Grants access to collections and data structures like List and Dictionary
using UnityEngine; // Grants access to Unity's core features 

public class EnemyDamage : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------
    public GameObject soundEffectPrefab; // Prefab for sound effect (with AudioSource attached)
    public Transform soundParent; // Who you want the sound to be parented to (e.g. player, self, etc.)
    private GameObject currentSoundInstance; // Keeps track of last sound so we don’t spam it

    public HealthManager healthManagerScript; // Reference to the player’s health script

    public float opassumDamage; // Damage value from Opassum
    public float vultureDamage; // Damage value from Vulture

    // ------------------------- FUNCTIONS -------------------------
    private void OnCollisionStay2D(Collision2D collision) // Triggered when the player continously collides with an enemy
    {
        if (collision.gameObject.CompareTag("Opassum")) // Checks if the collided object is an Opassum
        {
            if (currentSoundInstance == null) // Prevents sound overlapping (lets the current sound finish before executing new)
            {
                currentSoundInstance = Instantiate(soundEffectPrefab, soundParent); // Clean & simple parenting
            }

            healthManagerScript.TakeDamage(opassumDamage); // Triggers the Health function to reduce player's health by opassumDamage
            Debug.Log("Damage Executed by Opassum!");
        }

        else if (collision.gameObject.CompareTag("Vulture")) // Checks if the collided object is a Vulture
        {
            if (currentSoundInstance == null) // Prevents sound overlapping (lets the current sound finish before executing new)
            {
                currentSoundInstance = Instantiate(soundEffectPrefab, soundParent); // Same clean method
            }

            healthManagerScript.TakeDamage(vultureDamage); // Triggers the Health function to reduce player's health by vultureDamage
            Debug.Log("Damage Executed by Vulture!");
        }
    }
}
