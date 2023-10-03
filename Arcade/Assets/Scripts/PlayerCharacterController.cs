using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private ConfigurableJoint hipJoint;
    [SerializeField] private Rigidbody hip;

    [SerializeField] private Animator targetAnimator;

    private bool walk = false;
    private bool punch = false;
    
    void Update()
    {
        CheckMove();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            this.hipJoint.targetRotation = Quaternion.Euler(0f, targetAngle + 100, 0f);

            this.hip.AddForce(direction * this.speed);

            this.walk = true;
        }
        else
        {
            this.walk = false;
        }

        this.targetAnimator.SetBool("Walk", this.walk);
        this.targetAnimator.SetBool("Punch", this.punch);
    }

    void CheckMove()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.punch = true;
        }
        else
        {
            this.punch = false;
        }
    }
 
}

