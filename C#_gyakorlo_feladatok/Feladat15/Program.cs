namespace Chess6_onallo;

internal class Program
{
    static void Main(string[] args)
    {
        // Piece osztály teszt: Valid függvény
        Console.WriteLine();
        Console.WriteLine("Piece teszt: Valid");
        Console.WriteLine($"A1: {Piece.Valid("A1")}"); // true
        Console.WriteLine($"H8: {Piece.Valid("H8")}"); // true
        Console.WriteLine($"D6: {Piece.Valid("D6")}"); // true
        Console.WriteLine($"A: {Piece.Valid("A")}"); // false
        Console.WriteLine($"a1: {Piece.Valid("a1")}"); // false
        Console.WriteLine($"X1: {Piece.Valid("X1")}"); // false
        Console.WriteLine($"A9: {Piece.Valid("A9")}"); // false
        Console.WriteLine($"A1d: {Piece.Valid("A1d")}"); // false

        // Rook osztály teszt: CanEnter függvény
        Console.WriteLine();
        Console.WriteLine("Rook teszt: CanEnter");
        Rook r1 = new Rook("C5");
        Console.WriteLine($"C5: {r1.CanEnter("C5")}"); //false
        Console.WriteLine($"C8: {r1.CanEnter("C8")}"); //true
        Console.WriteLine($"D3: {r1.CanEnter("D3")}"); //false
        Console.WriteLine($"C4: {r1.CanEnter("C4")}"); //true
        Console.WriteLine($"E5: {r1.CanEnter("E5")}"); //true
        Console.WriteLine($"H5: {r1.CanEnter("H5")}"); //true
        Console.WriteLine($"A3: {r1.CanEnter("A3")}"); //false

        // King osztály teszt: CanEnter függvény
        Console.WriteLine();
        Console.WriteLine("King teszt: CanEnter");
        King k1 = new King("C5");
        Console.WriteLine($"C5: {k1.CanEnter("C5")}"); //false
        Console.WriteLine($"C4: {k1.CanEnter("C4")}"); //true
        Console.WriteLine($"D4: {k1.CanEnter("D4")}"); //true
        Console.WriteLine($"D5: {k1.CanEnter("D5")}"); //true
        Console.WriteLine($"D6: {k1.CanEnter("D6")}"); //true
        Console.WriteLine($"C6: {k1.CanEnter("C6")}"); //true
        Console.WriteLine($"B6: {k1.CanEnter("B6")}"); //true
        Console.WriteLine($"B5: {k1.CanEnter("B5")}"); //true
        Console.WriteLine($"B4: {k1.CanEnter("B4")}"); //true
        Console.WriteLine($"C7: {k1.CanEnter("C7")}"); //false
        Console.WriteLine($"E4: {k1.CanEnter("E4")}"); //false

       // Piece osztály teszt: Enter függvény
        Console.WriteLine();
        Console.WriteLine("Piece teszt: Enter");
        Piece p1 = new Rook("D4");
        Piece p2 = new King("E8");
        Console.WriteLine($"D9: {p1.Enter("D9")}"); //false
        Console.WriteLine(p1.Position); //D4
        Console.WriteLine($"E3: {p1.Enter("E3")}"); //false
        Console.WriteLine(p1.Position); //D4
        Console.WriteLine($"G4: {p1.Enter("G4")}"); //true
        Console.WriteLine(p1.Position); //G4
        Console.WriteLine($"G2: {p1.Enter("G2")}"); //true
        Console.WriteLine(p1.Position); //G2
        Console.WriteLine($"E6: {p2.Enter("E6")}"); //false
        Console.WriteLine(p2.Position); //E8
        Console.WriteLine($"E7: {p2.Enter("E7")}"); //true
        Console.WriteLine(p2.Position); //E7
        Console.WriteLine($"F6: {p2.Enter("F6")}"); //true
        Console.WriteLine(p2.Position); //F6
        Console.WriteLine($"F6: {p2.Enter("F6")}"); //false
        Console.WriteLine(p2.Position); //F6

       // Piece osztály teszt: Mark függvény
        Console.WriteLine();
        Console.WriteLine("Piece teszt: Mark");
        Piece p3 = new Rook("A2");
        Piece p4 = new King("F6");
        Console.WriteLine(p3.Mark()); // R
        Console.WriteLine(p4.Mark()); // K

        // Bishop osztály teszt
        Console.WriteLine();
        Console.WriteLine("Bishop teszt");
        Piece bishop = new Bishop("F4");
        Console.WriteLine(bishop.Mark()); // B
        Console.WriteLine($"F4: {bishop.CanEnter("F4")}"); //false
        Console.WriteLine($"F5: {bishop.CanEnter("F5")}"); //false
        Console.WriteLine($"E5: {bishop.CanEnter("E5")}"); //true
        Console.WriteLine($"D6: {bishop.CanEnter("D6")}"); //true
        Console.WriteLine($"C7: {bishop.CanEnter("C7")}"); //true
        Console.WriteLine($"B8: {bishop.CanEnter("B8")}"); //true
        Console.WriteLine($"E3: {bishop.CanEnter("E3")}"); //true
        Console.WriteLine($"H2: {bishop.CanEnter("H2")}"); //true
        Console.WriteLine($"D2: {bishop.CanEnter("D2")}"); //true
        Console.WriteLine($"D1: {bishop.CanEnter("D1")}"); //false
        Console.WriteLine($"D7: {bishop.Enter("D7")}"); //false
        Console.WriteLine(bishop.Position); //F4
        Console.WriteLine($"H6: {bishop.Enter("H6")}"); //true
        Console.WriteLine(bishop.Position); //H6
        Console.WriteLine($"F3: {bishop.Enter("F3")}"); //false
        Console.WriteLine(bishop.Position); //H6
        Console.WriteLine($"C1: {bishop.Enter("C1")}"); //true
        Console.WriteLine(bishop.Position); //C1

        // Queen osztály teszt
        Console.WriteLine();
        Console.WriteLine("Queen teszt");
        Piece queen = new Queen("A5");
        Console.WriteLine(queen.Mark()); // Q
        Console.WriteLine($"A5: {queen.CanEnter("A5")}"); //false
        Console.WriteLine($"F5: {queen.CanEnter("F5")}"); //true
        Console.WriteLine($"A8: {queen.CanEnter("A8")}"); //true
        Console.WriteLine($"B6: {queen.CanEnter("B6")}"); //true
        Console.WriteLine($"C7: {queen.CanEnter("C7")}"); //true
        Console.WriteLine($"D8: {queen.CanEnter("D8")}"); //true
        Console.WriteLine($"C3: {queen.CanEnter("C3")}"); //true
        Console.WriteLine($"E1: {queen.CanEnter("E1")}"); //true
        Console.WriteLine($"G3: {queen.CanEnter("G3")}"); //false
        Console.WriteLine($"D1: {queen.CanEnter("D1")}"); //false
        Console.WriteLine($"H6: {queen.Enter("H6")}"); //false
        Console.WriteLine(queen.Position); //A5
        Console.WriteLine($"H5: {queen.Enter("H5")}"); //true
        Console.WriteLine(queen.Position); //H5
        Console.WriteLine($"F8: {queen.Enter("F8")}"); //false
        Console.WriteLine(queen.Position); //H5
        Console.WriteLine($"E8: {queen.Enter("E8")}"); //true
        Console.WriteLine(queen.Position); //E8

        // Knight osztály teszt
        Console.WriteLine();
        Console.WriteLine("Knight teszt");
        Piece knight = new Knight("D4");
        Console.WriteLine(knight.Mark()); // N
        Console.WriteLine($"D4: {knight.CanEnter("D4")}"); //false
        Console.WriteLine($"E2: {knight.CanEnter("E2")}"); //true
        Console.WriteLine($"F3: {knight.CanEnter("F3")}"); //true
        Console.WriteLine($"F5: {knight.CanEnter("F5")}"); //true
        Console.WriteLine($"E6: {knight.CanEnter("E6")}"); //true
        Console.WriteLine($"C6: {knight.CanEnter("C6")}"); //true
        Console.WriteLine($"B5: {knight.CanEnter("B5")}"); //true
        Console.WriteLine($"B3: {knight.CanEnter("B3")}"); //true
        Console.WriteLine($"C2: {knight.CanEnter("C2")}"); //true
        Console.WriteLine($"D1: {knight.CanEnter("D1")}"); //false

        Console.WriteLine($"H6: {knight.Enter("H6")}"); //false
        Console.WriteLine(knight.Position); //D4
        Console.WriteLine($"E6: {knight.Enter("E6")}"); //true
        Console.WriteLine(knight.Position); //E6
        Console.WriteLine($"D7: {knight.Enter("D7")}"); //false
        Console.WriteLine(knight.Position); //E6
        Console.WriteLine($"D8: {knight.Enter("D8")}"); //true
        Console.WriteLine(knight.Position); //D8
    }
}