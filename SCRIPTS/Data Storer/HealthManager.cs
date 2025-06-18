using UnityEngine.UI; // Allows the use of UI elements, such as Image components
using UnityEngine; // Grants access to Unity's core features 

public class HealthManager : MonoBehaviour
{
    // ------------------------- VARIABLES -------------------------

    public SceneNavigator sceneNavigatorScript; // Reference to the SceneNavigator script for scene management

    public Image healthBar; // Reference to the UI Image that represents the health bar
    public float maxHealth = 100f; // Maximum health value
    public float currentHealth = 100f; // Tracks the player's current health

    // ------------------------- FUNCTIONS -------------------------

    void Start() // Called once when the script starts
    {
        currentHealth = maxHealth; // Initialize health to the maximum value
        UpdateHealthBar(); // Update the UI to reflect full health
    }

    private void Update() // Called once per frame
    {
        // Check if the player's health has dropped to or below 0
        if (currentHealth <= 0)
        {
            sceneNavigatorScript.BtnLoadSceneSpecific(); // Trigger the scene navigation to load a specific scene
            Debug.Log("LoadSpecficTriggered!"); 
        }
    }

    public void TakeDamage(float damage) // Reduces health when damage is taken
    {
        currentHealth -= damage; // Subtract damage from current health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health stays between 0 and max
        UpdateHealthBar(); // Refresh the health bar display
    }

    public void Heal(float heal) // Restores health when healed
    {
        currentHealth += heal; // Increase current health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health does not exceed max
        UpdateHealthBar(); // Refresh the health bar display
    }

    private void UpdateHealthBar() // Updates the UI health bar fill amount
    {
        healthBar.fillAmount = currentHealth / maxHealth; // Set the fill amount of the health bar based on the current health percentage
    }
}