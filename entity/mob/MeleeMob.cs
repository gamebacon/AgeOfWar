using System.Collections;
using team;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace entity.mob
{
    public abstract class MeleeMob : Mob

    {
        [SerializeField] private GameObject weapon;
        private BoxCollider2D weaponBox;

        public GameObject bounds;
    
        private Vector2 orgPos;
        private const float hitBoxStay = .001f;

        public new void Init(Team team, int maxHealth, float speed, int damage, int attackCooldown, float range)
        {
            base.Init(team, maxHealth, speed, damage, attackCooldown, range);

            weapon = gameObject.transform.GetChild(1).gameObject;
            weaponBox = weapon.GetComponent<BoxCollider2D>();

            //BoxCollider2D selfBox = gameObject.GetComponent<BoxCollider2D>();
            //weapon.transform.Translate(team.direction * 1);
            weaponBox.offset = new Vector2((team.direction.x * .43f),0);
        }

        protected override void Attack()
        {
            weapon.SetActive(true);
        
            //keep track of old hitbox pos
            orgPos = weapon.transform.position;
        
            //slightly move the hitbox to detect collisions 
            weapon.transform.Translate(Vector2.up * 0.01f);
        
            //invoke hitbox reset
            StartCoroutine(ResetAttack());
        }

        private IEnumerator ResetAttack()
        {
            yield return new WaitForSeconds(hitBoxStay);
            weapon.SetActive(false);
        
            //move hitbox back to orgPos
            weapon.transform.position = orgPos;
        }


    }
}
