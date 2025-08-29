using UnityEngine;
using System;

public class Screenshot : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject saveButton;
    public GameObject paintingsParent;
    public GameObject BG;
    public GameObject EndDrawingSeshButtontton;
    
    
   public void TakeScreenshot()
   {
       //in the furture, i want the user to be able to input a name
       string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
       string filename = Application.dataPath + "/Resources/Screenshots/" + "screenshot_" + timestamp + ".png";
       UICanvas.SetActive(false);
       ScreenCapture.CaptureScreenshot(filename, 5);
       Debug.Log("Screenshot taken: " + filename);
       //save to screenshots folder
       EndDrawingSeshButtontton.SetActive(true);
   }

   public void endDrawingSession()
   {
       //UICanvas.SetActive(true);
       saveButton.SetActive(false);
       //delete all children of paintings parent
       foreach (Transform child in paintingsParent.transform)
       {
           Destroy(child.gameObject);
       }
       BG.SetActive(false);
   }
}
