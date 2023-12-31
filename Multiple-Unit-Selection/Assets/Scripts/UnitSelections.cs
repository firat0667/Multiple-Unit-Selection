using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> UnitList=new List<GameObject>();
    public List<GameObject>UnitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance {  get { return _instance; } }
   void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
    public void ClickSelect(GameObject unitToAdd)
    {
        DeSelectAll();
        UnitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!UnitsSelected.Contains(unitToAdd))
        {
            UnitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            UnitsSelected.Remove(unitToAdd);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if (!UnitsSelected.Contains(unitToAdd))
        {
            UnitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }
    public void DeSelectAll()
    {
        foreach (var unit in UnitsSelected) 
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        UnitsSelected.Clear();
    }
    public void DeSelect(GameObject unitToDeselect) 
    { 

    }

}
