using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform thumb;
    public Vector2 delta;
    public bool enableKeyboardControls;

    private Vector2 originalPosition;
    private Vector2 originalThumbPosition;

    void Start()
    {
        originalPosition = this.GetComponent<RectTransform>().localPosition;
        originalThumbPosition = thumb.localPosition;

        thumb.gameObject.SetActive(false);

        delta = Vector2.zero;
    }

    // Keyboard controls
    void Update()
    {
        if (enableKeyboardControls)
        {
            delta.x = (Input.GetAxis("Horizontal"));
            delta.y = (Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                InputManager.instance.StartFiring();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                InputManager.instance.StopFiring();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        thumb.gameObject.SetActive(true);

        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);

        this.GetComponent<RectTransform>().position = worldPoint;
        thumb.localPosition = originalThumbPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = new Vector3();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(this.transform as RectTransform, eventData.position, eventData.enterEventCamera, out worldPoint);

        thumb.position = worldPoint;

        var size = GetComponent<RectTransform>().rect.size;

        delta = thumb.localPosition;

        delta.x /= size.x / 2.0f;
        delta.y /= size.y / 2.0f;

        delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
        delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localPosition = originalPosition;
        delta = Vector2.zero;

        thumb.gameObject.SetActive(false);
    }
}
