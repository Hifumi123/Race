using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;

    private float m_Time = 0;

    private string m_Unit = "s ";

    private bool m_IsRunning = true;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (m_IsRunning)
        {
            m_Time += Time.deltaTime;

            text.text = m_Time + m_Unit;
        }
    }

    public float GetTotalTime()
    {
        return m_Time;
    }

    public void Stop()
    {
        m_IsRunning = false;
    }
}
