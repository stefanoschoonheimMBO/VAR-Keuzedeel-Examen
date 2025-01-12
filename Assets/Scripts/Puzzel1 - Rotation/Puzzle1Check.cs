using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Check : MonoBehaviour
{
    // Dictionary to store the status of the items
    private Dictionary<GameObject, bool> rotationStatuses = new Dictionary<GameObject, bool>();

    // Reference to the LightController
    public LightController lightController;

    /* Function to add the items dynamically to the dictionary. If they are in the right rotation, add bool IsCorrect to the item
     GameObject obj = the item itself
    bool isCorrect = bool / flag for checking if item is in correct rotation
    */
    public void UpdateRotationStatus(GameObject obj, bool isCorrect)
    {
        // If statement to check if the object / item is already in the dictionary
        if (rotationStatuses.ContainsKey(obj))
        {
            // Update the rotation status of the given object / item to the isCorrect value
            rotationStatuses[obj] = isCorrect;
        }
        // If the object / item is not yet in the dictionary...
        else
        {
            // Add the object / item to the dictionary with the isCorrect value
            rotationStatuses.Add(obj, isCorrect);
        }

        // Check if all objects are correctly rotated
        CheckPuzzleCompletion();
    }

    // Function to check the completion / rotation status of all items
    private void CheckPuzzleCompletion()
    {
        // Checks all items based on the isCorrect bool
        foreach (var status in rotationStatuses.Values)
        {
            // If item has no isCorrect bool value as status, turn off light (item is not correctly rotated)
            if (!status)
            {
                Debug.Log("Puzzle not solved yet.");

                // Notify the LightController to turn off light (if it exists)
                if (lightController != null)
                {
                    lightController.TurnOffLight();
                }

                return;
            }
        }

        // If all objects are correctly rotated
        Debug.Log("Puzzle solved!");

        // Notify the LightController to turn on light (if it exists)
        if (lightController != null)
        {
            lightController.TurnOnLight();

        }
    }
}
