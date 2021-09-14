using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Util 
{

    public static int GetCrit(int chance)
    {
	    return (Chance(chance) ? Random.Range(20, 60) : 0);
    }

    public static int GetBonus()
    {
	    return Random.Range(0, 10);
    }
    
    
    private static bool Chance(int percentage)
    {
	    return Random.Range(0, 100) <= percentage;
    }
    

}
