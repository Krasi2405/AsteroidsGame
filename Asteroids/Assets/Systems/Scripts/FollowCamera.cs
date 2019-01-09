using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private float zoomingSpeedPerSecond = 10;

    private Vector3 offset;

    private float currentZoomLevel;

	void Start () {
        player = FindObjectOfType<PlayerController>();
        offset = transform.position - player.transform.position;
        currentZoomLevel = offset.y;
	}
	

	void LateUpdate () {
        // transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.2f);
        transform.position = player.transform.position + offset;
	}

    public void ChangeRelativeOffset(Vector3 relativeOffset)
    {
        offset += relativeOffset;
    }


    public void ChangeZoom(float targetZoom)
    {
        StopCoroutine("ZoomTo");
        StartCoroutine(ZoomTo(targetZoom));
    }


    private IEnumerator ZoomTo(float targetZoom)
    {
        while(currentZoomLevel != targetZoom)
        {
            currentZoomLevel = MathHelper.LinearFloatInterpolation(
                currentZoomLevel, 
                targetZoom, 
                zoomingSpeedPerSecond * Time.deltaTime
            );
            offset.y = currentZoomLevel;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finish zoom!");
    }
}
