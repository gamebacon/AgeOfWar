using team;
using UnityEngine;
using util;

namespace entity.mob
{
    public class Warrior : MeleeMob
    {

        public override void Init(Team team)
        {
            base.Init(team, 100, 1.2f, 20, 2, 1f);
        }

        public override int GetCost()
        {
            return 10;
        }
        public override MobType GetMobType()
        {
            return MobType.Warrior;
        }

        public override Vector2 GetEye()
        {
            return ((Vector2) transform.position) + GetTeam().direction * 1;
        }
    }
}
