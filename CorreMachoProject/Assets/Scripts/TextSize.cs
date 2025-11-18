using UnityEngine;

public class TextSize : MonoBehaviour
{
    Vector3 m_BaseSize;

    void Start()
    {
        m_BaseSize = transform.localScale;
    }

    void Update()
    {
        transform.localScale = (PlayerPrefs.GetInt("BigFont", 0) == 1 ? 1.25f : 1) * m_BaseSize;
    }
}
