using System;
using TMPro;
using UnityEngine;

namespace team
{
    public class Ally : Team
    {
        [SerializeField] private TextMeshProUGUI moneyText;
        public void Init()
        {
            base.Init(new Vector2(-11f, -4), Color.blue, Vector2.right);
        }

        public override string ToString()
        {
            return "ally";
        }

        public override void UpdateBalance(int add)
        {
            money += add;
            moneyText.SetText(String.Format("{0}", money));
        }

    }
}
