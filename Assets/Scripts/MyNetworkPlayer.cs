using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkPlayer :NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string _displayName = "Missing Name";
    [SyncVar]
    [SerializeField]
    private Color _playerColor;


    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        _displayName = newDisplayName;
    }

    [Server]
    public void SetColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        _playerColor = new Color(r, g, b);
    }
}
