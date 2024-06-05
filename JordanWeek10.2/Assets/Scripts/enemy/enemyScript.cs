using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    
    public int points;

    [SerializeField] float moveSpeed;

    [Header("Projectiles")]
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPos1;

    spawnManager spawnManager;

    bool canShoot = true;

    [Header("Health")]
    public int health;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.Instance.Score += points;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShootZone" && canShoot)
        {
            StartCoroutine(FireCannon());
        } 
    }


    IEnumerator FireCannon()
    {

        Destroy(Instantiate(projectile, spawnPos1.position, projectile.transform.rotation), 6);
        canShoot = false;
        yield return new WaitForSeconds(5);
        canShoot = true;
        
    }

    void DestroyBounds()
    {
        if (transform.position.z < -250)
        {
            Destroy(gameObject);
        }
    }
}
