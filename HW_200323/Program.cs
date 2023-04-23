using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_200323
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Item[] inventory = new Item[2];

			inventory[0] = ItemFactory.Create("Sword");
			inventory[1] = ItemFactory.Create("HealPotion");

			inventory[0].Use();
			inventory[1].Use();

			Console.ReadKey(true);
		}

		static class Global
		{
			static public Random Rand;

			static Global() { Rand = new Random(); }
		}

		abstract public class Item
		{
			public string Name { get; }

			public int Value { get; }

			abstract public void Use();
		}

		public class HealPotion : Item
		{
			public override void Use()
			{
				Console.WriteLine($"You have recovered { Global.Rand.Next(2, 6) } health points");
			}
		}

		public class Sword : Item
		{
			private int _DMG;

			public Sword(int DMG)
			{
				_DMG = DMG;
			}

			public override void Use()
			{
				Console.WriteLine($"You dealt { Global.Rand.Next(1, 4) + _DMG } damage");
			}
		}

		static public class ItemFactory
		{
			public static Item Create(string Name)
			{
				switch (Name.ToLower()) {
					case "sword":
						return new Sword(2);

					case "healpotion":
						return new HealPotion();

					default:
						throw new Exception("This item does not exist");
				}
			}
		}
	}
}
