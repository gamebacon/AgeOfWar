using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Vector2 = UnityEngine.Vector2;

public abstract class MeleeMob : Mob

{
    [SerializeField] private GameObject weapon;
    
    private Vector2 orgPos;
    private const float hitBoxStay = .3f;

    public new void Init(Team team, EntityType entityType, int maxHealth, float speed, int damage, int attackSpeed, float range)
    {
	    base.Init(team, EntityType.WARRIOR, maxHealth, speed, damage, attackSpeed, range);
        weapon.transform.Translate(team.direction * .1f);
    }

    protected override void Attack()
    {
        weapon.SetActive(true);
        
        //keep track of old hitbox pos
        orgPos = weapon.transform.position;
        
        //slightly move the hitbox to detect collisions 
        weapon.transform.Translate(Vector2.up * 0.1f);
        
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
