using UnityEngine;
using System;
using System.Collections;

public class Screenshot : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject saveButton;
    public GameObject paintingsParent;
    public GameObject BG;
    public GameObject EndDrawingSeshButtontton;
    GameManager gameManager;
    public int screenshotCount = 0;


    private IEnumerator SetUpScreenshot()
    {
        //wait for end of frame
        yield return new WaitForEndOfFrame();
        //in the furture, i want the user to be able to input a name
        string filename = Application.dataPath + "/MyCoolAndAwsomePainting"+ screenshotCount + ".png";
        // "/Resources/Screenshots/" + 
        
        ScreenCapture.CaptureScreenshot(filename, 5);
        Debug.Log("Screenshot taken: " + filename);
        //save to screenshots folder
        
        
    }
    
   public void TakeScreenshot()
   { 
       UICanvas.SetActive(false);
         StartCoroutine(SetUpScreenshot());
         EndDrawingSeshButtontton.SetActive(true);
         screenshotCount++;
       
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
       EndDrawingSeshButtontton.SetActive(false);
       gameManager = FindObjectOfType<GameManager>();
       gameManager.paintingCanvas.SetActive(true);
         
   }
}
