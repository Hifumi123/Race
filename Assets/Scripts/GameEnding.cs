using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public MainCharacter character;

    public Canvas gameEnding;

    public Timer timer;

    private CanvasGroup cg;

    private Text text;

    private bool m_IsPlayerAtExit = false;

    private bool m_IsPlayerLoss = false;

    private RobotRagdoll m_Ragdoll;

    private float m_LostLimit = -1.5f;

    private float m_Timer = 0;

    private float m_GameEndingDelayTime = 2;

    void Start()
    {
        cg = gameEnding.GetComponent<CanvasGroup>();

        text = gameEnding.GetComponentInChildren<Text>();

        m_Ragdoll = character.robot.GetComponent<RobotRagdoll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == character.GetCurrentCharacter().GetComponent<Rigidbody>())
            m_IsPlayerAtExit = true;
    }

    private void PlayerLoss()
    {
        m_IsPlayerLoss = true;
    }

    private void ShowGameEndingView(string result)
    {
        text.text = result;

        timer.Stop();

        cg.alpha = 1;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            ExitGame();

        if (Input.GetKey(KeyCode.R))
            RestartGame();

        if (m_Ragdoll.isRagdoll || character.GetCurrentCharacter().transform.position.y < m_LostLimit)
            PlayerLoss();

        if (m_IsPlayerAtExit)
            ShowGameEndingView("恭喜你，顺利通关！\n用时：" + timer.GetTotalTime() + "秒。");
        else if (m_IsPlayerLoss)
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_GameEndingDelayTime)
                ShowGameEndingView("很遗憾，你失败了！");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
