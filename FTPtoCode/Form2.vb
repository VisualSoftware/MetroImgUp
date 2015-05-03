'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: Form2.vb
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

Public Class Form2
    Dim newftpfileA As String
    Dim newftpfileB As String
    Dim newftpfileC As String
    Dim newftpfileD As String
    Dim newftpfileE As String
    Dim newftpfilenameA As String
    Dim newftpfilenameB As String
    Dim newftpfilenameC As String
    Dim newftpfilenameD As String
    Dim newftpfilenameE As String
    Dim filextension123 As String
    Dim newextension As String
    Dim errormsg1 As String
    Dim errormsg2 As String
    Dim errormsg3 As String
    Dim errormsg4 As String
    Dim errormsg5 As String
    Dim imgupacc As String
    Dim imguppwd As String
    Dim erradd1 As String
    Dim erradd2 As String
    Dim erradd3 As String
    Dim erradd4 As String
    Dim erradd5 As String

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then

        Else
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog2.ShowDialog()
        If OpenFileDialog2.FileName = "" Then

        Else
            TextBox3.Text = OpenFileDialog2.FileName
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        OpenFileDialog3.ShowDialog()
        If OpenFileDialog3.FileName = "" Then

        Else
            TextBox2.Text = OpenFileDialog3.FileName
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        OpenFileDialog4.ShowDialog()
        If OpenFileDialog4.FileName = "" Then

        Else
            TextBox4.Text = OpenFileDialog4.FileName
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        OpenFileDialog5.ShowDialog()
        If OpenFileDialog5.FileName = "" Then

        Else
            TextBox6.Text = OpenFileDialog5.FileName
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox8.Text = ""
        TextBox5.Text = ""
        WarningBox2.Visible = False
        PictureBox1.Image = PictureBox8.Image
        PictureBox2.Image = PictureBox8.Image
        PictureBox3.Image = PictureBox8.Image
        PictureBox4.Image = PictureBox8.Image
        PictureBox5.Image = PictureBox8.Image
        errormsg1 = ""
        errormsg2 = ""
        errormsg3 = ""
        errormsg4 = ""
        errormsg5 = ""
        ToolTip1.SetToolTip(PictureBox1, "")
        ToolTip1.SetToolTip(PictureBox2, "")
        ToolTip1.SetToolTip(PictureBox3, "")
        ToolTip1.SetToolTip(PictureBox4, "")
        ToolTip1.SetToolTip(PictureBox5, "")
        Label6.Text = "0"
        ButtonX1.Enabled = False
        ButtonX2.Enabled = False
        ButtonX3.Enabled = False
        ButtonX4.Enabled = False
        ButtonX5.Enabled = False
        ButtonX6.Enabled = False
        ButtonX7.Enabled = False
        ButtonX8.Enabled = False
        ButtonX9.Enabled = False
        Button9.Enabled = False
        TextBox1.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox1.AllowDrop = False
        TextBox3.AllowDrop = False
        TextBox2.AllowDrop = False
        TextBox4.AllowDrop = False
        TextBox6.AllowDrop = False
        Button6.Visible = False
        Button10.Visible = False
        CheckBox2.Enabled = False
        Timer1.Enabled = True
        SuperTabItem2.Visible = False
        CircularProgress1.Visible = True
        If TextBox1.Text = "" Then
            Label6.Text = Val(Label6.Text) + 1
            TextBox1.ReadOnly = False
            TextBox1.AllowDrop = True
            ButtonX1.Enabled = True
            PictureBox1.Visible = True
            ToolTip1.SetToolTip(PictureBox1, errormsg1)
            If TextBox1.Text = "" Then
                ButtonX5.Enabled = False
            Else
                ButtonX5.Enabled = True
            End If
        Else
            newftpfilenameA = My.Forms.Form1.MD5CalcFile(TextBox1.Text) & TextBox1.Text.Remove(0, TextBox1.Text.Length - 5)
            BackgroundWorker1.RunWorkerAsync()
        End If
        If TextBox3.Text = "" Then
            Label6.Text = Val(Label6.Text) + 1
            TextBox3.ReadOnly = False
            TextBox3.AllowDrop = True
            Button9.Enabled = True
            PictureBox2.Visible = True
            ToolTip1.SetToolTip(PictureBox2, errormsg2)
            If TextBox3.Text = "" Then
                ButtonX6.Enabled = False
            Else
                ButtonX6.Enabled = True
            End If
        Else
            newftpfilenameB = My.Forms.Form1.MD5CalcFile(TextBox3.Text) & TextBox3.Text.Remove(0, TextBox3.Text.Length - 5)
            BackgroundWorker2.RunWorkerAsync()
        End If
        If TextBox2.Text = "" Then
            Label6.Text = Val(Label6.Text) + 1
            TextBox2.ReadOnly = False
            TextBox2.AllowDrop = True
            ButtonX2.Enabled = True
            PictureBox3.Visible = True
            ToolTip1.SetToolTip(PictureBox3, errormsg3)
            If TextBox2.Text = "" Then
                ButtonX7.Enabled = False
            Else
                ButtonX7.Enabled = True
            End If
        Else
            newftpfilenameC = My.Forms.Form1.MD5CalcFile(TextBox2.Text) & TextBox2.Text.Remove(0, TextBox2.Text.Length - 5)
            BackgroundWorker3.RunWorkerAsync()
        End If
        If TextBox4.Text = "" Then
            Label6.Text = Val(Label6.Text) + 1
            TextBox4.ReadOnly = False
            TextBox4.AllowDrop = True
            ButtonX3.Enabled = True
            PictureBox4.Visible = True
            ToolTip1.SetToolTip(PictureBox4, errormsg4)
            If TextBox4.Text = "" Then
                ButtonX8.Enabled = False
            Else
                ButtonX8.Enabled = True
            End If
        Else
            newftpfilenameD = My.Forms.Form1.MD5CalcFile(TextBox4.Text) & TextBox4.Text.Remove(0, TextBox4.Text.Length - 5)
            BackgroundWorker4.RunWorkerAsync()
        End If
        If TextBox6.Text = "" Then
            Label6.Text = Val(Label6.Text) + 1
            TextBox6.ReadOnly = False
            TextBox6.AllowDrop = True
            ButtonX4.Enabled = True
            PictureBox5.Visible = True
            ToolTip1.SetToolTip(PictureBox5, errormsg5)
            If TextBox6.Text = "" Then
                ButtonX9.Enabled = False
            Else
                ButtonX9.Enabled = True
            End If
        Else
            newftpfilenameE = My.Forms.Form1.MD5CalcFile(TextBox6.Text) & TextBox6.Text.Remove(0, TextBox6.Text.Length - 5)
            BackgroundWorker5.RunWorkerAsync()
        End If
        If CheckBox2.Checked = True Then
            newftpfileA = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newftpfilenameA
            newftpfileB = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newftpfilenameB
            newftpfileC = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newftpfilenameC
            newftpfileD = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newftpfilenameD
            newftpfileE = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newftpfilenameE
        Else
            newftpfileA = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newftpfilenameA
            newftpfileB = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newftpfilenameB
            newftpfileC = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newftpfilenameC
            newftpfileD = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newftpfilenameD
            newftpfileE = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newftpfilenameE
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            My.Computer.Network.UploadFile(TextBox1.Text, newftpfileA, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            PictureBox1.Image = PictureBox7.Image
            errormsg1 = ex.Message
            erradd1 = "1"
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            My.Computer.Network.UploadFile(TextBox3.Text, newftpfileB, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            PictureBox2.Image = PictureBox7.Image
            errormsg2 = ex.Message
            erradd2 = "1"
        End Try
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Try
            My.Computer.Network.UploadFile(TextBox2.Text, newftpfileC, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            PictureBox3.Image = PictureBox7.Image
            errormsg3 = ex.Message
            erradd3 = "1"
        End Try
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Try
            My.Computer.Network.UploadFile(TextBox4.Text, newftpfileD, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            PictureBox4.Image = PictureBox7.Image
            errormsg4 = ex.Message
            erradd4 = "1"
        End Try
    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        Try
            My.Computer.Network.UploadFile(TextBox6.Text, newftpfileE, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            PictureBox5.Image = PictureBox7.Image
            errormsg5 = ex.Message
            erradd5 = "1"
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If erradd1 = "1" Then
            erradd1 = "0"
        Else
            PictureBox1.Image = PictureBox6.Image
            TextBox1.Text = ""
            If CheckBox2.Checked = True Then
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameA & "[/IMG]" & vbCrLf
            Else
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameA & "[/IMG]" & vbCrLf
            End If
            If CheckBox2.Checked = True Then
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameA & vbCrLf
            Else
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameA & vbCrLf
            End If
        End If
        Label6.Text = Val(Label6.Text) + 1
        TextBox1.ReadOnly = False
        TextBox1.AllowDrop = True
        ButtonX1.Enabled = True
        PictureBox1.Visible = True
        ToolTip1.SetToolTip(PictureBox1, errormsg1)
        If TextBox1.Text = "" Then
            ButtonX5.Enabled = False
        Else
            ButtonX5.Enabled = True
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Clipboard.SetText(TextBox8.Text)
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Clipboard.SetText(TextBox5.Text)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CircularProgress1.Value = CircularProgress1.Value + 1
        If errormsg1 = "" Then

        Else
            WarningBox2.Visible = True
        End If
        If errormsg2 = "" Then

        Else
            WarningBox2.Visible = True
        End If
        If errormsg3 = "" Then

        Else
            WarningBox2.Visible = True
        End If
        If errormsg4 = "" Then

        Else
            WarningBox2.Visible = True
        End If
        If errormsg5 = "" Then

        Else
            WarningBox2.Visible = True
        End If
        If Label6.Text = "5" Then
            Button6.Visible = True
            Button10.Visible = True
            Timer1.Enabled = False
            CheckBox2.Enabled = True
            CircularProgress1.Visible = False
            SuperTabItem2.Visible = True
            Dim oldlog As String
            Dim oldlog1 As String
            Dim newlog As String
            Dim newlog1 As String
            oldlog = ""
            If IO.File.Exists("Data\metroimgup_multi.log") = True Then
                oldlog = IO.File.ReadAllText("Data\metroimgup_multi.log")
            Else

            End If
            newlog = oldlog & TextBox8.Text
            My.Computer.FileSystem.WriteAllText("Data\metroimgup_multi.log", newlog, False)
            Button8.Enabled = True
            oldlog1 = ""
            If IO.File.Exists("Data\metroimgup_multi_dl.log") = True Then
                oldlog1 = IO.File.ReadAllText("Data\metroimgup_multi_dl.log")
            Else

            End If
            newlog1 = oldlog1 & TextBox5.Text
            My.Computer.FileSystem.WriteAllText("Data\metroimgup_multi_dl.log", newlog1, False)
            ButtonItem2.Enabled = True
        Else

        End If
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If erradd2 = "1" Then
            erradd2 = "0"
        Else
            PictureBox2.Image = PictureBox6.Image
            TextBox3.Text = ""
            If CheckBox2.Checked = True Then
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameB & "[/IMG]" & vbCrLf
            Else
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameB & "[/IMG]" & vbCrLf
            End If
            If CheckBox2.Checked = True Then
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameB & vbCrLf
            Else
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameB & vbCrLf
            End If
        End If
        Label6.Text = Val(Label6.Text) + 1
        TextBox3.ReadOnly = False
        TextBox3.AllowDrop = True
        Button9.Enabled = True
        PictureBox2.Visible = True
        ToolTip1.SetToolTip(PictureBox2, errormsg2)
        If TextBox3.Text = "" Then
            ButtonX6.Enabled = False
        Else
            ButtonX6.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        If erradd3 = "1" Then
            erradd3 = "0"
        Else
            PictureBox3.Image = PictureBox6.Image
            TextBox2.Text = ""
            If CheckBox2.Checked = True Then
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameC & "[/IMG]" & vbCrLf
            Else
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameC & "[/IMG]" & vbCrLf
            End If
            If CheckBox2.Checked = True Then
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameC & vbCrLf
            Else
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameC & vbCrLf
            End If
        End If
        Label6.Text = Val(Label6.Text) + 1
        TextBox2.ReadOnly = False
        TextBox2.AllowDrop = True
        ButtonX2.Enabled = True
        PictureBox3.Visible = True
        ToolTip1.SetToolTip(PictureBox3, errormsg3)
        If TextBox2.Text = "" Then
            ButtonX7.Enabled = False
        Else
            ButtonX7.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        If erradd4 = "1" Then
            erradd4 = "0"
        Else
            PictureBox4.Image = PictureBox6.Image
            TextBox4.Text = ""
            If CheckBox2.Checked = True Then
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameD & "[/IMG]" & vbCrLf
            Else
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameD & "[/IMG]" & vbCrLf
            End If
            If CheckBox2.Checked = True Then
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameD & vbCrLf
            Else
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameD & vbCrLf
            End If
        End If
        Label6.Text = Val(Label6.Text) + 1
        TextBox4.ReadOnly = False
        TextBox4.AllowDrop = True
        ButtonX3.Enabled = True
        PictureBox4.Visible = True
        ToolTip1.SetToolTip(PictureBox4, errormsg4)
        If TextBox4.Text = "" Then
            ButtonX8.Enabled = False
        Else
            ButtonX8.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker5_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker5.RunWorkerCompleted
        If erradd5 = "1" Then
            erradd5 = "0"
        Else
            PictureBox5.Image = PictureBox6.Image
            TextBox6.Text = ""
            If CheckBox2.Checked = True Then
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameE & "[/IMG]" & vbCrLf
            Else
                TextBox8.Text = TextBox8.Text & "[IMG]http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameE & "[/IMG]" & vbCrLf
            End If
            If CheckBox2.Checked = True Then
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/wuimguploader/autoup/" & newftpfilenameE & vbCrLf
            Else
                TextBox5.Text = TextBox5.Text & "http://" & my.forms.form1.globalhttpserver & "/publicimgup/" & newftpfilenameE & vbCrLf
            End If
        End If
        Label6.Text = Val(Label6.Text) + 1
        TextBox6.ReadOnly = False
        TextBox6.AllowDrop = True
        ButtonX4.Enabled = True
        PictureBox5.Visible = True
        ToolTip1.SetToolTip(PictureBox5, errormsg5)
        If TextBox6.Text = "" Then
            ButtonX9.Enabled = False
        Else
            ButtonX9.Enabled = True
        End If
    End Sub

    Private Sub CircularProgress1_ValueChanged(sender As Object, e As EventArgs) Handles CircularProgress1.ValueChanged
        If CircularProgress1.Value = CircularProgress1.Maximum Then
            CircularProgress1.Value = "0"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            ButtonX5.Enabled = False
            If TextBox3.Text = "" Then
                If TextBox2.Text = "" Then
                    If TextBox4.Text = "" Then
                        If TextBox6.Text = "" Then
                            Button6.Enabled = False
                        Else
                            Button6.Enabled = True
                        End If
                    Else
                        Button6.Enabled = True
                    End If
                Else
                    Button6.Enabled = True
                End If
            Else
                Button6.Enabled = True
            End If
        Else
            ButtonX5.Enabled = True
            Button6.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox1.Text = "" Then
            If TextBox3.Text = "" Then
                If TextBox2.Text = "" Then
                    If TextBox4.Text = "" Then
                        If TextBox6.Text = "" Then
                            Button6.Enabled = False
                        Else
                            Button6.Enabled = True
                        End If
                    Else
                        Button6.Enabled = True
                    End If
                Else
                    Button6.Enabled = True
                End If
            Else
                Button6.Enabled = True
            End If
        Else
            Button6.Enabled = True
        End If
        If TextBox3.Text = "" Then
            ButtonX6.Enabled = False
        Else
            ButtonX6.Enabled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox1.Text = "" Then
            If TextBox3.Text = "" Then
                If TextBox2.Text = "" Then
                    If TextBox4.Text = "" Then
                        If TextBox6.Text = "" Then
                            Button6.Enabled = False
                        Else
                            Button6.Enabled = True
                        End If
                    Else
                        Button6.Enabled = True
                    End If
                Else
                    Button6.Enabled = True
                End If
            Else
                Button6.Enabled = True
            End If
        Else
            Button6.Enabled = True
        End If
        If TextBox2.Text = "" Then
            ButtonX7.Enabled = False
        Else
            ButtonX7.Enabled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox1.Text = "" Then
            If TextBox3.Text = "" Then
                If TextBox2.Text = "" Then
                    If TextBox4.Text = "" Then
                        If TextBox6.Text = "" Then
                            Button6.Enabled = False
                        Else
                            Button6.Enabled = True
                        End If
                    Else
                        Button6.Enabled = True
                    End If
                Else
                    Button6.Enabled = True
                End If
            Else
                Button6.Enabled = True
            End If
        Else
            Button6.Enabled = True
        End If
        If TextBox4.Text = "" Then
            ButtonX8.Enabled = False
        Else
            ButtonX8.Enabled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox1.Text = "" Then
            If TextBox3.Text = "" Then
                If TextBox2.Text = "" Then
                    If TextBox4.Text = "" Then
                        If TextBox6.Text = "" Then
                            Button6.Enabled = False
                        Else
                            Button6.Enabled = True
                        End If
                    Else
                        Button6.Enabled = True
                    End If
                Else
                    Button6.Enabled = True
                End If
            Else
                Button6.Enabled = True
            End If
        Else
            Button6.Enabled = True
        End If
        If TextBox6.Text = "" Then
            ButtonX9.Enabled = False
        Else
            ButtonX9.Enabled = True
        End If
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Forms.Form1.ButtonX6.Enabled = True
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("Data\metroimgup_multi.log") = True Then
            Dim newentryline As String
            Dim logread As String
            newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
            logread = IO.File.ReadAllText("Data\metroimgup_multi.log")
            If logread.Contains(newentryline) Then

            Else
                My.Computer.FileSystem.WriteAllText("Data\metroimgup_multi.log", newentryline, True)
            End If
        Else
            Button8.Enabled = False
        End If
        If IO.File.Exists("Data\metroimgup_multi_dl.log") = True Then
            Dim newentryline As String
            Dim logread As String
            newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
            logread = IO.File.ReadAllText("Data\metroimgup_multi_dl.log")
            If logread.Contains(newentryline) Then

            Else
                My.Computer.FileSystem.WriteAllText("Data\metroimgup_multi_dl.log", newentryline, True)
            End If
        Else
            ButtonItem2.Enabled = False
        End If
        If IO.File.Exists("Data\metroimgup_mass.log") = True Then
            Dim newentryline As String
            Dim logread As String
            newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
            logread = IO.File.ReadAllText("Data\metroimgup_mass.log")
            If logread.Contains(newentryline) Then

            Else
                My.Computer.FileSystem.WriteAllText("Data\metroimgup_mass.log", newentryline, True)
            End If
        Else
            ButtonX11.Enabled = False
        End If
        If IO.File.Exists("Data\metroimgup_mass_dl.log") = True Then
            Dim newentryline As String
            Dim logread As String
            newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
            logread = IO.File.ReadAllText("Data\metroimgup_mass_dl.log")
            If logread.Contains(newentryline) Then

            Else
                My.Computer.FileSystem.WriteAllText("Data\metroimgup_mass_dl.log", newentryline, True)
            End If
        Else
            ButtonItem3.Enabled = False
        End If
        If IO.File.Exists("Data\imgup_acc.txt") = True Then
            imgupacc = IO.File.ReadAllText("Data\imgup_acc.txt")
        Else
            MessageBox.Show("The file ''imgup_acc.txt'' does not exist, Please configure your File Uploader account in the Settings form beforing using the MultiUploader", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        If IO.File.Exists("Data\imgup_pwd.txt") = True Then
            imguppwd = IO.File.ReadAllText("Data\imgup_pwd.txt")
        Else
            MessageBox.Show("The file ''imgup_pwd.txt'' does not exist, Please configure your File Uploader account in the Settings form beforing using the MultiUploader", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        CheckBox2.Visible = False
        CheckBox1.Visible = False
        CheckBox2.Checked = False
        CheckBox1.Checked = False
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then
            Button11.Enabled = False
        Else
            Button11.Enabled = True
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If IO.File.Exists("Data\metroimgup_multi.log") = True Then
            Process.Start("Data\metroimgup_multi.log")
        Else
            MessageBox.Show("Error, the MultiUpload log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        If IO.File.Exists("Data\metroimgup_multi_dl.log") = True Then
            Process.Start("Data\metroimgup_multi_dl.log")
        Else
            MessageBox.Show("Error, the MultiUpload DL log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        TextBox1.Text = ""
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        TextBox3.Text = ""
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        TextBox2.Text = ""
    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        TextBox4.Text = ""
    End Sub

    Private Sub ButtonX9_Click(sender As Object, e As EventArgs) Handles ButtonX9.Click
        TextBox6.Text = ""
    End Sub

    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                TextBox1.Text = (MyFiles(i))
            Next
        End If
    End Sub

    Private Sub TextBox3_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox3.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                TextBox3.Text = (MyFiles(i))
            Next
        End If
    End Sub

    Private Sub TextBox2_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                TextBox2.Text = (MyFiles(i))
            Next
        End If
    End Sub

    Private Sub TextBox4_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox4.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                TextBox4.Text = (MyFiles(i))
            Next
        End If
    End Sub

    Private Sub TextBox6_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox6.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                TextBox6.Text = (MyFiles(i))
            Next
        End If
    End Sub

    Private Sub TextBox3_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub TextBox2_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub TextBox4_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox4.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub TextBox6_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox6.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                ListBox1.Items.Add((MyFiles(i)))
            Next
        End If
    End Sub

    Private Sub ButtonX10_Click(sender As Object, e As EventArgs) Handles ButtonX10.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = "0"
        Else

        End If
    End Sub

    Private Sub ButtonX12_Click(sender As Object, e As EventArgs) Handles ButtonX12.Click
        OpenFileDialog6.ShowDialog()
        If OpenFileDialog6.FileName = "" Then

        Else
            ListBox1.Items.AddRange(OpenFileDialog6.FileNames)
        End If
    End Sub

    Private Sub ButtonX14_Click(sender As Object, e As EventArgs) Handles ButtonX14.Click
        Me.Close()
    End Sub

    Private Sub ButtonX15_Click(sender As Object, e As EventArgs) Handles ButtonX15.Click
        ToolTip1.SetToolTip(WarningBox1, "")
        WarningBox1.Visible = False
        TextBox9.Text = ""
        TextBox10.Text = ""
        Do While ListBox1.Items.Count > 0
            'CALCULATE CRC32
            Dim newfn As String
            Dim massupfn As String
            Dim actfile As String
            Try
                actfile = ListBox1.Items(0)
                newfn = My.Forms.Form1.MD5CalcFile(actfile) & actfile.Remove(0, actfile.Length - 5)
                If CheckBox1.Checked = True Then
                    massupfn = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/vip/autoup/" & newfn
                Else
                    massupfn = "ftp://" & My.Forms.Form1.GlobalFTPServer & "/public/" & newfn
                End If
                'UPLOAD FILE
                My.Computer.Network.UploadFile(ListBox1.Items(0), massupfn, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
                'WRITE TO LOG
                If CheckBox1.Checked = True Then
                    TextBox9.Text = TextBox9.Text & "[IMG]http://" & My.Forms.Form1.GlobalHTTPServer & "/wuimguploader/autoup/" & newfn & "[/IMG]" & vbCrLf
                Else
                    TextBox9.Text = TextBox9.Text & "[IMG]http://" & My.Forms.Form1.GlobalHTTPServer & "/publicimgup/" & newfn & "[/IMG]" & vbCrLf
                End If
                If CheckBox1.Checked = True Then
                    TextBox10.Text = TextBox10.Text & "http://" & My.Forms.Form1.GlobalHTTPServer & "/wuimguploader/autoup/" & newfn & vbCrLf
                Else
                    TextBox10.Text = TextBox10.Text & "http://" & My.Forms.Form1.GlobalHTTPServer & "/publicimgup/" & newfn & vbCrLf
                End If
                'DELETE ITEM
                ListBox1.Items.RemoveAt(0)
            Catch ex As Exception
                WarningBox1.Visible = True
                ToolTip1.SetToolTip(WarningBox1, ex.Message)
                Exit Do
            End Try
        Loop
        Dim oldlog2 As String
        Dim oldlog3 As String
        Dim newlog2 As String
        Dim newlog3 As String
        oldlog2 = ""
        If IO.File.Exists("Data\metroimgup_mass.log") = True Then
            oldlog2 = IO.File.ReadAllText("Data\metroimgup_mass.log")
        Else

        End If
        newlog2 = oldlog2 & TextBox9.Text
        My.Computer.FileSystem.WriteAllText("Data\metroimgup_mass.log", newlog2, False)
        Button11.Enabled = True
        oldlog3 = ""
        If IO.File.Exists("Data\metroimgup_mass_dl.log") = True Then
            oldlog3 = IO.File.ReadAllText("Data\metroimgup_mass_dl.log")
        Else

        End If
        newlog3 = oldlog3 & TextBox10.Text
        My.Computer.FileSystem.WriteAllText("Data\metroimgup_mass_dl.log", newlog3, False)
        ButtonItem3.Enabled = True
        'End If

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text = "" Then
            ButtonX13.Enabled = False
            ButtonItem4.Enabled = False
        Else
            ButtonX13.Enabled = True
            ButtonItem4.Enabled = True
        End If
    End Sub

    Private Sub ButtonX13_Click(sender As Object, e As EventArgs) Handles ButtonX13.Click
        Clipboard.SetText(TextBox9.Text)
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Clipboard.SetText(TextBox10.Text)
    End Sub

    Private Sub ButtonX11_Click(sender As Object, e As EventArgs) Handles ButtonX11.Click
        If IO.File.Exists("Data\metroimgup_mass.log") = True Then
            Process.Start("Data\metroimgup_mass.log")
        Else
            MessageBox.Show("Error, the MassUpload log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        If IO.File.Exists("Data\metroimgup_mass_dl.log") = True Then
            Process.Start("Data\metroimgup_mass_dl.log")
        Else
            MessageBox.Show("Error, the MassUpload DL log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ListBox1.SelectedItem = "" Then
            ButtonX10.Enabled = False
        Else
            ButtonX10.Enabled = True
            If ListBox1.SelectedIndex > 0 Then
                ButtonX16.Enabled = True
            Else
                ButtonX16.Enabled = False
            End If
            If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
                ButtonX17.Enabled = True
            Else
                ButtonX17.Enabled = False
            End If
        End If
    End Sub

    Private Sub ButtonX16_Click(sender As Object, e As EventArgs) Handles ButtonX16.Click
        If ListBox1.SelectedIndex > 0 Then
            Dim I = ListBox1.SelectedIndex - 1
            ListBox1.Items.Insert(I, ListBox1.SelectedItem)
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            ListBox1.SelectedIndex = I
        End If
    End Sub

    Private Sub ButtonX17_Click(sender As Object, e As EventArgs) Handles ButtonX17.Click
        'Make sure our item is not the last one on the list.
        If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
            'Insert places items above the index you supply, since we want
            'to move it down the list we have to do + 2
            Dim I = ListBox1.SelectedIndex + 2
            ListBox1.Items.Insert(I, ListBox1.SelectedItem)
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            ListBox1.SelectedIndex = I - 1
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If ListBox1.Items.Count = 0 Then
            ButtonX15.Enabled = False
        Else
            ButtonX15.Enabled = True
        End If
    End Sub
End Class