using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public PlayerControlle playerController; // Reference to the PlayerControlle script
    private Slider staminaSlider;

    private void Start()
    {
        staminaSlider = GetComponent<Slider>();

    }

    private void Update()
    {
        // Update the Slider's value to represent the current stamina.
        staminaSlider.value = playerController.currentStamina / playerController.maxStamina;
    }
}