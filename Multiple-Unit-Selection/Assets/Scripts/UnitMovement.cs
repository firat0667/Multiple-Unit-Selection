using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Camera _camera;
    NavMeshAgent _agent;
    public LayerMask GroundLayerMask;
    void Start()
    {
        _camera=Camera.main;
        _agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        { 
            RaycastHit hit;
            Ray ray=_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit,Mathf.Infinity,GroundLayerMask)) 
            { 
                if(UnitSelections.Instance.UnitsSelected.Contains(gameObject))
                _agent.SetDestination(hit.point);
            }
        }
    }
}
