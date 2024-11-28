using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTriggerChecker : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics; // Specify Left/Right controller
    private InputDevice controllerDevice;
    public bool isGripPressed;
    private bool hasDrum;
    private GameObject drum;

    void Start()
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            controllerDevice = devices[0];
            Debug.Log("Controller found: " + controllerDevice.name);
        }
    }

    void Update()
    {
        if (controllerDevice.isValid)
        {
            if (controllerDevice.TryGetFeatureValue(CommonUsages.gripButton, out isGripPressed) && isGripPressed)
            {
                Debug.Log("Grab trigger is pressed!");
            }
            else drum = null;
        }

        MoveDrum();
    }

    public void OnCollisonStay(Collision other)
    {
        if (other.transform.CompareTag("Drum") && isGripPressed && drum == null)
        {
            drum = other.transform.root.transform.gameObject;
        }
    }

    public void MoveDrum()
    {
        if (drum == null) return;
        drum.transform.position = transform.position;
        drum.transform.rotation = transform.rotation;
    }
}
