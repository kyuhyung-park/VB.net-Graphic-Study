Public Class Form1

    Dim pens(4) As Pen
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pens(0) = New Pen(Color.FromArgb(255, 219, 227))
        pens(1) = New Pen(Color.FromArgb(255, 166, 180))
        pens(2) = New Pen(Color.FromArgb(255, 122, 130))
        pens(3) = New Pen(Color.FromArgb(255, 78, 85))
        pens(4) = New Pen(Color.FromArgb(255, 1, 1))
    End Sub

    Dim dataQueue As New Queue()
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim arrays(4) As Integer

        arrays(0) = CInt(TextBox1.Text)
        arrays(1) = CInt(TextBox2.Text)
        arrays(2) = CInt(TextBox3.Text)
        arrays(3) = CInt(TextBox4.Text)
        arrays(4) = CInt(TextBox5.Text)

        For Each element As Integer In arrays
            Console.Write(element)
            Console.Write(" ")
        Next
        Console.WriteLine()

        dataQueue.Enqueue(arrays)
        If dataQueue.Count > 5 Then
            dataQueue.Dequeue()
        End If

        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim leftOffset As Single
        Dim topOffset As Single

        leftOffset = PictureBox1.Size.Width * 0.05
        topOffset = PictureBox1.Size.Height * 0.1

        e.Graphics.DrawLine(New Pen(Color.Black), leftOffset, 0, leftOffset, PictureBox1.Size.Height)
        e.Graphics.DrawLine(New Pen(Color.Black), PictureBox1.Size.Width - leftOffset, 0, PictureBox1.Size.Width - leftOffset, PictureBox1.Size.Height)

        Dim range As Single
        Dim barWidth As Single
        range = CInt(TextBox8.Text) - CInt(TextBox7.Text)
        barWidth = PictureBox1.Size.Width - leftOffset * 2
        Console.WriteLine("range:" & range)
        Console.WriteLine("barWidth:" & barWidth)
        Console.WriteLine("leftOffset:" & leftOffset)

        Dim count = 0
        Dim point As Single
        For Each data As Integer() In dataQueue
            For Each element As Integer In data
                point = (((element - CInt(TextBox7.Text)) * barWidth) / range) + leftOffset
                Console.WriteLine("point:" & point)
                e.Graphics.DrawLine(pens(count), point, topOffset, point, PictureBox1.Size.Height - (topOffset * 2))
            Next
            count = count + 1
        Next
    End Sub

End Class
