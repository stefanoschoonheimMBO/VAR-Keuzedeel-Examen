using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PositionChecker : MonoBehaviour
{
    public List<XRSocketInteractor> sockets = new List<XRSocketInteractor>(); // List of XRSocketInteractors (sockets)
    public List<GameObject> books = new List<GameObject>(); // List of books (GameObjects)

    private Vector3[] lastPositions;  // Store the last positions of books
    private bool[] positionLogged;   // Track if the position has been logged
    private bool victoryMessageDisplayed = false; // Track if victory message has been displayed

    void Start()
    {
        // Initialize the last positions of the books
        lastPositions = new Vector3[books.Count];
        positionLogged = new bool[books.Count]; // Initialize the tracking array
        for (int i = 0; i < books.Count; i++)
        {
            lastPositions[i] = books[i].transform.position;  // Store initial positions
            positionLogged[i] = false;                      // Initialize all to false
        }
    }

    void Update()
    {
        bool allAligned = true; // Flag to track if all pairs are aligned

        for (int i = 0; i < sockets.Count; i++)  // Loop through all the sockets
        {
            if (i < books.Count)  // Ensure we don't go out of bounds
            {
                // Only check position if the book has moved
                if (books[i].transform.position != lastPositions[i])  // Compare current position with the last stored position
                {
                    // Update the last known position
                    lastPositions[i] = books[i].transform.position;

                    // Compare the positions
                    if (ArePositionsEqual(sockets[i].transform.position, books[i].transform.position))
                    {
                        if (!positionLogged[i]) // Log only if not already logged
                        {
                            Debug.Log("Socket " + (i + 1) + " and Book " + (i + 1) + " are at the same position.");
                            positionLogged[i] = true; // Mark as logged
                        }
                    }
                    else
                    {
                        positionLogged[i] = false; // Reset if they are no longer aligned
                    }
                }

                // Check alignment status for the current pair
                if (!ArePositionsEqual(sockets[i].transform.position, books[i].transform.position))
                {
                    allAligned = false; // If one pair is not aligned, set flag to false
                }
            }
        }

        // Check victory condition
        if (allAligned && !victoryMessageDisplayed)
        {
            Debug.Log("Victory! All books and sockets are aligned.");
            victoryMessageDisplayed = true; // Prevent repeated victory messages
        }
        else if (!allAligned)
        {
            victoryMessageDisplayed = false; // Reset victory message if alignment is broken
        }
    }

    // Helper function to check if two positions are close enough
    bool ArePositionsEqual(Vector3 pos1, Vector3 pos2, float tolerance = 0.1f)
    {
        return Vector3.Distance(pos1, pos2) < tolerance;
    }
}
