using Game.GameSystem;
using UnityEngine;

namespace Game.HUD
{
    public class LoadSceneSolo : MonoBehaviour
    {
        [SerializeField, Min(0)] int m_sceneIndex; 
        public void Click()
        {
            GameScenesManager.ProvideInstance().LoadSingleScene(m_sceneIndex);
        }
    }
}
