using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float maxRotationalForce = 10;

    private Vector3 rotationalForce;

    private Vector3 targetDirection;

	void Start () {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;

        PlayerController player = FindObjectOfType<PlayerController>();
        transform.LookAt(player.transform);
        targetDirection = transform.forward;

        rotationalForce = new Vector3(
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce)
       );
    }
	

	void Update () {
        MoveToTarget();
        ApplyRotationalForce();
	}

    private void MoveToTarget() {
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    private void ApplyRotationalForce()
    {
        transform.Rotate(rotationalForce * Time.deltaTime, Space.Self);
    }
}
