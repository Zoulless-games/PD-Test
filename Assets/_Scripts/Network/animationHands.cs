using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class animationHands : MonoBehaviour
{
    public InputActionProperty grab;
    public InputActionProperty pinch;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float grabValue = grab.action.ReadValue<float>();
        float pinchValue = pinch.action.ReadValue<float>();

        anim.SetFloat("grab", grabValue);
        anim.SetFloat("pinch", pinchValue);
    }
}
