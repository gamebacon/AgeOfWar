using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MeleeMob 
{
    public override void Init(Team team)
    {
        base.Init(team, EntityType.WARRIOR, 100, 1.2f, 20, 2, .1f);
    }
    
    public override Vector2 GetEye()
    {
        return ((Vector2) transform.position) + team.direction * .1f;
    }
}
