using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("BuildingBase"))
            {
                var buildingBase = hit.collider.GetComponent<BuildingBaseBehaviour>();

                if (buildingBase)
                {
                    buildingBase.BuildTower();
                }
            }
        }
    }
}
