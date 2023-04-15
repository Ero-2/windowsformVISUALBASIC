Imports System.Diagnostics.Contracts
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Partial Public Class Form1
    Inherits Form

    Private personas As Integer = 0
    Private registrados As Integer = 0
    Private cantidad As Integer = 0
    Private arreglo As contacto()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (registrados < cantidad) Then
            Dim nuevocontacto = New contacto()
            nuevocontacto.FechaDenacimiento_ = DateTimePicker1.Value
            nuevocontacto.Nombre_ = nombre.Text
            nuevocontacto.telefono_ = telefono.Text
            nuevocontacto.correoElectronico = txtcorreo.Text
            arreglo(registrados) = nuevocontacto
            registrados = registrados + 1
            Dim nuevaLinea As String = nuevocontacto.Nombre_ & ", " + nuevocontacto.Edad.ToString() & ", " + nuevocontacto.telefono_.ToString() & ", " + nuevocontacto.correoElectronico.ToString() + Environment.NewLine
            Lbl1.Text = Lbl1.Text & nuevaLinea
        Else
            MessageBox.Show("No se pueden registrar más personas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged
        Dim valor As Integer

        If Integer.TryParse(txttelefono.Text, valor) Then
            cantidad = valor
            registrados = 0
            arreglo = New contacto(cantidad + 1 - 1) {}
        Else
            MessageBox.Show("Debe ingresar un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txttelefono.Text = ""
            cantidad = 0
            registrados = 0
            arreglo = New contacto(cantidad + 1 - 1) {}
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim lector As OpenFileDialog = New OpenFileDialog()
        lector.Filter = "Nombre del Archivo|*.txt"

        If lector.ShowDialog() = DialogResult.OK Then
            Dim abrir As StreamReader = New StreamReader(lector.FileName)
            Lbl1.Text = abrir.ReadToEnd()
            abrir.Close()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim guardarArchivo As SaveFileDialog = New SaveFileDialog()
        guardarArchivo.Filter = "Archivos de texto|*.txt"
        guardarArchivo.Title = "Guardar archivo de contactos"
        guardarArchivo.FileName = "contactos.txt"

        If guardarArchivo.ShowDialog() = DialogResult.OK Then

            Using archivo As StreamWriter = New StreamWriter(guardarArchivo.FileName)

                For i As Integer = 0 To registrados - 1
                    archivo.WriteLine(arreglo(i).Nombre_ & "," + arreglo(i).Edad.ToString() & "," + arreglo(i).telefono_ & "," + arreglo(i).correoElectronico)
                Next
            End Using
        End If

    End Sub
End Class


