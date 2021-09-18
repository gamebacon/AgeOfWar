using System;
using System.Collections.Generic;
using System.Data;
using entity.mob;
using UnityEngine;
using util;
using Random = UnityEngine.Random;

public class Util
{
	//private static readonly Dictionary<MobType, Mob> mobs = new Dictionary<MobType, Mob>();

	/*
	static Util()
	{
		MobType[] mobTypes = (MobType[]) Enum.GetValues(typeof(MobType));
		
		foreach(MobType mobType in mobTypes)
		{
			Debug.Log(mobType.ToString());
			Mob mob = (Mob) Activator.CreateInstance(Type.GetType(mobType.ToString()) ?? throw new InvalidOperationException());
			Debug.Log(mob == null);
			mobs.Add(mobType, mob);
		}
		
	}
	*/
    public static int GetCrit(int chance)
    {
	    return (Chance(chance) ? Random.Range(20, 60) : 0);
    }

    public static int GetBonus()
    {
	    return Random.Range(0, 10);
    }

    public static int GetCost(MobType type)
    {
	    return (int) type;
    }
    
    public static string GetString(MobType type)
    {
	    return "";
    }


    /*
    public static Mob GetMob(MobType type)
    {
	    Debug.Log("getting: " + type);
	    return mobs[type];
    }
    */
    
    private static bool Chance(int percentage)
    {
	    return Random.Range(0, 100) <= percentage;
    }


    public static Type Type(MobType mobType)
    {
	    String reflect = String.Format("{0}.{1}", typeof(Mob).Namespace, mobType.ToString());
	    return System.Type.GetType(reflect);
    }
}
