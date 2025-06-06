using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{

    public class CutSceneManager : MonoBehaviour
    {

        [System.Serializable]
        public struct CutSceneData
        {

            public Sprite m_BackGround;
            public string m_Dialog;

        }

        public List<CutSceneData> m_CutSceneData = new List<CutSceneData>();
        private int m_CurrentScene;
        public float m_TimeToNext;

        public Image m_BackGround;
        public TMP_Text m_Dialog;

        public UnityEvent OnEndCutScene;

        public void OnEnable()
        {

            m_CurrentScene = -1;
            StartCoroutine(nameof(SceneCounter));

        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space)) NextScene();

        }

        public void NextScene()
        {

            StopCoroutine(nameof(SceneCounter));
            StartCoroutine(nameof(SceneCounter));

        }

        IEnumerator SceneCounter()
        {

            m_CurrentScene++;

            if (m_CurrentScene >= m_CutSceneData.Count)
            {

                OnEndCutScene?.Invoke();
                yield break;

            }

            m_BackGround.sprite = m_CutSceneData[m_CurrentScene].m_BackGround;
            m_Dialog.text = m_CutSceneData[m_CurrentScene].m_Dialog;

            yield return new WaitForSeconds(m_TimeToNext);

            StartCoroutine(nameof(SceneCounter));

        }
        
    }

}
