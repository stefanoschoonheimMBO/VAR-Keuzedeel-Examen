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

    private bool isCorrectRotation = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = trackedObject.transform.position;
        lastRotation = trackedObject.transform.rotation;
        lastScale = trackedObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        OnTransformChanged();
    }

    void OnTransformChanged()
    {
        // Convert rotation to Euler angles to check the Z rotation in degrees between 2 values
        float zRotation = trackedObject.transform.eulerAngles.z;

        // Normalize rotation to ensure it's within 0-360
        //zRotation = (zRotation + 360) % 360;

        // Check if rotation is within the correct range
        isCorrectRotation = (zRotation >= startRotation && zRotation <= endRotation);

        // Notify the Puzzle1Check script of the rotation status
        if (puzzleChecker != null)
        {
            puzzleChecker.UpdateRotationStatus(this.gameObject, isCorrectRotation);
        }

        // Debug output
        if (isCorrectRotation)
        {
            Debug.Log($"{gameObject.name} is correctly rotated.");
        }

        // Update previous transform states
        lastPosition = trackedObject.transform.position;
        lastRotation = trackedObject.transform.rotation;
        lastScale = trackedObject.transform.localScale;
    }
}