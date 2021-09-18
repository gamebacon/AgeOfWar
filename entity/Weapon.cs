using entity.mob;
using UnityEngine;
using UnityEngine.UIElements;

namespace entity
{
    public class Weapon : MonoBehaviour
    {
        private Mob mob;
        public BoxCollider2D box;

        private void Start()
        {
            mob = GetComponentInParent<Mob>();
            box = GetComponent<BoxCollider2D>();
            
            box.offset = new Vector2(mob.attackRange * mob.GetTeam().direction.x, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Entity target = other.GetComponent<Entity>();
            
            if(!isFrinedly(target))
                target.TakeDamage(this.mob.GetDamage());
        }

        private bool isFrinedly(Entity entity)
        {
            return entity.GetTeam().Equals(this.mob.GetTeam());
        }

    }
}
