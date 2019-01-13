using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : AIBehaviour
{
    [SerializeField]
    private float releaseBombDistance = 40f;

    private bool releasedBombs = false;
    private bool steeredAroundPlayer = false;

    protected override IEnumerator FightBehaviour()
    {
        while(true)
        {
            float distance = (transform.position - player.transform.position).magnitude;
            Vector3 deltaPosition = (transform.position - player.transform.position).normalized;
            if (distance < releaseBombDistance)
            {
                if(!steeredAroundPlayer && transform.position.x < player.transform.position.x)
                {
                    steeredAroundPlayer = true;
                }

                if(!releasedBombs)
                {
                    releasedBombs = true;
                    weapon.RequestShoot();
                    Debug.Log("Release bombs!");
                }

                if (steeredAroundPlayer)
                {
                    Vector3 newPosition = new Vector3(0, 0, transform.position.z);
                    deltaPosition = (newPosition - Vector3.zero).normalized;
                    flyModeController.HandleInput(-deltaPosition.z, 1, player.transform.position);
                }
                else
                {
                    deltaPosition.z /= 2;
                    flyModeController.HandleInput(deltaPosition.z, 1, player.transform.position);
                }   
                
            }
            else
            {
                flyModeController.HandleInput(-deltaPosition.z, 1, player.transform.position);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator IdleBehaviour()
    {
        while(true)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator SeekBehaviour()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
