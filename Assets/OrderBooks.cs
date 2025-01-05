using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class OrderBooks : MonoBehaviour
{
    public XRSocketInteractor basicsocket;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basicsocket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
