using System;

namespace First
{
	class Program
	{


		static void Main(string[] args)
		{
			var menu = new Utils.Menu();
			// voeg oefeningen to door een callback naar een functie
			menu.AddOption('1', "Test exercise 1", DoOef1);
			menu.AddOption('2', "Test exercise 2", DoOef2);
			menu.AddOption('3', "Test exercise 3", DoOef3);
			menu.AddOption('4', "Test exercise 4", DoOef4);
			menu.AddOption('5', "Test scoreboard", StartScoreBoard);
			menu.Start();
		}

		static void DoOef1()
		{
			if (!ValidateCustomer()) return;

			var customer = new Utils.Object("First.Customer");
			Console.Write("Your Name: ");
			customer.Prop("FirstName").Set(Console.ReadLine());
			Console.Write("Your Last Name: ");
			customer.Prop("LastName").Set(Console.ReadLine());
			Console.Write("Your date of birth (dd/mm/yyyy): ");
			customer.Prop("DateOfBirth").Set(DateTime.Parse(Console.ReadLine()));

			Console.WriteLine();
			Console.WriteLine("Your name is " + customer.Prop("Name").Get());
			Console.WriteLine("You are " + customer.Prop("Age").Get() + " years old.");
		}

		static void DoOef2()
		{
			if (!ValidateCoordinate()) return;
			Console.WriteLine();

			Console.Write("Enter an X coordinate: ");
			float x = Convert.ToSingle(Console.ReadLine());
			Console.Write("Enter an Y coordinate: ");
			float y = Convert.ToSingle(Console.ReadLine());
			Console.WriteLine();

			var coord1 = new Utils.Object("First.Coordinate");
			coord1.Prop("X").Set(x);
			coord1.Prop("Y").Set(y);
			Console.WriteLine("When using X and Y properties, the values of your object are ");
			Console.WriteLine("X: " + coord1.Prop("X").Get());
			Console.WriteLine("Y: " + coord1.Prop("Y").Get());

			var coord2 = new Utils.Object("First.Coordinate");
			coord2.Method("Set", new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { x, y });
			Console.WriteLine("When using the Set method, the values of your object are ");
			Console.WriteLine("X: " + coord2.Prop("X").Get());
			Console.WriteLine("Y: " + coord2.Prop("Y").Get());
		}

		static void DoOef3()
		{
			if (!ValidateCoordinate()) return;
			if (!ValidateCircle()) return;

			Console.WriteLine();
			var circle = new Utils.Object("First.Circle");
			Console.WriteLine("Setting the radius of your circle to 4.5 ...");
			circle.Prop("Radius").Set(4.5f);
			Console.WriteLine("Settings the position of your circle to (3, 4) ...");
			var coord = new Utils.Object("First.Coordinate");
			coord.Method("Set", new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 3, 4 });
			circle.Prop("Pos").Set(coord.Instance);

			Console.WriteLine();
			Console.WriteLine("The area should be 63.61725");
			Console.WriteLine("Your value is " + circle.Prop("Area").Get());
			Console.WriteLine();
			Console.WriteLine("The perimeter should be 28.27433");
			Console.WriteLine("Your value is " + circle.Prop("Perimeter").Get());
		}

		static void DoOef4()
		{
			if (!ValidateCoordinate()) return;
			if (!ValidateRectangle()) return;
			Console.WriteLine();

			var rectangle = new Utils.Object("First.Rectangle");
			Console.WriteLine("Setting the width of your rectangle to 4 ...");
			rectangle.Prop("Width").Set(4f);
			Console.WriteLine("Setting the height of your rectnagle to 6 ...");
			rectangle.Prop("Height").Set(6f);
			Console.WriteLine("Settings the position of your rectangle to (3, 4) ...");
			var coord = new Utils.Object("First.Coordinate");
			coord.Method("Set", new Type[] { typeof(float), typeof(float) }).Invoke(new object[] { 3, 4 });
			rectangle.Prop("Pos").Set(coord.Instance);

			Console.WriteLine();
			Console.WriteLine("Value\t\tExpected\tYours");
			Console.WriteLine("UpperLeft\t(1, 7)\t\t" + ToString(new Utils.Object(rectangle.Prop("UpperLeft").Get())));
			Console.WriteLine("UpperRight\t(5, 7)\t\t" + ToString(new Utils.Object(rectangle.Prop("UpperRight").Get())));
			Console.WriteLine("LowerLeft\t(1, 1)\t\t" + ToString(new Utils.Object(rectangle.Prop("LowerLeft").Get())));
			Console.WriteLine("LowerRight\t(5, 1)\t\t" + ToString(new Utils.Object(rectangle.Prop("LowerRight").Get())));

			Console.WriteLine();
			Console.WriteLine("Area\t\t24\t\t" + rectangle.Prop("Area").Get());
			Console.WriteLine("Perimeter\t16\t\t" + rectangle.Prop("Perimeter").Get());
		}

