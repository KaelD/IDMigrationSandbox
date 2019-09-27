using System;

namespace IDMigrationSandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var ID1 = new ConversionID(new Guid("D07058A0-E0C6-4D7C-8A55-30C9AD84774D"), 42);

			PrintIntID(ID1);
			PrintguidID(ID1);

			var ID2 = new ConversionID(new Guid("D07058A0-E0C6-4D7C-8A55-30C9AD84774D"));

			PrintIntID(ID2);
			PrintguidID(ID2);

			var ID3 = new ConversionID(42);

			PrintIntID(ID3);
			PrintguidID(ID3);
		}

		public static void PrintIntID(int ID)
			=> Console.WriteLine(ID);
		public static void PrintguidID(Guid ID)
			=> Console.WriteLine(ID);
	}

	public class FeatureFlagQuery
	{
		public bool Useguids => false;
	}

	public class ConversionID
	{
		private Guid _guidID;
		private int _intID;

		private Guid getguidQueryHandler(int i) => new Guid("D07058A0-E0C6-4D7C-8A55-30C9AD84774D");
		private int getIntQueryHandler(Guid g) => 42;

		public ConversionID(Guid guidID, int intID)
		{
			_guidID = guidID;
			_intID = intID;
		}

		public ConversionID(Guid guidID)
		{
			_guidID = guidID;
			_intID = getIntQueryHandler(guidID);
		}

		public ConversionID(int intID)
		{
			_guidID = getguidQueryHandler(intID);
			_intID = intID;
		}

		public static implicit operator Guid(ConversionID ID)
			=> ID._guidID;

		public static implicit operator int(ConversionID ID)
			=> ID._intID;
	}


}
