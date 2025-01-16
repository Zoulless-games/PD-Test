using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Unity.Netcode;

public class networkPlayer : NetworkBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Transform head;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    private void Update()
    {
        if (IsOwner)
        {
            root.position = VRigNetworkPlayer.instance.root.position;
            root.rotation = VRigNetworkPlayer.instance.root.rotation;

            head.position = VRigNetworkPlayer.instance.head.position;
            head.rotation = VRigNetworkPlayer.instance.head.rotation;

            leftHand.position = VRigNetworkPlayer.instance.leftHand.position;
            leftHand.rotation = VRigNetworkPlayer.instance.leftHand.rotation;

            rightHand.position = VRigNetworkPlayer.instance.rightHand.position;
            rightHand.rotation = VRigNetworkPlayer.instance.rightHand.rotation;
        }
    }
}
