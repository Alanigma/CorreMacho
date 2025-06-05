using UnityEngine;

namespace Game.GameSystem
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField, Min(0)] int m_firstSceneIndex;

        private void Awake()
        {
            Bootstrap();
        }

        void Bootstrap()
        {
            InputManager.ProvideInstance();
            AudioManager.ProvideInstance();
            GameScenesManager.ProvideInstance().LoadSingleScene(m_firstSceneIndex);
        }
    }
}
