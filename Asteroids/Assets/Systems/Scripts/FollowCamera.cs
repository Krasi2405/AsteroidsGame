using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private float playAreaWidth = 20;

    [SerializeField]
    private float startZoom = 15f;

    [SerializeField]
    private float zoomingSpeedPerSecond = 10;

    private Vector3 offset;
    private float currentZoomLevel;
    private Camera camera;

    private bool isFollowingPlayer = true;
    

    void Start () {
        camera = GetComponent<Camera>();
        player = FindObjectOfType<PlayerController>();
        offset = new Vector3(0, startZoom, 0);
        currentZoomLevel = offset.y;

        transform.position = player.transform.position + offset;
    }

    void LateUpdate () {
        
        Vector3 newPosition = player.transform.position + offset;
        if (!isFollowingPlayer)
        {
            newPosition.x = transform.position.x;
        }
        if (newPosition.z > playAreaWidth)
        {
            newPosition.z = playAreaWidth;
        }
        else if (newPosition.z < -playAreaWidth)
        {
            newPosition.z = -playAreaWidth;
        }

        transform.position = newPosition;
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
    
    public void LockTo(Vector3 position)
    {
        StartCoroutine(MoveTo(position));
        LockCamera();
    }

    public void LockCamera()
    {
        isFollowingPlayer = false;
    }

    public void UnlockCamera()
    {
        StopCoroutine("MoveTo");
        isFollowingPlayer = true;
    }

    public void SetPlayAreaHeight(float height)
    {
        playAreaWidth = height;
    }


    private IEnumerator MoveTo(Vector3 position)
    {
        for(int i = 0; i < 60; i++)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, position, 0.6f);
            newPosition.y = currentZoomLevel;
            transform.position = newPosition;
            yield return new WaitForEndOfFrame();
        }
    }

    public Vector3 GetTopPoint()
    {
        float playerCameraOffset = transform.position.y - player.transform.position.y;
        Vector3 top = new Vector3(camera.pixelWidth / 2, camera.pixelHeight, playerCameraOffset);
        return camera.ScreenToWorldPoint(top);
    }

    public Vector3 GetBottomPoint()
    {
        float playerCameraOffset = transform.position.y - player.transform.position.y;
        Vector3 bottom = new Vector3(camera.pixelWidth / 2, 0, playerCameraOffset);
        return camera.ScreenToWorldPoint(bottom);
    }

    public Vector3 GetLeftPoint()
    {
        float playerCameraOffset = transform.position.y - player.transform.position.y;
        Vector3 left = new Vector3(0, camera.pixelHeight / 2, playerCameraOffset);
        return camera.ScreenToWorldPoint(left);
    }

    public Vector3 GetRightPoint()
    {
        float playerCameraOffset = transform.position.y - player.transform.position.y;
        Vector3 left = new Vector3(camera.pixelWidth, camera.pixelHeight / 2, playerCameraOffset);
        return camera.ScreenToWorldPoint(left);
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
