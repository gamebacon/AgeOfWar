using UnityEngine;

namespace team
{
    public class Enemy : Team 
    {
        public void Init()
        {
            base.Init(new Vector2(11f, -4), Color.yellow, Vector2.left);
        }
    
        public override string ToString()
        {
            return "enemy";
        }

        public override void UpdateBalance(int add)
        {
            money += add;
        }

    }
}
