using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTransform : MonoBehaviour
{
    public GameObject trackedObject;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private Vector3 lastScale;

    [SerializeField] private float startRotation;
    [SerializeField] private float endRotation;

    // Reference to Puzzle1Check script
    public Puzzle1Check puzzleChecker;

    // Reference to AudioSource
    private AudioSource audioSource;

    private bool isCorrectRotation = false;
    private bool hasPlayedSound = false; // To avoid replaying sound repeatedly

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
        OnTransformChanged();
    }

    void OnTransformChanged()
    {
        // Convert rotation to Euler angles to check the Y rotation in degrees between 2 values
        float yRotation = trackedObject.transform.eulerAngles.y;

        // Normalize rotation to ensure it's within 0-360
        //zRotation = (zRotation + 360) % 360;

        // Check if rotation is within the correct range
        isCorrectRotation = (yRotation >= startRotation && yRotation <= endRotation);

        // Notify the Puzzle1Check script of the rotation status
        if (puzzleChecker != null)
        {
            puzzleChecker.UpdateRotationStatus(this.gameObject, isCorrectRotation);
        }

        // Play sound if correctly rotated and sound hasn't been played
        if (isCorrectRotation && !hasPlayedSound)
        {
            Debug.Log($"{gameObject.name} is correctly rotated.");

            if (audioSource != null)
            {
                audioSource.Play();
                hasPlayedSound = true;
            }
        }
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
