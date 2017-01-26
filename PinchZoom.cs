using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour
{
	public float orthographicZoomSensitivity;
	public float perspectiveZoomSensitivity;

	void Update() 
	{
		Camera camera = gameObject.GetComponent<Camera> ();

		if (Input.touchCount == 2) 
		{
			UnityEngine.Touch touch0 = Input.GetTouch(0);
			UnityEngine.Touch touch1 = Input.GetTouch(1);

			Vector2 touch0_prevPos = touch0.position - touch0.deltaPosition;
			Vector2 touch1_prevPos = touch1.position - touch1.deltaPosition;

			float prev_TouchDeltaMag = (touch0_prevPos - touch1_prevPos).magnitude;
			float current_TouchDeltaMag = (touch0.position - touch1.position).magnitude;

			float deltaMagDiff = prev_TouchDeltaMag - current_TouchDeltaMag;

			camera.orthographicSize += deltaMagDiff * orthographicZoomSensitivity;
			camera.fieldOfView += deltaMagDiff * perspectiveZoomSensitivity;
			camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
			camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
		}
	}

}
