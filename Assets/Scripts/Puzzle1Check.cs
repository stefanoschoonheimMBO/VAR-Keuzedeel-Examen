using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Check : MonoBehaviour
{
    private Dictionary<GameObject, bool> rotationStatuses = new Dictionary<GameObject, bool>();

    // Reference to the LightController
    public LightController lightController;

    public void UpdateRotationStatus(GameObject obj, bool isCorrect)
    {
        // Update the rotation status of the given object
        if (rotationStatuses.ContainsKey(obj))
        {
            rotationStatuses[obj] = isCorrect;
        }
        else
        {
            rotationStatuses.Add(obj, isCorrect);
        }

        // Check if all objects are correctly rotated
        CheckPuzzleCompletion();
    }

    private void CheckPuzzleCompletion()
    {
        foreach (var status in rotationStatuses.Values)
        {
            if (!status)
            {
                Debug.Log("Puzzle not solved yet.");

                lightController.TurnOffLight();

                return;
            }
        }

        // If all objects are correctly rotated
        Debug.Log("Puzzle solved!");

        // Notify the LightController
        if (lightController != null)
        {
            lightController.TurnOnLight();
        }
    }
}
