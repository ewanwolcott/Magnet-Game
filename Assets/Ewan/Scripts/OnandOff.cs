using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggle : MonoBehaviour
{
    public Light2D myLight; // Reference to the Light2D component
    private bool isLightOn = false;

    // Make sure to assign your Light2D component in the Inspector

    void Start()
    {
        // Start with the light off
        myLight.enabled = false;
        isLightOn = false;
    }

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        isLightOn = !isLightOn;
        myLight.enabled = isLightOn;
        Debug.Log("Light is now " + (isLightOn ? "ON" : "OFF"));
    }
}