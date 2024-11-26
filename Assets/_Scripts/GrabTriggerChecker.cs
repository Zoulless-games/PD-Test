using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GrabTriggerChecker : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics; // Specify Left/Right controller
    private InputDevice controllerDevice;
    public bool isGripPressed;

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
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Drum") && isGripPressed)
        {
            other.transform.position = transform.position;
        }
    }
}
