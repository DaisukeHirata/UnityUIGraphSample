using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private Transform canvasTran;

	void Awake()
	{
		Debug.Log ("Awake called");
        canvasTran = transform.parent.parent;
	}

	public void OnBeginDrag(PointerEventData pointerEventData)
	{
		transform.position = GetLocalPosition(pointerEventData.position);
	}

	public void OnDrag(PointerEventData pointerEventData)
	{
        transform.position = GetLocalPosition(pointerEventData.position);
	}

	public void OnEndDrag(PointerEventData pointerEventData)
	{
	}

	private Vector2 GetLocalPosition(Vector2 screenPosition)
	{
		Vector3 result = Vector3.zero;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasTran.GetComponent<RectTransform>(), screenPosition, Camera.main, out result);

		return result;
	}
}
