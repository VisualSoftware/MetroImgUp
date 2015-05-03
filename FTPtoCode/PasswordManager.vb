'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: PasswordManager.vb
'
'    This program is free software; you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation; either version 2 of the License, or
'    (at your option) any later version.
'
'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License along
'    with this program; if not, write to the Free Software Foundation, Inc.,
'    51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
'
'============================================================================

Public Class PasswordManager

    Dim lngstart As String

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'saving imgup
        If TextBox3.Text = "" Then

        Else
            IO.File.WriteAllText("Data\imgup_acc.txt", TextBox3.Text)
            IO.File.WriteAllText("Data\imgup_pwd.txt", TextBox4.Text)
        End If
        'saving fwlink
        If TextBox1.Text = "" Then

        Else
            IO.File.WriteAllText("Data\fwlink_acc.txt", TextBox1.Text)
            IO.File.WriteAllText("Data\fwlink_pwd.txt", TextBox2.Text)
        End If
        'saving global
        If IO.File.Exists("Data\FirstStart.dat") = True Then
        Else
            IO.File.Create("Data\FirstStart.dat")
        End If
        'loading all
        'LOADING IMGUP ACCOUNT
        If IO.File.Exists("Data\imgup_acc.txt") = True Then
            My.Forms.Form1.imgupacc = TextBox3.Text
            My.Forms.Form1.imguppwd = TextBox4.Text
        Else
        End If
        'LOADING FWLINK ACCOUNT
        If IO.File.Exists("Data\fwlink_acc.txt") = True Then
            My.Forms.Form1.fwacc = TextBox1.Text
            My.Forms.Form1.fwpwd = TextBox2.Text
        End If
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        TextBox4.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        TextBox1.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        TextBox2.Text = Clipboard.GetText()
    End Sub

    Private Sub PasswordManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim uextheme As String
        SuperTabControl2.SelectedTab = SuperTabItem12
        If IO.File.Exists("Data\UIColor.dat") = True Then
            uextheme = IO.File.ReadAllText("Data\UIColor.dat")
            ComboBoxEx2.SelectedIndex = uextheme
        Else
            ComboBoxEx2.SelectedIndex = "3"
        End If
        If IO.File.Exists("Data\imgup_acc.txt") = True Then
            TextBox3.Text = IO.File.ReadAllText("Data\imgup_acc.txt")
            TextBox4.Text = IO.File.ReadAllText("Data\imgup_pwd.txt")
        End If
        If IO.File.Exists("Data\FTP.dat") = True Then
            TextBox7.Text = IO.File.ReadAllText("Data\FTP.dat")
            ButtonX11.Enabled = True
        End If
        If IO.File.Exists("Data\HTTP.dat") = True Then
            TextBox8.Text = IO.File.ReadAllText("Data\HTTP.dat")
            ButtonX11.Enabled = True
        End If
        If IO.File.Exists("Data\IP.dat") = True Then
            TextBox9.Text = IO.File.ReadAllText("Data\IP.dat")
            ButtonX11.Enabled = True

        End If
        If IO.File.Exists("Data\fwlink_acc.txt") = True Then
            TextBox1.Text = IO.File.ReadAllText("Data\fwlink_acc.txt")
            TextBox2.Text = IO.File.ReadAllText("Data\fwlink_pwd.txt")
        End If
        lngstart = "1"
        If IO.File.Exists("Data\Language.dat") = True Then
            Dim applang As String
            applang = IO.File.ReadAllText("Data\Language.dat")
            If applang = "en-US" Then
                ComboBoxEx1.SelectedIndex = "0"
            ElseIf applang = "es-ES" Then
                ComboBoxEx1.SelectedIndex = "1"
            ElseIf applang = "fr-FR" Then
                ComboBoxEx1.SelectedIndex = "2"
            ElseIf applang = "de-DE" Then
                ComboBoxEx1.SelectedIndex = "3"
            ElseIf applang = "he-IL" Then
                ComboBoxEx1.SelectedIndex = "4"
            ElseIf applang = "ru-RU" Then
                ComboBoxEx1.SelectedIndex = "5"
            Else
                ComboBoxEx1.SelectedIndex = "0"
            End If
        Else
            ComboBoxEx1.SelectedIndex = "0"
        End If
        lngstart = "0"
    End Sub

    Private Sub PasswordManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Forms.Form1.ButtonItem2.Enabled = True
        If TextBox7.Text = "" Then

        Else
            IO.File.WriteAllText("Data\FTP.dat", TextBox7.Text)
            My.Forms.Form1.GlobalFTPServer = TextBox7.Text
        End If
        If TextBox8.Text = "" Then

        Else
            IO.File.WriteAllText("Data\HTTP.dat", TextBox8.Text)
            My.Forms.Form1.GlobalHTTPServer = TextBox8.Text
            If TextBox8.Text.Contains("www.") = True Then
                My.Forms.Form1.GlobalHTTPServer2 = TextBox8.Text.Replace("www.", "")
            Else
                My.Forms.Form1.GlobalHTTPServer2 = TextBox8.Text
            End If
        End If
        If TextBox9.Text = "" Then

        Else
            IO.File.WriteAllText("Data\IP.dat", TextBox9.Text)
            My.Forms.Form1.GlobalServerIP = TextBox9.Text
        End If
        If ComboBoxEx1.SelectedIndex = "0" Then
            IO.File.WriteAllText("Data\Language.dat", "en-US")
        ElseIf ComboBoxEx1.SelectedIndex = "1" Then
            IO.File.WriteAllText("Data\Language.dat", "es-ES")
        ElseIf ComboBoxEx1.SelectedIndex = "2" Then
            IO.File.WriteAllText("Data\Language.dat", "fr-FR")
        ElseIf ComboBoxEx1.SelectedIndex = "3" Then
            IO.File.WriteAllText("Data\Language.dat", "de-DE")
        ElseIf ComboBoxEx1.SelectedIndex = "4" Then
            IO.File.WriteAllText("Data\Language.dat", "he-IL")
        ElseIf ComboBoxEx1.SelectedIndex = "5" Then
            IO.File.WriteAllText("Data\Language.dat", "ru-RU")
        Else
            IO.File.WriteAllText("Data\Language.dat", "en-US")
        End If
    End Sub

    Private Sub ComboBoxEx2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx2.SelectedIndexChanged
        If ComboBoxEx2.SelectedIndex = "0" Then
            'RED
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(242, 12, 39))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(242, 12, 39)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(242, 12, 39)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(242, 12, 39)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(242, 12, 39)
            IO.File.WriteAllText("Data\UIColor.dat", "0")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "1" Then
            'ORANGE
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(242, 146, 12))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(242, 146, 12)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(242, 146, 12)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(242, 146, 12)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(242, 146, 12)
            IO.File.WriteAllText("Data\UIColor.dat", "1")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "2" Then
            'GREEN
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(39, 214, 44))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(39, 214, 44)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(39, 214, 44)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(39, 214, 44)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(39, 214, 44)
            IO.File.WriteAllText("Data\UIColor.dat", "2")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "3" Then
            'BLUE
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(69, 150, 232))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(69, 150, 232)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(69, 150, 232)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(69, 150, 232)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(69, 150, 232)
            IO.File.WriteAllText("Data\UIColor.dat", "3")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "4" Then
            'PURPLE
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(163, 16, 196))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(163, 16, 196)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(163, 16, 196)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(163, 16, 196)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(163, 16, 196)
            IO.File.WriteAllText("Data\UIColor.dat", "4")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "5" Then
            'GRAY
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(204, 200, 204))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(204, 200, 204)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(204, 200, 204)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(204, 200, 204)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(204, 200, 204)
            IO.File.WriteAllText("Data\UIColor.dat", "5")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "6" Then
            'BROWN
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(123, 45, 32))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(123, 45, 32)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(123, 45, 32)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(123, 45, 32)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(123, 45, 32)
            IO.File.WriteAllText("Data\UIColor.dat", "6")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "7" Then
            'YELLOW
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(247, 244, 62))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(247, 244, 62)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(247, 244, 62)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(247, 244, 62)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(247, 244, 62)
            IO.File.WriteAllText("Data\UIColor.dat", "7")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "8" Then
            'PINK
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(250, 35, 232))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(250, 35, 232)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(250, 35, 232)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(250, 35, 232)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(250, 35, 232)
            IO.File.WriteAllText("Data\UIColor.dat", "8")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "9" Then
            'BLACK
            My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.Black, System.Drawing.Color.FromArgb(0, 0, 0))
            My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(0, 0, 0)
            My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(0, 0, 0)
            My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(0, 0, 0)
            My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(0, 0, 0)
            IO.File.WriteAllText("Data\UIColor.dat", "9")
        Else

        End If
        If ComboBoxEx2.SelectedIndex = "10" Then
            'CUSTOM
            ColorPickerButton1.Enabled = True
            If IO.File.Exists("Data\CustomUIColor.dat") = True Then
                ColorPickerButton1.SelectedColor = System.Drawing.Color.FromArgb(IO.File.ReadAllText("Data\CustomUIColor.dat"))
            Else

            End If
            IO.File.WriteAllText("Data\UIColor.dat", "10")
        Else
            ColorPickerButton1.Enabled = False
        End If
    End Sub

    Private Sub ColorPickerButton1_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPickerButton1.SelectedColorChanged
        ColorPickerButton1.Text = ColorPickerButton1.SelectedColor.ToString
        My.Forms.Form1.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(ColorPickerButton1.SelectedColor.ToArgb))
        My.Forms.Form1.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(ColorPickerButton1.SelectedColor.ToArgb)
        My.Forms.Form1.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(ColorPickerButton1.SelectedColor.ToArgb)
        My.Forms.Form2.CircularProgress1.ProgressColor = System.Drawing.Color.FromArgb(ColorPickerButton1.SelectedColor.ToArgb)
        My.Forms.Form2.CircularProgress1.ProgressTextColor = System.Drawing.Color.FromArgb(ColorPickerButton1.SelectedColor.ToArgb)
        IO.File.WriteAllText("Data\CustomUIColor.dat", ColorPickerButton1.SelectedColor.ToArgb)
    End Sub

    Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        TextBox7.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        TextBox8.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        TextBox9.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX11_Click(sender As Object, e As EventArgs) Handles ButtonX11.Click
        Dim newconfirm As Object
        newconfirm = MessageBox.Show("Are you sure you want to remove all server configuration files?", "Delete server configuration files", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If newconfirm = vbYes Then
            If IO.File.Exists("Data\FTP.dat") = True Then
                IO.File.Delete("Data\FTP.dat")
                TextBox7.Text = ""
            Else

            End If
            If IO.File.Exists("Data\HTTP.dat") = True Then
                IO.File.Delete("Data\HTTP.dat")
                TextBox8.Text = ""
            Else

            End If
            If IO.File.Exists("Data\IP.dat") = True Then
                IO.File.Delete("Data\IP.dat")
                TextBox9.Text = ""
            Else

            End If
            MessageBox.Show("Successfully removed all server configuration files.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonX11.Enabled = False
        ElseIf newconfirm = vbNo Then

        End If
    End Sub
    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "" Then
            WarningBox5.Visible = True
        Else
            If TextBox8.Text = "" Then
                WarningBox5.Visible = True
            Else
                If TextBox9.Text = "" Then
                    WarningBox5.Visible = True
                Else
                    WarningBox5.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then
            WarningBox5.Visible = True
        Else
            If TextBox7.Text = "" Then
                WarningBox5.Visible = True
            Else
                If TextBox9.Text = "" Then
                    WarningBox5.Visible = True
                Else
                    WarningBox5.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text = "" Then
            WarningBox5.Visible = True
        Else
            If TextBox8.Text = "" Then
                WarningBox5.Visible = True
            Else
                If TextBox7.Text = "" Then
                    WarningBox5.Visible = True
                Else
                    WarningBox5.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        Dim newapplang As String
        If ComboBoxEx1.SelectedIndex = "0" Then
            newapplang = "en-US"
        ElseIf ComboBoxEx1.SelectedIndex = "1" Then
            newapplang = "es-ES"
        ElseIf ComboBoxEx1.SelectedIndex = "2" Then
            newapplang = "fr-FR"
        ElseIf ComboBoxEx1.SelectedIndex = "3" Then
            newapplang = "de-DE"
        ElseIf ComboBoxEx1.SelectedIndex = "4" Then
            newapplang = "he-IL"
        ElseIf ComboBoxEx1.SelectedIndex = "5" Then
            newapplang = "ru-RU"
        Else
            newapplang = "en-US"
        End If
        If lngstart = "1" Then

        Else
            MessageBox.Show("Please restart the application to load the selected language file." & vbCrLf & vbCrLf & "Current Language: " & My.Forms.Globalization.applang & " | New Language: " & newapplang, "Language successfully changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class