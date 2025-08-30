using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public string selectedPainting;

    public GameObject paintingCanvas;

    public GameObject bigPainting;

    public GameObject DoneButton;

    public GameObject PaintingUI;

    public GameObject BG;
    public GameObject IntroCanvas;
    public DialogueRunner dialogueRunner;
    public GameObject EndCanvas;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //play text to start the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("EndCanvas")]
    public void OpenPaintingCanvas()
    {
        EndCanvas.SetActive(true);
    }

    public void ChoosePaining()
    {
        
        //click on a canvas and get it the name of the canvas
        selectedPainting = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Selected Painting: " + selectedPainting);
        paintingCanvas.SetActive(false);
        //find object with selected painting name and disable it
        if (paintingCanvas.transform.childCount > 0)
        {
            foreach (var children in paintingCanvas.GetComponentsInChildren<Transform>(true))
            {
                if (children.gameObject.name == selectedPainting)
                {
                    children.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.Log("No children found in painting canvas");
        }
        //instantiate the big painting
        Sprite PaintingSprite = Resources.Load<Sprite>("Sprites/" + selectedPainting + "Large");
        bigPainting.GetComponent<Image>().sprite= PaintingSprite;
        bigPainting.SetActive(true);
        DoneButton.SetActive(true);
        
    }
    
    public void DonePainting()
    {
        bigPainting.SetActive(false);
        DoneButton.SetActive(false);
        PaintingUI.SetActive(true);
        //start timer
        FindObjectOfType<LineGenerator>().timerOn = true;
        FindObjectOfType<LineGenerator>().timerDuration = 30f;
        FindObjectOfType<LineGenerator>().canDraw = true;
        BG.SetActive(true);
        
    }
    
    [YarnCommand("openIntroCanvas")]
    public void OpenIntroCanvas()
    {
        
        IntroCanvas.SetActive(true);
    }
    
    public void CloseIntroCanvas()
    {
        
        IntroCanvas.SetActive(false);
        paintingCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
