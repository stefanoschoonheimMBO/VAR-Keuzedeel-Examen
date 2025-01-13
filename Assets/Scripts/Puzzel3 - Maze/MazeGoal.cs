using UnityEngine;

public class MazeGoal : MonoBehaviour
{
    // Reference to the LightController
    public LightController lightController;

    // If Ball enters area...
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the ball has the tag
        if (other.CompareTag("PlayerBall"))
        {
            Debug.Log("Puzzle 3 complete!");

            // Notify the LightController to turn on light (if it exists)
            if (lightController != null)
            {
                lightController.TurnOnLight();
            }
        }
    }

    // If ball exists area...
    private void OnTriggerExit(Collider other)
    {
        // Checks if the ball has the tag
        if (other.CompareTag("PlayerBall"))
        {
            Debug.Log("Puzzle 3 not completed");

            // Notify the LightController to turn on light (if it exists)
            if (lightController != null)
            {
                lightController.TurnOffLight();
            }
        }
    }
}
