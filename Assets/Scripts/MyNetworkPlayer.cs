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

    private void HandleDisplayColorUpdate(Color oldColor, Color newColor)
    {
        _displayColorRenderer.material.SetColor("_BaseColor", newColor);
    }

    private void HandleDisplayNameUpdate(string oldName, string newName)
    {
        _displayNameText.text = _displayName;
    }
}