		static string ToString(Utils.Object coord)
		{
			string result = "(";
			result += coord.Prop("X").Get();
			result += ", ";
			result += coord.Prop("Y").Get();
			result += ")";
			return result;
		}

		static void StartScoreBoard()
		{
			if (!Utils.Object.DoesClassExist("First.ScoreBoard"))
			{
				Console.WriteLine("Er bestaat geen class 'ScoreBoard'.");
				return;
			}

			var board = new Utils.Object("First.ScoreBoard");
			if (board.IsValid)
			{
				var menu = new Utils.Menu();
				menu.AddOption('1', "Geef een punt aan Player 1",
					() =>
					{
						board.Method("PointToPlayer1")?.Invoke();
						Console.WriteLine("Player 1 heeft nu "
							+ board.Prop("Player1Score")?.Get()
							+ " punten.");
					}
				);

				menu.AddOption('2', "Geef een punt aan Player 2",
					() =>
					{
						board.Method("PointToPlayer2")?.Invoke();
						Console.WriteLine("Player 2 heeft nu "
							+ board.Prop("Player2Score")?.Get()
							+ " punten.");
					}
				);

				menu.AddOption('3', "Reset de scores",
					() =>
					{
						board.Method("Reset")?.Invoke();

						Console.WriteLine("Player 1 heeft nu "
							+ board.Prop("Player1Score")?.Get()
							+ " punten.");
						Console.WriteLine("Player 2 heeft nu "
							+ board.Prop("Player2Score")?.Get()
							+ " punten.");
					}
				);

				menu.AddOption('4', "Geef de spelers een naam",
					() =>
					{
						Console.Write("Naam voor speler 1: ");
						string player1 = Console.ReadLine();
						board.Prop("Player1Name")?.Set(player1);

						Console.Write("Naam voor speler 2: ");
						string player2 = Console.ReadLine();
						board.Prop("Player2Name")?.Set(player2);
					}
				);

				menu.AddOption('5', "Toon het scorebord",
					() =>
					{
						Console.WriteLine(
								board.Prop("Player1Name")?.Get()
								+ " heeft "
								+ board.Prop("Player1Score")?.Get()
								+ " punten."
							);
						Console.WriteLine(
								board.Prop("Player2Name")?.Get()
								+ " heeft "
								+ board.Prop("Player2Score")?.Get()
								+ " punten."
							);

						if ((bool)board.Method("IsPlayer1Winning")?.Invoke() == true)
						{
							Console.WriteLine(
								board.Prop("Player1Name")?.Get()
								+ " wint."
								);
						}
						else if ((bool)board.Method("IsPlayer2Winning")?.Invoke() == true)
						{
							Console.WriteLine(
								board.Prop("Player2Name")?.Get()
								+ " wint."
								);
						}
						else
						{
							Console.WriteLine("Gelijkspel!");
						}

						Console.WriteLine(
							"Het verschil bedraagt "
							+ board.Method("Distance")?.Invoke()
							+ " punten."
							);
					}
				);

				menu.Start();
			}


		}

		static bool ValidateCustomer()
		{
			var validator = new Utils.Validator("First.Customer");
			validator.AddProperty("FirstName", typeof(string));
			validator.AddProperty("LastName", typeof(string));
			validator.AddProperty("DateOfBirth", typeof(DateTime));
			validator.AddProperty("Name", typeof(string), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("Age", typeof(int), Utils.PropertyAccess.ReadOnly);

			return validator.Validate();
		}

		static bool ValidateCoordinate()
		{
			var validator = new Utils.Validator("First.Coordinate");
			validator.AddProperty("X", typeof(float));
			validator.AddProperty("Y", typeof(float));
			validator.AddMethod("Set", typeof(void), new Type[] { typeof(float), typeof(float) });

			return validator.Validate();
		}

		static bool ValidateCircle()
		{
			var validator = new Utils.Validator("First.Circle");
			validator.AddProperty("Radius", typeof(float));
			validator.AddProperty("Pos", Utils.Object.GetClassType("First.Coordinate"));
			validator.AddProperty("Area", typeof(float), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("Perimeter", typeof(float), Utils.PropertyAccess.ReadOnly);

			return validator.Validate();
		}

		static bool ValidateRectangle()
		{
			var validator = new Utils.Validator("First.Rectangle");
			validator.AddProperty("Width", typeof(float));
			validator.AddProperty("Height", typeof(float));
			validator.AddProperty("Pos", Utils.Object.GetClassType("First.Coordinate"));
			validator.AddProperty("UpperLeft", Utils.Object.GetClassType("First.Coordinate"), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("UpperRight", Utils.Object.GetClassType("First.Coordinate"), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("LowerLeft", Utils.Object.GetClassType("First.Coordinate"), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("LowerRight", Utils.Object.GetClassType("First.Coordinate"), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("Area", typeof(float), Utils.PropertyAccess.ReadOnly);
			validator.AddProperty("Perimeter", typeof(float), Utils.PropertyAccess.ReadOnly);

			return validator.Validate();
		}
	}
}
