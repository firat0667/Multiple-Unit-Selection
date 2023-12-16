using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    // Start is called before the first frame update
    Camera myCam;
    [SerializeField]
    RectTransform boxVisual;

    Rect selectionBox;
    Vector2 startPosition;
    Vector2 EndPosition;
    void Start()
    {
        myCam=Camera.main;
        startPosition = Vector2.zero;
        EndPosition = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        // when clicked
        if(Input.GetMouseButtonDown(0))
        {
            startPosition=Input.mousePosition;
            selectionBox = new Rect();
        }
         // when dragging
        if(Input.GetMouseButton(0))
        {
            EndPosition=Input.mousePosition;
            DrawVisual() ;
            DrawSelection();
        }
        // when release click
        if(Input.GetMouseButtonUp(0)) 
        { 
            SelectUnits();
            startPosition=Vector2.zero;
            EndPosition=Vector2.zero;
            DrawVisual();
        }
    }
    private void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = EndPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize= new Vector2(Mathf.Abs(boxStart.x-boxEnd.x),Mathf.Abs(boxStart.y-boxEnd.y));
        boxVisual.sizeDelta = boxSize;
    }
    void DrawSelection()
    {
        // do x Calculations
        if (Input.mousePosition.x < startPosition.x)
        {
            // dragging left
           selectionBox.xMin = Input.mousePosition.x;
           selectionBox.xMax= startPosition.x;
        }
        else
        {
            //dragging right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        if(Input.mousePosition.y < startPosition.y)
        {
            //dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            //dragging up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
        // do Y Calculations
    }
    void SelectUnits()
    {
        //loop thru all the units
        foreach (var item in UnitSelections.Instance.UnitList)
        {
            // if unit is within the bounds of the selectin rect
            if (selectionBox.Contains(myCam.WorldToScreenPoint(item.transform.position)))
            {
                UnitSelections.Instance.DragSelect(item);
            }
        }
    }
}
