using System;
using team;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using util;
using static util.EntityStatus;
using Debug = UnityEngine.Debug;

namespace entity
{
	public abstract class Entity : MonoBehaviour 
	{
		private int maxHealth;
		[SerializeField] private int health;
		private Guid uuid;
		[SerializeField] EntityStatus status;
		private Team team;
    
		protected TextMeshProUGUI titleText; 
		protected TextMeshProUGUI hpText; 
		protected Slider slider; 
		protected SpriteRenderer spriteRenderer; 
    
		protected void Init(Team team, int health)
		{
			this.team = team;
			this.maxHealth = health;
			this.health = maxHealth;
			this.uuid = Guid.NewGuid();

			this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	    
			gameObject.tag = team.ToString();
        
        
			GameObject canvas = gameObject.transform.GetChild(0).gameObject;
			titleText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
			GameObject hp = canvas.transform.GetChild(1).gameObject;
			slider = hp.gameObject.GetComponent<Slider>();

			hpText = hp.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
	    
	    
			TakeDamage(0);
			titleText.SetText(gameObject.name);
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

			if (health <= 0)
			{
				health = 0; 
				SetStatus(DEAD);
			}
	    
			hpText.SetText(String.Format("{0}/{1}", health, maxHealth));
			slider.value = (float) health / maxHealth;
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
				titleText.SetText(status.ToString());
			}
	    
		}


		public Team GetTeam()
		{
			return this.team;
		}

		public EntityStatus GetStatus()
		{
			return this.status;
		}

		public Guid GetUUID()
		{
			return this.uuid;
		}
    
    
	}
}
