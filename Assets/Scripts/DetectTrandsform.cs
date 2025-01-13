using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTransform : MonoBehaviour
{
    // References for objects and rotations
    public GameObject trackedObject;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private Vector3 lastScale;

    // Customizable start and end rotation to track
    [SerializeField] private float startRotation;
    [SerializeField] private float endRotation;

    // Bool to check if rotation is correct based on start- / endrotation
    private bool isCorrectRotation = false;

    // Reference to Puzzle1Check script
    public Puzzle1Check puzzleChecker;

    // Reference to AudioSource
    private AudioSource audioSource;

    // To avoid replaying sound repeatedly
    private bool hasPlayedSound = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = trackedObject.transform.position;
        lastRotation = trackedObject.transform.rotation;
        lastScale = trackedObject.transform.localScale;

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Run function
        OnTransformChanged();
    }

    void OnTransformChanged()
    {
        // Convert rotation to Euler angles to based on the Y rotation
        float yRotation = trackedObject.transform.eulerAngles.y;

        // Normalize rotation to ensure it's within 0-360
        //zRotation = (zRotation + 360) % 360;

        // Check if the rotation is within the correct range
        isCorrectRotation = (yRotation >= startRotation && yRotation <= endRotation);

        // Notify the Puzzle1Check script of the rotation status
        if (puzzleChecker != null)
        {
            puzzleChecker.UpdateRotationStatus(this.gameObject, isCorrectRotation);
        }

        // Play sound if correctly rotated and sound hasn't been played yet
        if (isCorrectRotation && !hasPlayedSound)
        {
            Debug.Log($"{gameObject.name} is correctly rotated.");

            // If audioSource exists, play sound
            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true;
            }
        }
        // If the item is not in the correct rotation...
        else if (!isCorrectRotation)
        {
            // Reset sound playback if rotation becomes incorrect
            hasPlayedSound = false;
        }

        // Update previous transform states
        lastPosition = trackedObject.transform.position;
        lastRotation = trackedObject.transform.rotation;
        lastScale = trackedObject.transform.localScale;
    }
}
