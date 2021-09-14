using UnityEngine;

namespace util
{
    public class EntityManager : MonoBehaviour
    {
        [SerializeField] GameObject warrior;
        [SerializeField] GameObject allyBase;
        [SerializeField] GameObject enemyBase;

        private void Start()
        {
                                                  
            allyBase.GetComponent<Ally>().Init();
            enemyBase.GetComponent<Enemy>().Init();
        }

        private Mob Spawn(GameObject o, Team team)
        {
            return Instantiate(o, team.spawn, Quaternion.identity).GetComponent<Mob>();
        }


        public void SpawnAlly()
        {
            Team ally = allyBase.GetComponent<Ally>();
            Spawn(warrior, ally).Init(ally);
        }
        public void SpawnEnemy()
        {
            Team enemy = enemyBase.GetComponent<Enemy>();
            Spawn(warrior, enemy).Init(enemy);
        }


    }
}
