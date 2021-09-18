using System;
using System.Collections;
using team;
using UnityEngine;
using util;
using static util.EntityStatus;

namespace entity.mob
{
	public abstract class Mob : Entity {


		private float movementSpeed;
		private int attackCooldown;
		private bool isWoken = false;

		private int damage;
		public float attackRange { get; private set; }

		private bool canAttack = true;


		public abstract void Init(Team team);
		protected void Init(Team team,  int health, float speed, int damage, int attackCooldown, float range)
		{
			base.Init(team, health);
			team.mobQueue.AddLast(GetUUID());
        

			this.movementSpeed = speed;
			this.damage = damage;
			this.attackCooldown = attackCooldown;
			this.attackRange = range;

			spriteRenderer.color = team.color;
			spriteRenderer.flipX = team is Enemy;
			gameObject.name = String.Format("[{0}] {1}", team.ToString(), GetMobType());
        
			SetStatus(SLEEPING);
		}

		private IEnumerator WakeUp()
		{
			isWoken = true;
			yield return new WaitForSeconds(2);
			GetTeam().mobQueue.RemoveFirst();
			SetStatus(IDLE);

		}


		void Update() {
			if (GameManager.state == GameState.ONGOING)
			{
				switch(GetStatus())
				{
					case NOT_INIT:
					{
						return;
					}
					case MOVING:
					{
						Move();	
						break;
					}
					case ATTACKING:
					{
						if (canAttack)
							StartCoroutine(InvokeAttack());
						break;
					}
					case IDLE:
					{

						break;
					}
					case SLEEPING:
					{
						if (!isWoken && GetTeam().mobQueue.First.Value.Equals(GetUUID()))
						{
							StartCoroutine(WakeUp());
						
						}
			
						break;
					}
					case DEAD:
					{
						gameObject.layer = 0;
						spriteRenderer.color = Color.gray;
						Destroy(this.gameObject, 1);
						break;
					}
				}
			}
		}


		private IEnumerator InvokeAttack()
		{
			canAttack = false;
			yield return new WaitForSeconds(attackCooldown);
			this.Attack();
			canAttack = true;
		}


		void Move()
		{
			transform.Translate(GetTeam().direction * (Time.deltaTime * movementSpeed));
		}

		public bool IsPlaying()
		{
			return GetStatus() != NOT_INIT && GetStatus() != SLEEPING && GetStatus() != DEAD;
		}




		public int GetDamage()
		{
			return this.damage + Util.GetBonus() + Util.GetCrit(8);
		}

		public abstract int GetCost();

		public abstract Vector2 GetEye();

		protected abstract void Attack();
    
		public abstract MobType GetMobType();

	}
}