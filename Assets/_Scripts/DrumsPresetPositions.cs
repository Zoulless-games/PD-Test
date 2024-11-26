using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumsPresetPositions : MonoBehaviour
{
    public Preset[] presets;
    public GameObject[] drums;
    public GameObject UIMenu;

    public LineRenderer lineRendererRightController;
    public XRInteractorLineVisual xrInteractorLineVisualRightController;

    public void isMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        if (!UIMenu.activeSelf)
        {
            UIMenu.SetActive(true);
            lineRendererRightController.enabled = true;
            xrInteractorLineVisualRightController.enabled = true;
        }
        else
        {
            UIMenu.SetActive(false);
            lineRendererRightController.enabled = false;
            xrInteractorLineVisualRightController.enabled = false;
        }
    }

    public void MoveDrumsToPreset(int index)
    {
        for (int i = 0; i < drums.Length; i++)
        {
            drums[i].transform.localPosition = presets[index].positions[i];
            drums[i].transform.localEulerAngles = presets[index].rotations[i];
        }
    }
}

[System.Serializable]
public class Preset
{
    [SerializeField]
    public Vector3[] positions;
    public Vector3[] rotations;
}
