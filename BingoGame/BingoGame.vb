'Alexis Villagran

Option Compare Binary
Option Strict On
Option Explicit On

Module BingoGame

    Sub Main()
        For i = 1 To 10

            Drawball()
            DisplayBoard()
            Console.Read()
            Console.Clear()
        Next

    End Sub

    Sub Drawball()
        Dim temp(,) As Boolean = BingoTracker(0, 0)
        Dim currentBallNumber As Integer
        Dim currentBallInteger As Integer

        Do
            currentBallNumber = RandomNumberBetween(0, 14)
            currentBallInteger = RandomNumberBetween(0, 4)
        Loop Until temp(currentBallNumber, currentBallInteger) = False

        BingoTracker(currentBallNumber, currentBallInteger)
        Console.WriteLine($"The current row is {currentBallNumber} and the column is {currentBallInteger}")

    End Sub
    Function BingoTracker(ballNumber As Integer, ballLetter As Integer) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean

        _bingoTracker(ballNumber, ballLetter) = True

        Return _bingoTracker
    End Function

    Sub DisplayBoard()
        Dim temp As String = " |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0)

        For Each letter In heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next

        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))

        For currentNumber = 1 To 14
            For currentInteger = 1 To 4

                If tracker(currentNumber, currentInteger) Then
                    temp = "X |"
                Else
                    temp = " |"
                End If
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
