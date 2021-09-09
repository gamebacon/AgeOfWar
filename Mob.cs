using System;
using System.Collections;
using UnityEngine;
using TMPro;
using static MobStatus;

public abstract class Mob : MonoBehaviour {


    private int id; 
    private float movementSpeed;
    private int attackSpeed;

    public MobType type { get; private set; }
    public int health { get; private set; }
    public int damage { get; private set; }

    public int attackRange { get; private set; }

    private bool canAttack = true;

    private MobStatus status = IDLE;
    public TextMeshProUGUI text; 
    private Team team;


    private void Start()
    {
        text.SetText("test");
    }

    public abstract void Init(Team team);
    protected void Init(Team team, MobType type, int health, float speed, int damage, int attackSpeed, int range) {
        this.id = UnityEngine.Random.Range(1, 9999999);

        this.team = team;
        this.type = type;
        this.health = health;
        this.movementSpeed = speed;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.attackRange = range;

        SetStatus(MOVING);
    }


    void Update() {
        switch(status)
		{
            case MobStatus.MOVING:
			{
					Move();	
					break;
			}
            case MobStatus.ATTACKING:
			{
                    if (canAttack)
                        StartCoroutine(InvokeAttack());
					break;
			}
            case MobStatus.IDLE:
			{

					break;
			}

		}
    }

    public void msg(String message)
    {
        Debug.Log(String.Format(
            "[{0}]: {1}",
            id,
            message
		));
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
        float lastTime = movementSpeed * Time.deltaTime;
        Vector3 v3 = TeamUtil.GetDirection(team) * lastTime;
        transform.Translate(v3);
    }

    public bool isInit()
    {
        return team != null;
    }

    public void SetStatus(MobStatus status) {
        this.status = status;
	} 


    public Team GetTeam() 
	{
        return this.team;
	}

    public abstract Vector2 GetEye();

    public abstract void Attack();

}