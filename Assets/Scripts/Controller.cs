using UnityEngine;
using UnityEngine.UI;

public class Controller : GameManager
{
    GameObject currentShape;
    int shapeIndex = 0;

    private void Awake()
    {
        currentShape = shapes[shapeIndex];    
    }

    public void ChangeShape(Button button)
    {
        currentShape.gameObject.SetActive(false);
        if(button.name == "right")
        {
            if(shapeIndex + 1 >= shapes.Length)
            {
                shapeIndex = 0;
                currentShape = shapes[shapeIndex];
            }
            else
            {
                currentShape = shapes[++shapeIndex];
            }
        }
        else if(button.name =="left")
        {
            if(shapeIndex - 1 < 0)
            {
                shapeIndex = shapes.Length - 1;
                currentShape = shapes[shapeIndex];
            }
            else
            {
                currentShape = shapes[--shapeIndex];
            }
        } 

        SetNewShape();      
    }

    private void SetNewShape()
    {
        ResetCount();
        currentShape.SetActive(true);
    }
}
