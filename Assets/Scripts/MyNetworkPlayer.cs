using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer :NetworkBehaviour
{
    [SyncVar(hook = nameof(HandleDisplayNameUpdate))]
    [SerializeField]
    private string _displayName = "Missing Name";
    [SyncVar(hook = nameof(HandleDisplayColorUpdate))]
    [SerializeField]
    private Color _playerColor;
    [SerializeField]
    private TMP_Text _displayNameText = null;
    [SerializeField]
    private Renderer _displayColorRenderer = null;

    #region Server
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

    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        SetDisplayName(newDisplayName);
        RpcSetNewName(newDisplayName);
    }
    #endregion
    #region Client
    private void HandleDisplayColorUpdate(Color oldColor, Color newColor)
    {
        _displayColorRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void HandleDisplayNameUpdate(string oldName, string newName)
    {
        _displayNameText.text = _displayName;
    }

    [ContextMenu("Set My Name")]
    private void SetMyName()
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc]
    private void RpcSetNewName(string newName)
    {
        Debug.Log($"{newName}");
    }
    #endregion
}
