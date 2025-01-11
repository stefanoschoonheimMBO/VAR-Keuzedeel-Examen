using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VRRotateObject : MonoBehaviour
{
    public Transform pivotPoint; // The point around which the object rotates
    public float rotationSpeed = 100f; // Adjust this for faster/slower rotation

    private bool isBeingRotated = false; // Track whether the user is interacting
    private Transform controller; // Reference to the VR controller

    void Update()
    {
        if (isBeingRotated && controller != null)
        {
            // Calculate rotation based on controller movement
            Vector3 controllerPosition = controller.position;
            Vector3 directionToController = controllerPosition - pivotPoint.position;

            // Compute the angle (you can tweak the axis of rotation as needed)
            float angle = Mathf.Atan2(directionToController.y, directionToController.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void StartRotation(object userController)
    {
        if (userController is XRBaseInteractor interactor)
        {
            // Get the Transform of the VR controller
            controller = interactor.transform;
            isBeingRotated = true;
        }
        else
        {
            Debug.LogError("Invalid userController type passed to StartRotation!");
        }
    }

    public void StopRotation()
    {
        isBeingRotated = false;
        controller = null;
    }
}
