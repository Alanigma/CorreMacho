using UnityEngine;

public class PauseHUD : MonoBehaviour
{

    public CanvasGroup m_PauseCanvas;
    private bool m_IsPaused = false;

    private void OnEnable()
    {

        ObserverPause.OnPause += PauseGame;

    }

    private void OnDisable()
    {

        ObserverPause.OnPause -= PauseGame;

    }

    public void CallPause() => ObserverPause.CallPause();

    private void PauseGame()
    {

        if (Time.timeScale == 0 && !m_IsPaused) return;

        m_IsPaused = !m_IsPaused;

        if (m_IsPaused)
        {
            m_PauseCanvas.alpha = 1;
            m_PauseCanvas.interactable = true;
            m_PauseCanvas.blocksRaycasts = true;
            Time.timeScale = 0;
        }
        else
        {
            m_PauseCanvas.alpha = 0;
            m_PauseCanvas.interactable = false;
            m_PauseCanvas.blocksRaycasts = false;
            Time.timeScale = 1;
        }

    }

}
