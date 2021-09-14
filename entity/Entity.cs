using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using static EntityStatus;

public class Entity : MonoBehaviour 
{
    public int maxHealth;
    public int health;
    public Guid uuid;
    
    public EntityStatus status;
    public EntityType type;
    [FormerlySerializedAs("base")] public Team team;
    
    [SerializeField] private TextMeshProUGUI text; 
    [SerializeField] private Slider slider; 
    
    protected void Init(Team team, EntityType type, int health)
    {
	    this.team = team;
        this.type = type;
        this.maxHealth = health;
        this.health = maxHealth;
        this.uuid = Guid.NewGuid();

        gameObject.tag = team.ToString();
        gameObject.name = String.Format("[{0}] {1}", team.ToString(), type);
        text.SetText(gameObject.name);
        
    }

    private void Update()
    {
	    switch (status)
	    {
		    case IDLE:
			    break;
		    case MOVING:
			    break;
		    case ATTACKING:
			    break;
		    case DEAD:
		    {
			    //remove?
			    this.gameObject.layer = 0;
			    Destroy(this.gameObject, 1);
			    break;
		    }
		    case SLEEPING:
			    break;
		    default:
			    throw new ArgumentOutOfRangeException();
	    }
    }

    
    public void TakeDamage(int damageTaken)
    {
	    this.health -= damageTaken;
	    slider.value = (float) health / maxHealth;

	    if (health <= 0)
	    {
		    SetStatus(DEAD);
	    }
		    
    }
    

    public void msg(String message)
    {

        Debug.Log(String.Format(
            "[{0} - {1}]: {2}",
            team,
            status,
            message
		));
    }
    public void SetStatus(EntityStatus status)
    {
	    if (this.status != status)
	    {
			this.status = status;
			text.SetText(status.ToString());
	    }
	    
	}
    
    
}
