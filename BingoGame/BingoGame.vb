'Alexis Villagran

Option Compare Binary
Option Strict On
Option Explicit On

Module BingoGame

    Sub Main()
        DisplayBoard()
    End Sub

    Function BingoTracker(ballNumber As Integer, ballLetter As Integer) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean

        Return _bingoTracker
    End Function

    Sub DisplayBoard()
        Dim temp As String = "X |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}

        For Each letter In heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next

        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))

        For i = 1 To 15
            For j = 1 To 5
                temp = temp.PadLeft(4)
                Console.Write(temp)
            Next
            Console.WriteLine()
        Next
    End Sub
    Function RandomNumberBetween(max As Integer, min As Integer) As Integer
        Dim temp As Single
        Randomize()
        temp = Rnd()
        'temp *= max - min establishes range
        temp *= max - min + 1 'The +1 makes range bigger by 1 to fix inlusivity max/min

        temp += min '- 1 '-1 shifts range down to fix the ceiling 

        'Return CInt(Int(temp)) 'Randomness is good but max is not included
        'Return Cint(temp) 'Not Good Randomness
        'Return CInt(Math.Ceiling(temp)) 'Randomness is good but min is not included
        Return CInt(Math.Floor(temp)) 'Randomness is good but max is not included
    End Function

End Module
