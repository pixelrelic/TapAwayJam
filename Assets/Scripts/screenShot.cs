using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShot : MonoBehaviour
{
    private int screenshotCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Check if the space bar (KeyCode.Space) is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenshot();
        }
    }

    void TakeScreenshot()
    {
        // Define the screenshot file name with a timestamp
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

        // Capture the screen and save it as a PNG image
        ScreenCapture.CaptureScreenshot(fileName);

        // Increase the screenshot counter
        screenshotCount++;

        Debug.Log("Screenshot saved as " + fileName);
    }
}