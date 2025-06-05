using Game;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseHUD : MonoBehaviour
{

    public GameObject m_PausePanel;

    private void OnEnable()
    {

        UpdatePause();
        InputObserver.OnEscape += OpenOrClose;

    }

    private void OnDisable()
    {

        InputObserver.OnEscape -= OpenOrClose;

    }

    public void OpenOrClose(InputAction.CallbackContext _CallbackContext) => OpenOrClose();
    public void OpenOrClose()
    {

        m_PausePanel.SetActive(!m_PausePanel.activeInHierarchy);
        UpdatePause();

    }

    private void UpdatePause()
    {

        Time.timeScale = (m_PausePanel.activeInHierarchy) ? 0:1;

    }

}
