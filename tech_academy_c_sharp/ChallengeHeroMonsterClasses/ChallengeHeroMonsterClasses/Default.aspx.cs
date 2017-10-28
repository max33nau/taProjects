using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClasses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            Character monster = new Character();

            hero.Name = "Arthur";
            monster.Name = "Dragon";

            hero.Health = 100;
            monster.Health = 100;

            hero.DamageMaximum = 20;
            monster.DamageMaximum = 15;

            hero.AttackBonus = true;
            monster.AttackBonus = false;
            Battle(hero, monster);
        }

        private void Battle(Character hero, Character monster)
        {
            string battleDetails = "<strong>Round 1</strong>";
            battleDetails += "<br />";
            battleDetails += String.Format("{0} attacking {1}", hero.Name, monster.Name);
            battleDetails += "<br />";
            int heroDamage = hero.Attack();
            monster.Defend(heroDamage);
            battleDetails += String.Format("Result: {0} took {1} damage from {2} and only has {3} health left.",
                monster.Name, heroDamage, hero.Name, monster.Health
            );
            battleDetails += "<br /> <hr />";
            battleDetails += "<strong>Round 2</strong>";
            battleDetails += "<br />";
            battleDetails += String.Format("{0} attacking {1}", monster.Name, hero.Name);
            battleDetails += "<br />";
            int monsterDamage = monster.Attack();
            hero.Defend(monsterDamage);
            battleDetails += String.Format("Result: {0} took {1} damage from {2} and only has {3} health left.",
                hero.Name, monsterDamage, monster.Name, hero.Health
            );

            battleLabel.Text = battleDetails;
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random random = new Random();
            int damage = random.Next(0, this.DamageMaximum);
            return damage;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }
}