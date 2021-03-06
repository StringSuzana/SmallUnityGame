using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    [SerializeField]
    private SceneSettings sceneSettings;

    [SerializeField]
    private Texture2D customCursor;

    private void OnMouseEnter()
    {
        ShowCustomCursor();
    }
    private void OnMouseExit()
    {
        sceneSettings.ResetCursor();
    }
    public void ShowCustomCursor()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
