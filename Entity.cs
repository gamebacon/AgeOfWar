using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Pojo
public class Entity
{

    public string type { get; private set; }
    public int attackSpeed { get; private set; }
    public float speed { get; private set; }
    public int health { get; private set; }
    public int damage { get; private set; }
    public int range { get; private set; }


    public bool moving = true;
    public bool attacking = false;
    public bool canAttack = true;


    public Entity(string type, int health, float speed, int damage, int attackSpeed, int range)
    {
        this.type = type;
        this.health = health;
        this.speed = speed;
        this.damage = damage;
        this.attackSpeed = attackSpeed;
        this.range = range;
    }

}
