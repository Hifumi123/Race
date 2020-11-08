using UnityEngine;

public class ElevatorUp : MonoBehaviour
{
    public Rigidbody passenger;

    public float speed = 10;

    public float maxHeight = 38;

    private bool m_IsRising = false;

    private Vector3 m_UpVelocity = Vector3.zero;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == passenger)
            m_IsRising = true;
    }

    void Update()
    {
        if (m_IsRising)
        {
            passenger.constraints = RigidbodyConstraints.FreezeRotation;

            m_UpVelocity.y = speed;

            transform.parent.Translate(m_UpVelocity * Time.deltaTime);
        }

        if (transform.parent.position.y > maxHeight)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, maxHeight, transform.parent.position.z);

            m_IsRising = false;

            passenger.constraints = RigidbodyConstraints.None;
        }
    }
}
