using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed = 1;

    public float turnSpeed = 20;

    public bool isCurrent = false;

    private Animator m_Animator;

    private Rigidbody m_Rigidbody;

    private RobotRagdoll m_Ragdoll;

    private bool m_IsMoving = false;

    private bool m_IsJumping = false;

    private Vector3 m_Movement = Vector3.zero;

    private Quaternion m_Rotation = Quaternion.identity;

    private Vector3 m_UpVelocity = Vector3.zero;

    private float m_RayOriginUp = 0.1f;

    private float m_OnTheGroundThreshold = 0.2f;

    void Start()
    {
        m_Animator = GetComponent<Animator>();

        m_Rigidbody = GetComponent<Rigidbody>();

        m_Ragdoll = GetComponent<RobotRagdoll>();
    }

    private bool IsStandingOnTheGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * m_RayOriginUp, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.distance - m_RayOriginUp) < m_OnTheGroundThreshold)
            return true;

        return false;
    }

    void FixedUpdate()
    {
        if (isCurrent && !m_Ragdoll.isRagdoll)
        {
            m_IsJumping = !IsStandingOnTheGround();

            m_Animator.SetBool("IsJump", m_IsJumping);

            if (!m_IsJumping && m_UpVelocity.y < 0)
                m_UpVelocity.y = 0;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            m_IsMoving = !Mathf.Approximately(h, 0) || !Mathf.Approximately(v, 0);

            m_Animator.SetBool("IsRun", m_IsMoving);

            if (m_IsMoving && !m_IsJumping)
            {
                m_Movement.Set(h, 0, v);
                m_Movement.Normalize();

                Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0);
                m_Rotation = Quaternion.LookRotation(desiredForward);
            }

            if (Input.GetButton("Jump") && !m_IsJumping)
            {
                m_IsJumping = true;

                m_Animator.SetBool("IsJump", m_IsJumping);

                if (m_IsMoving)
                {
                    Vector3 acceleration = new Vector3(m_Movement.x, 0, m_Movement.z) * 80;
                    acceleration.y = 200;

                    m_Rigidbody.AddForce(acceleration, ForceMode.Acceleration);
                }
                else
                    m_Rigidbody.AddForce(new Vector3(0, 200, 0), ForceMode.Acceleration);
            }

            if (!m_IsMoving && !m_IsJumping)
            {
                m_Rigidbody.velocity = Vector3.zero;
                m_Rigidbody.angularVelocity = Vector3.zero;

                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
        }
    }

    private void OnAnimatorMove()
    {
        if (isCurrent && !m_Ragdoll.isRagdoll && m_IsMoving)
        {
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude * speed);
            m_Rigidbody.MoveRotation(m_Rotation);
        }
    }
}
