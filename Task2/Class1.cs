using System;
// повторение)
public class Class1
{
    abstract class Character
    {
        protected weapon weapon;

        public Character(weapon weapon)
        {
            this.weapon = weapon;
        }

        public void setWeapon(weapon weapon)
        {
            this.weapon = weapon;
        }
        public abstract void fight();
    }

    class Knight : Character
    {
        public Knight(weapon weapon) : base(weapon)
        {
        }

        override public void fight()
        {
            Console.WriteLine("Knight start atacking!");
            weapon.useWeapon();
        }
    }

    class Queen : Character
    {
        public Queen(weapon weapon) : base(weapon)
        {
        }

        override public void fight()
        {
            Console.WriteLine("Queen start atacking!");
            weapon.useWeapon();
        }
    }

    class King : Character
    {
        public King(weapon weapon) : base(weapon)
        {
        }

        override public void fight()
        {
            Console.WriteLine("King start atacking!");
            weapon.useWeapon();
        }
    }


    interface weapon
    {
        void useWeapon();
    }

    class Axe : weapon
    {
        public void useWeapon()
        {
            Console.WriteLine("Axe swing");
        }
    }

    class Sword : weapon
    {
        public void useWeapon()
        {
            Console.WriteLine("Sword swing");
        }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            var knight = new Knight(new Axe());
            knight.fight();
        }
    }
}
