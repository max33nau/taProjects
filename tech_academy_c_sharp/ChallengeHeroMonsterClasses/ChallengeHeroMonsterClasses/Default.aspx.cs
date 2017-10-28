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

            hero.DamageMaximum = 10;
            monster.DamageMaximum = 20;

            hero.AttackBonus = true;
            monster.AttackBonus = false;
            Battle(hero, monster);
        }

        private void Battle(Character hero, Character monster)
        {
            string battleDetails = "<h2>Let the battle begin...</h2>";
            int round = 1;
            Dice dice = new Dice();
            while (hero.Health >= 0 && monster.Health >= 0)
            {
                battleDetails += String.Format("<strong> Round {0} </strong> <br />", round);
                Character attacker;
                Character defender;
                if (round % 2 == 0)
                {
                    attacker = hero;
                    defender = monster;
                } else
                {
                    attacker = monster;
                    defender = hero;
                }

                battleDetails += String.Format("{0} attacking {1} (has attack bonus: {2}) <br />", attacker.Name, defender.Name, attacker.AttackBonus);
                int attackerDamage = attacker.Attack(dice);
                defender.Defend(attackerDamage);
                battleDetails += String.Format("{0} took {1} damage from {2} <br />",
                    defender.Name, attackerDamage, attacker.Name
                );
                if (defender.Health >= 0)
                {
                    battleDetails += String.Format("{0} only has {1} health left",
                        defender.Name, defender.Health
                    );
                } else
                {
                    battleDetails += String.Format("{0} has been vanquished.",defender.Name);
                }
                battleDetails += "<br /> <hr>";
                round++;
            }

            battleLabel.Text = battleDetails;
            displayResult(hero, monster);
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            string result;
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
            {
                result = String.Format("There is no winner, both {0} and {1} have died.",
                    opponent1.Name, opponent2.Name);
            } else 
            {
                string winner = (opponent1.Health > opponent2.Health) ? opponent1.Name : opponent2.Name;
                result = String.Format("We have a winner, our champion is none other than {0}", winner);
            }
            resultLabel.Text =  "<h4>" + result + "</h4>";
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            dice.Sides = this.DamageMaximum;
            int attackIncrease = this.AttackBonus ? 5 : 0;
            return dice.Roll() + attackIncrease;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();

        public int Roll()
        {
            return random.Next(1, this.Sides);
        }
    }
}