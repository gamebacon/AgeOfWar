using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Weapon : MonoBehaviour
{
    private Mob mob;

    private void Start()
    {
        mob = GetComponentInParent<Mob>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity target = other.GetComponent<Entity>();
        if(!isFrinedly(target))
            target.TakeDamage(this.mob.GetDamage());
    }

    private bool isFrinedly(Entity entity)
    {
        return entity.team.Equals(this.mob.team);
    }

}
