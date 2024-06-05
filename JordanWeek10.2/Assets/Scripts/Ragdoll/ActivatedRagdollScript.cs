using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedRagdollScript : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    Rigidbody[] ragdollRB;

    [SerializeField] GameObject Eva;
    bool isRagdoll;
    // Start is called before the first frame update
    void Awake()
    {
        ragdollRB = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleRagdoll(bool isRagdollChar)
    {
        isRagdoll = !isRagdollChar;
        myCollider.enabled = isRagdollChar;

        foreach(Rigidbody ragdollBone in ragdollRB) 
        {
            ragdollBone.isKinematic = isRagdollChar;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannonball")
        {
            ToggleRagdoll(false);
            Debug.Log("Hit");
            StartCoroutine(ResetRagdoll());
        }
    }

    IEnumerator ResetRagdoll()
    {
        Debug.Log("Resetting Ragdoll");
        yield return new WaitForSeconds(3);
        ToggleRagdoll(true);
        Instantiate(Eva, GenerateSpawnPosition(), transform.rotation);
        Destroy(gameObject);
        Debug.Log("Respawned Eva");
        
        
    }



    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(40, 58);
        float spawnPosZ = Random.Range(-83, -32);
        Vector3 randomPos = new Vector3(spawnPosX, 10.1f, spawnPosZ);
        return randomPos;
    }
}
