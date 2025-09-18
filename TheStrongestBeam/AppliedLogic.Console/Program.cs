using AppliedLogic.Core;
using System;

internal class BeamProgram
{
    private static void Main()
    {
        Console.Write("Enter the beam: ");
        string beam = Console.ReadLine();

        string result = ResitorBeam.EvaluateBeam(beam);
        Console.WriteLine(result);
    }
}