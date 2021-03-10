using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationBehaviour : MonoBehaviour
{
    public GameObject destinationPoint1;
    public GameObject destinationPoint2;

    Ray destinationRay;
    float destinationRayLength;

    private void Awake()
    {
        References.destination = this;
        Vector3 destinationRayDirection = destinationPoint2.transform.position - destinationPoint1.transform.position;
        destinationRay = new Ray(destinationPoint1.transform.position, destinationRayDirection);
        destinationRayLength = destinationRayDirection.magnitude;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetDestinationPoint()
    {
        // Give a random point in the ray
        float randomDestinationPointDistance = Random.Range(0f, destinationRayLength);
        Vector3 retVal = destinationRay.GetPoint(randomDestinationPointDistance);
        return retVal;
    }
}
