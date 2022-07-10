using System;

namespace IMJunior
{
	class Program
	{
		static void Main(string[] args)
		{
			int age = 0, strength = 0, agility = 0, intelligence = 0, points = 25;
			string strengthVisual = string.Empty, agilityVisual = string.Empty, intelligenceVisual = string.Empty;

			Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
			Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
			Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
			Console.ReadKey();

			while (points > 0)
			{
				Console.Clear();
				strengthVisual = string.Empty;
				agilityVisual = string.Empty;
				intelligenceVisual = string.Empty;
				strengthVisual = strengthVisual.PadLeft(strength, '#').PadRight(10, '_');
				agilityVisual = agilityVisual.PadLeft(agility, '#').PadRight(10, '_');
				intelligenceVisual = intelligenceVisual.PadLeft(intelligence, '#').PadRight(10, '_');
				Console.WriteLine("Поинтов - {0}", points);
				Console.WriteLine("Возраст - {0}\nСила - [{1}]\nЛовкость - [{2}]\nИнтелект - [{3}]", age, strengthVisual, agilityVisual, intelligenceVisual);

				Console.WriteLine("Какую характеристику вы хотите изменить?");
				string subject = Console.ReadLine();

				Console.WriteLine(@"Что вы хотите сделать? +\-");
				string operation = Console.ReadLine();

				Console.WriteLine(@"Колличество поинтов которые следует {0}", operation == "+" ? "прибавить" : "отнять");

				string operandPointsRaw = string.Empty;
				int operandPoints = 0;
				do
				{
					operandPointsRaw = Console.ReadLine();
				} while (!int.TryParse(operandPointsRaw, out operandPoints));

				switch (subject.ToLower())
				{
					case "сила":
						if (operation == "+")
						{
							int overhead = operandPoints - (10 - strength);
							overhead = overhead < 0 ? 0 : overhead;
							operandPoints -= overhead;
						}
						else {
							int overhead = strength - operandPoints;
							overhead = overhead < 0 ? overhead : 0;
							operandPoints += overhead;
						}

						strength = operation == "+" ? strength + operandPoints : strength - operandPoints;
						points = operation == "+" ? points - operandPoints : points + operandPoints;
						break;
					case "ловкость":
						if (operation == "+")
						{
							int overhead = operandPoints - (10 - agility);
							overhead = overhead < 0 ? 0 : overhead;
							operandPoints -= overhead;
						}
						else {
							int overhead = agility - operandPoints;
							overhead = overhead < 0 ? overhead : 0;
							operandPoints += overhead;
						}

						agility = operation == "+" ? agility + operandPoints : agility - operandPoints;
						points = operation == "+" ? points - operandPoints : points + operandPoints;
						break;
					case "интелект":
						if (operation == "+")
						{
							int overhead = operandPoints - (10 - intelligence);
							overhead = overhead < 0 ? 0 : overhead;
							operandPoints -= overhead;
						}
						else {
							int overhead = intelligence - operandPoints;
							overhead = overhead < 0 ? overhead : 0;
							operandPoints += overhead;
						}

						intelligence = operation == "+" ? intelligence + operandPoints : intelligence - operandPoints;
						points = operation == "+" ? points - operandPoints : points + operandPoints;
						break;
				}
			}

			Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");
			string ageRaw = string.Empty;
			do
			{
				ageRaw = Console.ReadLine();
			} while (int.TryParse(ageRaw, out age));


			Console.Clear();
			strengthVisual = string.Empty;
			agilityVisual = string.Empty;
			intelligenceVisual = string.Empty;
			strengthVisual = strengthVisual.PadLeft(strength, '#').PadRight(10, '_');
			agilityVisual = agilityVisual.PadLeft(agility, '#').PadRight(10, '_');
			intelligenceVisual = intelligenceVisual.PadLeft(intelligence, '#').PadRight(10, '_');
			Console.WriteLine("Возраст - {0}\nСила - [{1}]\nЛовкость - [{2}]\nИнтелект - [{3}]", age, strengthVisual, agilityVisual, intelligenceVisual);

		}
	}
}