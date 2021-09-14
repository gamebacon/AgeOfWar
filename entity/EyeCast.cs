using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static EntityStatus;

public class EyeCast : MonoBehaviour
{


    private const float stopDistance = 0.5f;
    private int layer; 
    private Mob mob;

    void Start()
    {
        mob = gameObject.GetComponent<Mob>();
        layer = LayerMask.GetMask("Base", "Mob"); 
    }


    private void Update()
    {
	    if(!mob.IsPlaying())
            return;
	    
	    
	    //Idle distance
	    //Attack distance
	    //?

	    float range = .01f;
	    
        Vector2 start = transform.TransformDirection(mob.GetEye());
        Vector2 end = transform.TransformDirection(mob.team.direction);
        
        RaycastHit2D hit = Physics2D.Raycast(start, end, range, layer);


        Debug.DrawRay(start, end * range, mob.team.color);
        Debug.DrawRay(start, end * stopDistance, Color.yellow);
        
        bool shouldStop = hit.distance <= stopDistance; 

        if (hit)
        {
            Entity other = hit.collider.gameObject.GetComponent<Entity>();
            
            if(!IsFriendly(other))
            {
                mob.SetStatus(ATTACKING);
			} 
			else if(shouldStop && other.type != EntityType.BASE)
			{
                mob.SetStatus(IDLE);
			}
            else
                mob.SetStatus(MOVING);

        }
        else
        {
			mob.SetStatus(MOVING);
        }
	

    }

    private bool IsFriendly(Entity entity)
    {
	    return entity.team.Equals(this.mob.team);
	}
}
