using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPunch : MonoBehaviour
{
    public float punchForce = 10.0f;
    public GameObject targetObject; 
    public float punchRange = 2.0f; 

    private Transform playerTransform;

    private void Start()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player1").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformPunch();
        }
    }

    private void PerformPunch()
    {
        if (targetObject != null && playerTransform != null)
        {
           
            float distanceToTarget = Vector3.Distance(playerTransform.position, targetObject.transform.position);

            
            if (distanceToTarget <= punchRange)
            {
                
                Rigidbody rb = targetObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    
                    rb.AddForce(transform.forward * punchForce, ForceMode.Impulse);
                }
            }
        }
    }
}

