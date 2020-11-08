using System;
using System.Collections.Generic;
using UnityEngine;

public class RobotRagdoll : MonoBehaviour
{
    public bool isRagdoll = false;

    public Rigidbody[] allColliderRigidbodys;

    private Animator m_Animator;

    private Rigidbody m_Rigidbody;

    private CapsuleCollider m_CapsuleCollider;

    private List<Rigidbody> m_RList;

    private List<Collider> m_CList;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

        m_Rigidbody = GetComponent<Rigidbody>();

        m_CapsuleCollider = GetComponent<CapsuleCollider>();

        m_RList = new List<Rigidbody>();
        m_CList = new List<Collider>();

        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            if (rb == m_Rigidbody)
                continue;

            rb.isKinematic = true;
            m_RList.Add(rb);

            Collider c = rb.GetComponent<Collider>();
            c.isTrigger = true;
            m_CList.Add(c);
        }
    }

    private void EnableRagdoll()
    {
        foreach (Rigidbody rb in m_RList)
            rb.isKinematic = false;

        foreach (Collider c in m_CList)
            c.isTrigger = false;

        m_Rigidbody.isKinematic = true;
        m_CapsuleCollider.isTrigger = true;

        m_Animator.enabled = false;
    }

    private void DisableRagdoll()
    {
        foreach (Rigidbody rb in m_RList)
            rb.isKinematic = true;

        foreach (Collider c in m_CList)
            c.isTrigger = true;

        m_Rigidbody.isKinematic = false;
        m_CapsuleCollider.isTrigger = false;

        m_Animator.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (Array.IndexOf(allColliderRigidbodys, rb) == -1)
            return;

        isRagdoll = true;
    }

    void Update()
    {
        if (isRagdoll)
            EnableRagdoll();
    }
}
