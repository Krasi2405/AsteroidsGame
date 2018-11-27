using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    private Vector3 offset;

	void Start () {
        player = FindObjectOfType<PlayerController>();
        offset = transform.position - player.transform.position;
	}
	

	void LateUpdate () {
        // transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.2f);
        transform.position = player.transform.position + offset;
	}
}
