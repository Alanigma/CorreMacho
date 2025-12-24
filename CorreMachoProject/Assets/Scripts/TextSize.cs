using UnityEngine;

public class TextSize : MonoBehaviour
{
    Vector3 m_BaseSize;
    public float m_BigSize = 1.25f;

    void Start()
    {
        m_BaseSize = transform.localScale;
    }

    void Update()
    {
        transform.localScale = (PlayerPrefs.GetInt("BigFont", 0) == 1 ? m_BigSize : 1) * m_BaseSize;
    }
}
