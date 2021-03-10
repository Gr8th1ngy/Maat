using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Image background;
    public Image filledPart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHealth(float healthFraction)
    {
        filledPart.rectTransform.localScale = new Vector3(healthFraction, 1, 1);

        if (healthFraction <= 1)
        {
            filledPart.enabled = true;
            background.enabled = true;
        }
        else
        {
            filledPart.enabled = false;
            background.enabled = false;
        }
    }
}
