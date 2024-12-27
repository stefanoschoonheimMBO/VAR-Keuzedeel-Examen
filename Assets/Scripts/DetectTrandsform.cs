using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrandsform : MonoBehaviour
{
    public GameObject trackedObject;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private Vector3 lastScale;

    [SerializeField] private float startRotation;
    [SerializeField] private float endRotation;
    [SerializeField] public GameObject item1;
    [SerializeField] public GameObject item2;
    [SerializeField] public GameObject item3;
    //[SerializeField] public GameObject item4;

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
        if (trackedObject.transform.position != lastPosition || trackedObject.transform.rotation != lastRotation || trackedObject.transform.localScale != lastScale)
        {
            Debug.Log("Transform has changed!");
            // Perform some action in response to the change
        }

        // Convert rotation to Euler angles to check the Z rotation in degrees between 2 values
        float zRotation = trackedObject.transform.eulerAngles.z;
        if (zRotation >= startRotation && zRotation <= endRotation)
        {
            Debug.Log("Z rotation is between 40 and 50 degrees");
        }

        lastPosition = trackedObject.transform.position;
        lastRotation = trackedObject.transform.rotation;
        lastScale = trackedObject.transform.localScale;
    }
}