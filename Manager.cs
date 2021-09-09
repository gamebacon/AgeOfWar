using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] GameObject warrior;

    private void OnEnable()
    {
        //Spawn(warrior);
    }


    //constructor -> Init() -> Awake() -> OnEnable() -> Start()

    private Mob Spawn(GameObject o)
    {

        Instantiate(o);
        return o.GetComponent<Mob>();
    }


    public void Spawn() { 
        Spawn(warrior).Init(Team.ALLY);
	}



    public void Spawn(MobType type, Team team)
    {
        Spawn(warrior).Init(team);
	}

}
