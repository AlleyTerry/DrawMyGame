using TMPro;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public bool canDraw = true;
    Line activeLine;
    public float timerDuration; // Duration of the timer in seconds
    public TextMeshProUGUI timerText;
    public bool timerOn = true;
    public GameObject ParentObjectDrawingFolder;
    public GameObject saveButton;
    
    void Start()
    {
        timerOn = false;
        canDraw = false;
    }
    // Update is called once per frame
    void Update()
    {


        if (timerOn)
        {
            if (timerDuration > 0 )
            {
                //enable line drawing
                canDraw = true;
                timerDuration -= Time.deltaTime;
                timerText.text = timerDuration.ToString("F0");
            }
            else
            {
                canDraw = false;
                timerText.text = "0";
                timerOn = false;
                saveButton.SetActive(true);
            }
        }
        //when clicking down instantiate a new line
        if (Input.GetMouseButtonDown(0) && canDraw)
        {
            //instatiate line prefab under the game object
            GameObject newLine = Instantiate(linePrefab);
            newLine.transform.parent = ParentObjectDrawingFolder.transform;
            activeLine = newLine.GetComponent<Line>();
        }

        //when mouse button goes up we are done with the line
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }
        

        //get mouse position and update line
        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }

        //change line material based on key press or button press
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //switch line material to material 0
            linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/DefaultBrushMat");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //switch line material to material 1
            linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/GraffitiDraft1");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //switch line material to material 2
            linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/Draft2");
        }
    }

    public void BlackButtonClick()
    {
        linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/DefaultBrushMat");
    }
    public void PurpleButtonClick()
    {
        linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/GraffitiDraft1");
    }

    public void YellowButtonClick()
    {
        linePrefab.GetComponent<LineRenderer>().sharedMaterial = Resources.Load<Material>("BrushesMat/Draft2");
    }
}
