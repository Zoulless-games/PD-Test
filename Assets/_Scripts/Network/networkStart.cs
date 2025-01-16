using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class networkStart : MonoBehaviour
{
    public void StartHost()
    {
        if (NetworkManager.Singleton.IsConnectedClient) return;
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host started!");
    }

    public void StartClient()
    {
        if (NetworkManager.Singleton.IsConnectedClient) return;
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client started!");
    }
}
