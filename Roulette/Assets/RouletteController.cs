using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotationSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.rotationSpeed = 10;
        }

        transform.Rotate(0, 0, this.rotationSpeed);

        if (this.rotationSpeed > 0.5)
        {
            this.rotationSpeed *= 0.96f;
        }
        else
        {
            this.rotationSpeed = 0;
        }

    }
}
