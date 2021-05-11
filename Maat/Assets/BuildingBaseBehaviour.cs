using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBaseBehaviour : MonoBehaviour
{
    public Transform towerPosition;
    public GameObject tower;

    bool hasTower;

    private void Start()
    {
        hasTower = false;
    }

    public void BuildTower()
    {
        if (!hasTower)
        {
            Instantiate(tower, towerPosition.position, towerPosition.rotation);

            hasTower = true;
        }
    }
}
