using System.Collections;
using UnityEngine;

namespace Game
{
    public class DisableAfter : MonoBehaviour
    {
        [SerializeField] float m_Delay;

        private void OnEnable()
        {
            StopAllCoroutines();
            if(gameObject.activeSelf)
                StartCoroutine(nameof(DisableObjectAfter));
        }

        IEnumerator DisableObjectAfter()
        {
            yield return new WaitForSeconds(m_Delay);
            gameObject.SetActive(false);
        }
    }
}
