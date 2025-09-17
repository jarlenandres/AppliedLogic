using AppliedLogic.Core;

string beam = string.Empty;
Console.WriteLine("Enter the beam: ");
beam = Console.ReadLine() ?? string.Empty;

if (ResitorBeam.IsValid(beam))
{
    if (ResitorBeam.CalculateWeight(beam))
    {
        throw new Exception("The beam is valid and supports the weight.");
    }
    else
    {
        throw new Exception("The beam not support the weight.");
    }
}
else
{
    throw new Exception("The beam is poorly constructed.");
}