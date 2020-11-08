using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Transform center;

    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Rigidbody.centerOfMass = center.localPosition;
    }

    void Update()
    {
        
    }
}
