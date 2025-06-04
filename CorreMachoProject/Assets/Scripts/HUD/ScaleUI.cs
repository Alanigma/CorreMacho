using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler {

    [SerializeField] Transform m_Target;
    [SerializeField] UnityEvent m_HoverEvents;
    [SerializeField, Min(0)] float m_sizeMouseOver = 1.1f;
    Vector3 StartScale;

    private void OnEnable() {

        if(m_Target == null) m_Target = transform;

        StartScale = m_Target.localScale;
        if (EventSystem.current.currentSelectedGameObject == gameObject) OnSelect(null);
        

    }

    private void OnDisable() {
        m_Target.localScale = StartScale;
    }

    public virtual void OnPointerEnter(PointerEventData eventData) {

        if (TryGetComponent(out Selectable selectable) && !selectable.interactable) return;
        m_HoverEvents?.Invoke();
        m_Target.localScale = StartScale * m_sizeMouseOver;

    }

    public virtual void OnPointerExit(PointerEventData eventData) {

        if (TryGetComponent(out Selectable selectable) && !selectable.interactable) return;
        m_Target.localScale = StartScale;

    }

    public void OnSelect(BaseEventData eventData) {
        m_Target.localScale = StartScale * m_sizeMouseOver;
    }

    public void OnDeselect(BaseEventData eventData) {
        m_Target.localScale = StartScale;
    }

}
