using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

	void Start () {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;

        PlayerController player = FindObjectOfType<PlayerController>();
        transform.LookAt(player.transform);

        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
	

	void Update () {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}
}
