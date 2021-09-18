
using System;
using System.Collections;
using entity.mob;
using team;
using UnityEngine;
using Random = UnityEngine.Random;

namespace util
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField]  GameObject prefab;

        [SerializeField] GameObject allyBase;
        [SerializeField] GameObject enemyBase;

        public static Team ally;
        public static Team enemy;

        private void Awake()
        {
            ally = allyBase.GetComponent<Team>();
            enemy = enemyBase.GetComponent<Team>();

            allyBase.GetComponent<Ally>().Init();
            enemyBase.GetComponent<Enemy>().Init();

            if(true)
            StartCoroutine(StartSpawnEnemy());
        }

	private IEnumerator StartSpawnEnemy()
	{
		while (GameManager.state == GameState.ONGOING)
        {
            int interval = Random.Range(5, 15);
			yield return new WaitForSeconds(interval);
            bool spawned = BuyEnemy(MobType.Warrior);
            Debug.Log("Spawned: " + spawned);
        }
	}
  

        public bool BuyAlly(MobType type)
        {
            return Buy(type, ally);
        }

        public bool BuyEnemy(MobType mobType)
        {
            return Buy(mobType, enemy);
        }


        private bool Buy(MobType type, Team team)
        {
            int cost = Util.GetCost(type);
            
            if (team.GetMoney() >= cost)
            {
                team.UpdateBalance(-cost);
                Summon(type, team);
                return true;
            }

            return false;
        }

        private void Summon(MobType mobType, Team team)
        {
            GameObject instance = Instantiate(prefab, team.spawn, Quaternion.identity);

            Type type = Util.Type(mobType);
            
            Mob mob = instance.AddComponent(type) as Mob;
            mob.Init(team);
        }
        
    }
}
