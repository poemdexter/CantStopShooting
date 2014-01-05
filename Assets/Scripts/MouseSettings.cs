using UnityEngine;
using System.Collections;

public class MouseSettings : MonoBehaviour
{
    public Texture2D cursorTexture;
    
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); // custom cursor
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); // custom cursor
        }
    }
}