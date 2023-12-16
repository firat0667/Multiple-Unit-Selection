using System;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    public GameObject GroundMarker;

    public LayerMask Clickable;
    public LayerMask Ground;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray=_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit,Mathf.Infinity,Clickable)) 
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeSelectAll();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastHit;
            Ray ray =_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out raycastHit, Mathf.Infinity, Ground))
            {
                GroundMarker.transform.position = raycastHit.point;
                GroundMarker.SetActive(false);
                GroundMarker.SetActive(true);
            }
        }
    }
}
