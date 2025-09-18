using System;
using System.Collections.Generic;

internal class HorsesConflict
{
    private static void Main()
    {
        Console.Write("Enter location of horses: ");
        string entrance = Console.ReadLine();

        string[] positions = entrance.Split(',');

        // Diccionario para convertir letras a columnas (A-H → 1-8)
        Dictionary<char, int> columns = new Dictionary<char, int>
        {
            {'A', 1}, {'B', 2}, {'C', 3}, {'D', 4},
            {'E', 5}, {'F', 6}, {'G', 7}, {'H', 8}
        };

        // Lista de posiciones de los caballos convertidas a coordenadas
        List<(int row, int col)> horses = new List<(int, int)>();
        foreach (var pos in positions)
        {
            string p = pos.Trim().ToUpper();
            if (p.Length == 2 && columns.ContainsKey(p[0]) && char.IsDigit(p[1]))
            {
                int col = columns[p[0]];
                int row = int.Parse(p[1].ToString());
                horses.Add((row, col));
            }
        }

        // Todos los posibles movimientos de un caballo
        int[] dRow = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] dCols = { 1, 2, 2, 1, -1, -2, -2, -1 };

        // Revisar conflictos
        for (int i = 0; i < horses.Count; i++)
        {
            var current = horses[i];
            string conflict = "";

            for (int j = 0; j < horses.Count; j++)
            {
                if (i == j) continue;

                var other = horses[j];
                for (int k = 0; k < 8; k++)
                {
                    int newRow = current.row + dRow[k];
                    int newCol = current.col + dCols[k];

                    if (newRow == other.row && newCol == other.col)
                    {
                        // Convertimos columna a letra
                        string letterCol = "";
                        foreach (var kv in columns)
                        {
                            if (kv.Value == other.col)
                            {
                                letterCol = kv.Key.ToString();
                                break;
                            }
                        }
                        conflict += $" Conflict with {other.row}{letterCol}";
                    }
                }
            }

            // Mostrar resultado
            string letraActual = "";
            foreach (var kv in columns)
            {
                if (kv.Value == current.col)
                {
                    letraActual = kv.Key.ToString();
                    break;
                }
            }

            Console.Write($"Analyzing Horse in {current.row}{letraActual} =>");

            if (string.IsNullOrEmpty(conflict))
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(conflict);
            }
        }
    }
}