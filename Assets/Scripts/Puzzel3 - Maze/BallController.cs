using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BallController : XRGrabInteractable
{
    public float forceMultiplier = 1f; // Adjust the force applied
    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        // Get the interactor's forward direction
        Transform interactorTransform = args.interactorObject.transform;
        Vector3 forceDirection = interactorTransform.forward;

        // Apply force to the ball
        rb.AddForce(forceDirection * forceMultiplier, ForceMode.Force);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        // Optional: Add behavior when interaction ends (e.g., stop movement)
    }
}
