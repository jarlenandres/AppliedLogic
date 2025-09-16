using AppliedLogic.Core;

var beam = string.Empty;
try
{
	Console.Write("Enter the beam: ");
	beam = Console.ReadLine() ?? string.Empty;
	var resitorBeam = new ResitorBeam
	{
		Beam = beam
	};

}
catch (Exception ex)
{

	Console.WriteLine(ex.Message);
}