using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light puzzleLight;

    private void Awake()
    {
        // Get the Light component
        puzzleLight = GetComponent<Light>();

        // Ensure the light starts off
        if (puzzleLight != null)
        {
            puzzleLight.enabled = false;
        }
    }

    // Function to turn on the light
    public void TurnOnLight()
    {
        if (puzzleLight != null)
        {
            puzzleLight.enabled = true;
            Debug.Log("Light is turned on!");
        }
    }

    // Function to turn off the light
    public void TurnOffLight()
    {
        if (puzzleLight != null)
        {
            puzzleLight.enabled = false;
            Debug.Log("Light is turned off!");
        }
    }
}
