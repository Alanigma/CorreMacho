using Game.GameSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MapSelection : MonoBehaviour
    {
        public Image m_MapPreview;
        public int m_MapIndex;
        public List<Sprite> m_Maps;

        private void Start()
        {
            UpdateVisual();
        }

        public void Previous()
        {
            m_MapIndex--;
            if (m_MapIndex < 0)
                m_MapIndex = m_Maps.Count - 1;
            UpdateVisual();
        }

        public void Next()
        {
            m_MapIndex++;
            m_MapIndex %= m_Maps.Count;
            UpdateVisual();
        }

        void UpdateVisual()
        {
            m_MapPreview.sprite = m_Maps[m_MapIndex];
            GameScenesManager.Instance.m_MapIndex = m_MapIndex;
        }

    }
}
