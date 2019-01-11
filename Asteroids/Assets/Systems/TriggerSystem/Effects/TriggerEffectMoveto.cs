using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectMoveto : TriggerEffect
{
    [SerializeField]
    private Location[] locations;

    [SerializeField]
    private float speed = 20;

    private PlayerController player;

    private int locationIndex = 0;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public override void ActivateEffect()
    {
        StartCoroutine(MoveTo());
    }

    public override bool HasFinished()
    {
        if(player.transform.position == locations[locations.Length - 1].GetLocation())
        {
            return true;
        }
        return false;
    }

    public override bool IsAsynchronous()
    {
        return false;
    }

    private IEnumerator MoveTo()
    {
        // TODO: Add saving momentum from point to point.
        foreach(Location location in locations)
        {
            Vector3 destination = location.GetLocation();
            Vector3 travelDirection = (destination - player.transform.position).normalized;
            float travelledDistance = 0;
            float distance = (player.transform.position - destination).magnitude;

            Quaternion nextRotation = Quaternion.LookRotation(travelDirection);
            Quaternion rotation = player.transform.rotation;

            
            while (travelledDistance < distance)
            {
                travelledDistance += speed * Time.deltaTime;
                player.transform.rotation = Quaternion.Lerp(rotation, nextRotation, travelledDistance / distance);
                player.transform.position += travelDirection * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            player.transform.position = destination;
        }
    }
}
