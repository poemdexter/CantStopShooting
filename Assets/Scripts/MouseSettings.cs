using UnityEngine;
using System.Collections;

public class MouseSettings : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 cursorOffset;
    
    void Start()
    {
        cursorOffset = new Vector2((float)cursorTexture.width / 2.0f, (float)cursorTexture.height / 2.0f); 
        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto); // custom cursor
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto); // custom cursor
        }
    }
}