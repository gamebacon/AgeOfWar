using team;
using UnityEngine;
using util;

namespace entity.mob
{
    public class FartBlaster : MeleeMob
    {
        public override void Init(Team team)
        {
            base.Init(team, 200, 3, 200, 1, .6f);
        }

        public override int GetCost()
        {
            return 30;
        }

        public override Vector2 GetEye()
        {
            return ((Vector2) transform.position) + GetTeam().direction * .1f;
        }

        public override MobType GetMobType()
        {
            return MobType.FartBlaster;
        }
    }
}