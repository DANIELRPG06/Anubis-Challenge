using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public PlayerControlle playerController; 
    private Slider staminaSlider;

    private void Start()
    {
        staminaSlider = GetComponent<Slider>();

    }

    private void Update()
    {
        
        staminaSlider.value = playerController.currentStamina / playerController.maxStamina;
    }
}
