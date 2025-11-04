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
        public List<Image> m_Miniatures;

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

        public void SetMapIndex(int _MapIndex)
        {
            m_MapIndex = _MapIndex;
            UpdateVisual();
        }

        void UpdateVisual()
        {
            for (int i = 0; i < m_Miniatures.Count; i++)
            {
                m_Miniatures[i].color = i == m_MapIndex ? Color.white : Color.black;
            }
            m_MapPreview.sprite = m_Maps[m_MapIndex];
            GameScenesManager.Instance.m_MapIndex = m_MapIndex;
        }

    }
}
