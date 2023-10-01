using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCopyLimb : MonoBehaviour
{
    [SerializeField] private Transform targetLimbOther;
    private ConfigurableJoint m_ConfigurableJointOther;

    Quaternion targetInitialRotationOther;

    void Start()
    {
        this.m_ConfigurableJointOther = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotationOther = this.targetLimbOther.transform.localRotation;
    }

    private void FixedUpdate()
    {
        this.m_ConfigurableJointOther.targetRotation = CopyRotation();
    }

    private Quaternion CopyRotation()
    {
        return Quaternion.Inverse(this.targetLimbOther.localRotation) * this.targetInitialRotationOther;
    }
}
