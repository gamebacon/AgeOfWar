using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static EntityStatus;
using Random = UnityEngine.Random;

public abstract class Mob : Entity {


    private float movementSpeed;
    private int attackSpeed;
    private bool isWoken = false;

    private int damage;
    public float attackRange { get; private set; }

    private bool canAttack = true;

    protected SpriteRenderer spriteRenderer;

    public abstract void Init(Team team);
    protected void Init(Team team, EntityType type, int health, float speed, int damage, int attackSpeed, float range)
    {
	    base.Init(team, type, health);
        team.mobQueue.AddLast(uuid);
        

        this.movementSpeed = speed;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.attackRange = range;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = team.color;
        spriteRenderer.flipX = team is Enemy;
        
        SetStatus(SLEEPING);
    }

    private IEnumerator WakeUp()
    {
	    isWoken = true;
	    yield return new WaitForSeconds(2);
	    team.mobQueue.RemoveFirst();
	    SetStatus(IDLE);

    }


    void Update() {
        switch(status)
		{
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
				if (!isWoken && team.mobQueue.First.Value.Equals(uuid))
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


    private IEnumerator InvokeAttack()
    {
        canAttack = false;
        this.Attack();
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }


    void Move()
    {
        transform.Translate(team.direction * (Time.deltaTime * movementSpeed));
    }

    public bool IsPlaying()
    {
	    return status != SLEEPING && status != DEAD;
    }




    public int GetDamage()
    {
	    return this.damage + Util.GetBonus() + Util.GetCrit(8);
    }
    public abstract Vector2 GetEye();

    protected abstract void Attack();

}