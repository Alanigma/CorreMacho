using Game;
using UnityEngine;

public class PauseHUD : MonoBehaviour
{

    public CanvasGroup m_PauseCanvas;
    private bool m_IsPaused = false;

    private void OnEnable()
    {

        GameSettingsObserver.OnPauseButtonClick += PauseGame;

    }

    private void OnDisable()
    {

        GameSettingsObserver.OnPauseButtonClick -= PauseGame;

    }

    public void CallPause() => ObserverPause.CallPause();

    public void CallPauseClick()
    {
        GameSettingsObserver.PauseButtonClick();
    }

    private void PauseGame()
    {

        //

    }

}
