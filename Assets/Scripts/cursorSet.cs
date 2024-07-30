using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorSet : MonoBehaviour
{
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        //Texture2D cursorTexture = Resources.Load<Texture2D>("CursorTexture"); // Load your custom cursor texture
        // Vector2 cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2); // Set the hotspot at the center of the texture

        // Vector3 mousePosition = Input.mousePosition;
        //  mousePosition.z = Camera.main.nearClipPlane; // Set the Z coordinate to the camera's near clip plane distance
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Cursor.SetCursor(cursorTexture, Vector3.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {



        }

    }
}
