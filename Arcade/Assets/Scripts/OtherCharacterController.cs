using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class OtherCharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private ConfigurableJoint hipJointOther;
    [SerializeField] private Rigidbody hipOther;

    [SerializeField] private Animator targetAnimatorOther;

    private bool canWalk = false;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal2");
        float vertical = Input.GetAxisRaw("Vertical2");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            this.hipJointOther.targetRotation = Quaternion.Euler(0f, targetAngle - 100, 0f);

            this.hipOther.AddForce(direction * this.speed);

            this.canWalk = true;
        }
        else
        {
            this.canWalk = false;
        }

        this.targetAnimatorOther.SetBool("isWalking", this.canWalk);
    }
}
