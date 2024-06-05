using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimCannonScript : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float xRotationClamp = 24;

    float xRange = 24;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimCannon();
    }

    void AimCannon()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
    }

    void ClampRotation()
    {
        if (transform.rotation.x > 24)
        {
            
        }
    }
}
