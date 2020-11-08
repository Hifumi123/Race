using UnityEngine;

public class GetIntoTheCar : MonoBehaviour
{
    public Rigidbody passenger;

    public Transform farLand;

    public MainCharacter mainCharacter;

    public FallBall ball;

    private bool m_InArea = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == passenger)
            m_InArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == passenger)
            m_InArea = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (m_InArea && Input.GetKey(KeyCode.T))
        {
            mainCharacter.changeCurrentCharacterAsCar();

            passenger.transform.position = farLand.position;

            ball.Fall();
        }
    }
}
