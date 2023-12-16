using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitSelections.Instance.UnitList.Add(this.gameObject);
    }
    private void OnDestroy()
    {
        UnitSelections.Instance.UnitList.Remove(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
