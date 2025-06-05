using Game.Player;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.GameSystem
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] GameObject m_gameplayCanvas;
        [SerializeField] GameObject m_pauseCanvas;

        int m_currentPoints;
        private void OnEnable()
        {
            PlayerHealthObserver.OnPlayerDie += LoadDeathScreen;
            PlayerPointsObserver.OnUpdatePoints += SetPoints;
        }

        private void OnDisable()
        {
            PlayerHealthObserver.OnPlayerDie -= LoadDeathScreen;
            PlayerPointsObserver.OnUpdatePoints -= SetPoints;
        }

        void SetPoints(int newValue)
        {
            m_currentPoints = newValue;
        }

        private void Awake()
        {
            m_pauseCanvas.SetActive(false);
            m_gameplayCanvas.SetActive(true);
        }

        void LoadDeathScreen()
        {
            GameScenesManager gameScene = GameScenesManager.ProvideInstance();
            gameScene.LoadSingleSceneWithData(gameScene.DeathScreenScene, m_currentPoints);
        }

    }
}
