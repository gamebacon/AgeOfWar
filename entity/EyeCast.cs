using System;
using System.Collections;
using entity.mob;
using team;
using UnityEditor.PackageManager;
using UnityEngine;
using static util.EntityStatus;
using Random = System.Random;

namespace entity
{
	public class EyeCast : MonoBehaviour
	{

		private BoxCollider2D hitbox; 
		private const float stopDistance = 0.5f;
		private int layer;
		private Mob mob;
		private Vector3 eye;

		void Start()
		{
			
			layer = LayerMask.GetMask("Base", "Mob"); 
			mob = gameObject.GetComponent<Mob>();
			hitbox = gameObject.GetComponent<BoxCollider2D>();

			float offset = 0.01f;
			float gay = (offset + hitbox.size.x * .5f) * mob.GetTeam().direction.x;
			eye = new Vector3(gay,0, 0);
			
		}


		private void Update()
		{
			if (!mob.IsPlaying())
			{
				return;
			}

	    
			
			//TODO: fix so faster mobs dont flicker between idle/move
			
			Vector2 start = transform.TransformDirection(transform.position + eye);
			Vector2 end = transform.TransformDirection(mob.GetTeam().direction);
        
			RaycastHit2D hit = Physics2D.Raycast(start, end, mob.attackRange, layer);


			Debug.DrawRay(start, end * mob.attackRange, mob.GetTeam().color);



			bool shouldStop = hit.distance <= mob.attackRange;//stopDistance; 

			if (hit)
			{
				Debug.Log(String.Format("{0} > {1}", gameObject.name, hit.collider.name));
				Entity other = hit.collider.gameObject.GetComponent<Entity>();

				if (!IsFriendly(other))
				{
					mob.SetStatus(ATTACKING);
				}
				else if (shouldStop && !(other is Team))
				{
					mob.SetStatus(IDLE);
				}
				else
				{
					mob.SetStatus(MOVING);
				}

			}
			else
			{
				mob.SetStatus(MOVING);
			}
				


		}


		private bool IsFriendly(Entity entity)
		{
			return entity.GetTeam().Equals(this.mob.GetTeam());
		}
	}
}
