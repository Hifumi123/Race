using Cinemachine;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public GameObject robot;

    public GameObject car;

    public CinemachineVirtualCameraBase robotCamera;

    public CinemachineVirtualCameraBase carCamera;

    private GameObject m_CurrentCharacter;

    public void changeCurrentCharacterAsRobot()
    {
        m_CurrentCharacter = robot;
        m_CurrentCharacter.GetComponent<RobotMovement>().isCurrent = true;

        car.GetComponent<SportsCarController>().isCurrent = false;

        carCamera.VirtualCameraGameObject.SetActive(false);
        robotCamera.VirtualCameraGameObject.SetActive(true);
    }

    public void changeCurrentCharacterAsCar()
    {
        m_CurrentCharacter = car;
        m_CurrentCharacter.GetComponent<SportsCarController>().isCurrent = true;

        robot.GetComponent<RobotMovement>().isCurrent = false;

        robotCamera.VirtualCameraGameObject.SetActive(false);
        carCamera.VirtualCameraGameObject.SetActive(true);
    }

    void Start()
    {
        changeCurrentCharacterAsRobot();
    }

    void Update()
    {

    }

    public GameObject GetCurrentCharacter()
    {
        return m_CurrentCharacter;
    }
}
