using System;
using System.Collections;
using System.Collections.Generic;
using entity;
using UnityEngine;
using util;
using static util.EntityStatus;

namespace team
{
	public abstract class Team : Entity
	{
		private bool fart;
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
		
			base.Init(this, 500);
		
			gameObject.name = String.Format("[{0}]", ToString());
		}

		private void Start()
		{
			StartCoroutine(GainMoney());
			UpdateBalance(100);
		}


		private IEnumerator GainMoney()
		{
			fart = true;
			yield return new WaitForSeconds(1.4f);
			UpdateBalance(1);
			fart = false;
		}

		private void Update()
		{
			if (GameManager.state == GameState.ONGOING)
			{
				switch (GetStatus())
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

				if (!fart)
					StartCoroutine("GainMoney");
			}
		}


		public int GetMoney()
		{
			return money;
		}
		public abstract void UpdateBalance(int add);

	}
}
