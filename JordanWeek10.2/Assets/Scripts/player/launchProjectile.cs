using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float launchVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject cannonball = (Instantiate(projectile, transform.position, transform.rotation));
            cannonball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));

            Destroy(cannonball, 4);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

            Debug.Log("HIT");
        }

    }
}
