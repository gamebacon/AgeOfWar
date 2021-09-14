using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using static EntityStatus;

public abstract class Team : Entity
{
	protected int money = 0;
	public readonly LinkedList<Guid> mobQueue = new LinkedList<Guid>();
	
	public Vector2 spawn { get; private set; }
	public Vector2 direction { get; private set; }
	public Color color { get; private set; }

	public void Init(Vector2 spawn, Color color, Vector2 direction)
	{
		this.spawn = spawn;
		this.color = color;
		this.direction = direction;
		
		base.Init(this, EntityType.BASE, 500);
	}

	private void Start()
	{
		StartCoroutine(GainMoney());
	}

	private IEnumerator GainMoney()
	{
		while (GameManager.state == GameState.ONGOING)
		{
			yield return new WaitForSeconds(1.4f);
			UpdateBalance(1);
		}
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
				GameState result = this is Enemy ? GameState.VICTORY : GameState.DEFEAT;
				GameManager.ResetGame(result);
				break;
			}
			case SLEEPING:
				break;
		}
	}


	public abstract void UpdateBalance(int add);

}
