using UnityEngine;
using static Team;

public abstract class TeamUtil
{
	public static Color GetColor(Team team)
	{
		if (team == ALLY)
			return Color.blue;
		else
			return Color.red;
	}
	public static Vector2 GetDirection(Team team)
	{ 
		if (team == ALLY)
			return Vector2.right;
		else
			return Vector2.left;
	}


}
