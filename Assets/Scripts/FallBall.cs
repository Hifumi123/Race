using System;
using UnityEngine;

public class FallBall : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = true;
    }

    public void Fall()
    {
        m_Rigidbody.isKinematic = false;
    }

    void Update()
    {
        
    }
}
