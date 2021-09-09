using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MobStatus;

public class EyeCast : MonoBehaviour
{


    public const float stopDistance = .2f;
    private Mob mob;

    void Start()
    {
        mob = gameObject.GetComponent<Mob>();
    }


    private void Update()
    {

        if (!mob.isInit())
            return;

        Vector2 start = transform.TransformDirection(mob.GetEye());
        Vector2 end = transform.TransformDirection(TeamUtil.GetDirection(mob.GetTeam()));

        RaycastHit2D hit = Physics2D.Raycast(start, end, mob.attackRange);

        bool shouldStop = hit.distance <= stopDistance; 

        Debug.DrawRay(start, end * mob.attackRange, TeamUtil.GetColor(mob.GetTeam()));

        if (hit)
        {
            Mob other = hit.collider.gameObject.GetComponent<Mob>();

            if(!IsFriendly(other))
            {
                mob.SetStatus(ATTACKING);
			} 
			else if(shouldStop)
			{
                mob.SetStatus(IDLE);
			}

        }
        else 
		{
			mob.SetStatus(MOVING);
		}

    }

    private bool IsFriendly(Mob mob)
	{
        return  mob.GetTeam() == this.mob.GetTeam();
	}
}
