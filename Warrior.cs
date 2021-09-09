using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Mob 

{

    public override void Init(Team team)
    {
	    base.Init(team, MobType.WARRIOR, 100, 1.2f, 75, 3, 2);
    }


    public override void Attack()
    {

    }

    public override Vector2 GetEye()
    {
        return ((Vector2) transform.position) + (TeamUtil.GetDirection(GetTeam()) * .7f);
    }

}
