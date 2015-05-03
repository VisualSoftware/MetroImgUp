'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: Form1.vb
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

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO
Imports System.Collections.Specialized
Imports System.Globalization

Public Class Form1

    Dim updater As New WebClient()
    Dim updadd As String
    Dim updfile As String
    Dim newftpfile As String
    Dim newftpfilename As String
    Dim filextension123 As String
    Dim newextension As String
    Dim delnewurl As String
    Dim chkerr As String
    Dim errprc As String
    Dim errprc2 As String
    Dim errprc3 As String
    Dim erradd1 As String
    Dim dirname As String
    Dim newtxt As String
    Dim erradd2 As String
    Dim erradd3 As String
    Dim erradd4 As String
    Dim erradd5 As String
    Public imgupacc As String
    Public imguppwd As String
    Public adminacc As String
    Public fwacc As String
    Public fwpwd As String
    Dim ddf As String
    Dim ccleaner As String
    Dim officepath As String
    Dim officeselected As String
    Dim offslcfake As String
    Public NTVer As String
    Public takenpic As String
    Public GetWindowSize As String
    Dim erracc1 As String
    Dim schupd As String
    Public GlobalFTPServer As String
    Public GlobalHTTPServer As String
    Public GlobalHTTPServer2 As String
    Public GlobalServerIP As String
    Dim updatefilesize As String
    Public proxy1 As String
    Public proxy2 As String
    Public proxied As String
    Dim metroenabled As String
    Dim VSTools As VSSharedSource = New VSSharedSource


    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    ' specify the path to a file and this routine will calculate your hash
    Public Function MD5CalcFile(ByVal filepath As String) As String

        ' open file (as read-only)
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider

                ' hash contents of this stream
                Dim hash() As Byte = md5.ComputeHash(reader)

                ' return formatted hash
                Return ByteArrayToString(hash)

            End Using
        End Using

    End Function

    ' utility function to convert a byte array into a hex string
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)

        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next

        Return sb.ToString().ToLower

    End Function


    Private Sub Button5_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'moved to button6_click_1
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            Button6.Enabled = False
        Else
            Button6.Enabled = True
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Clipboard.SetText(TextBox4.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If IO.Directory.Exists("Data") Then

            Else
                IO.Directory.CreateDirectory("Data")
            End If
            SuperTabControl1.Visible = True
            If IO.File.Exists("Data\FTP.dat") = True Then
                GlobalFTPServer = IO.File.ReadAllText("Data\FTP.dat")
            Else
                GlobalFTPServer = "localhost:21"
            End If
            If IO.File.Exists("Data\HTTP.dat") = True Then
                GlobalHTTPServer = IO.File.ReadAllText("Data\HTTP.dat")
                If GlobalHTTPServer.Contains("www.") = True Then
                    GlobalHTTPServer2 = GlobalHTTPServer.Replace("www.", "")
                Else
                    GlobalHTTPServer2 = GlobalHTTPServer
                End If
            Else
                GlobalHTTPServer = "localhost"
                GlobalHTTPServer2 = "localhost"
            End If
            If IO.File.Exists("Data\IP.dat") = True Then
                GlobalServerIP = IO.File.ReadAllText("Data\IP.dat")
            Else
                GlobalServerIP = "127.0.0.1:21"
            End If

            If My.Application.Info.CompanyName = "Visual Software" Then
                If Now.Year > 2012 Then
                    LinkLabel1.Text = My.Application.Info.AssemblyName & " © 2012-" & Now.Year & " " & My.Application.Info.CompanyName
                Else
                    LinkLabel1.Text = My.Application.Info.AssemblyName & " © 2012-2013" & " " & My.Application.Info.CompanyName
                End If
            Else
                MessageBox.Show("Error, This application has been modified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            Dim uextheme As String
            If IO.File.Exists("Data\UIColor.dat") = True Then
                uextheme = IO.File.ReadAllText("Data\UIColor.dat")
                My.Forms.PasswordManager.ComboBoxEx2.SelectedIndex = uextheme
            Else
                My.Forms.PasswordManager.ComboBoxEx2.SelectedIndex = "3"
            End If
            If IO.File.Exists("Data\metroimgup.log") = True Then
                Dim newentryline As String
                Dim logread As String
                newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
                logread = IO.File.ReadAllText("Data\metroimgup.log")
                If logread.Contains(newentryline) Then

                Else
                    My.Computer.FileSystem.WriteAllText("Data\metroimgup.log", newentryline, True)
                End If
            Else
                Button8.Enabled = False
            End If
            If IO.File.Exists("Data\metroimgup_dl.log") = True Then
                Dim newentryline As String
                Dim logread As String
                newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
                logread = IO.File.ReadAllText("Data\metroimgup_dl.log")
                If logread.Contains(newentryline) Then

                Else
                    My.Computer.FileSystem.WriteAllText("Data\metroimgup_dl.log", newentryline, True)
                End If
            Else
                ButtonItem1.Enabled = False
            End If
            If IO.File.Exists("Data\metroimgup_fwlink.log") = True Then
                Dim newentryline As String
                Dim logread As String
                newentryline = "################################ -= " & Now.Day & "/" & Now.Month & "/" & Now.Year & " =- ################################" & vbCrLf
                logread = IO.File.ReadAllText("Data\metroimgup_fwlink.log")
                If logread.Contains(newentryline) Then

                Else
                    My.Computer.FileSystem.WriteAllText("Data\metroimgup_fwlink.log", newentryline, True)
                End If
            Else
                ButtonX14.Enabled = False
            End If
            Me.Text = Me.Text & " - v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor
            Label8.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                Me.Text = "Administrator: " & Me.Text
            End If
            If IO.File.Exists("Data\FirstStart.dat") = True Then

            Else
                PasswordManager.ShowDialog()
            End If
            Label20.Text = "Registered to: " & Environment.UserName
            Try
                Dim myFile As String
                Dim mydir As String = My.Application.Info.DirectoryPath & "\Data\"
                For Each myFile In Directory.GetFiles(mydir, "*.png")
                    File.Delete(myFile)
                Next
            Catch ex As Exception
            End Try
            proxied = "0"
            ButtonX1_Click(sender, e)
            'LOADING IMGUP ACCOUNT
            If IO.File.Exists("Data\imgup_acc.txt") = True Then
                imgupacc = IO.File.ReadAllText("Data\imgup_acc.txt")
                imguppwd = IO.File.ReadAllText("Data\imgup_pwd.txt")
            End If
            CheckBox2.Visible = False
            CheckBox5.Visible = False
            CheckBox2.Checked = False
            CheckBox5.Checked = False
            'LOADING FWLINK ACCOUNT
            If IO.File.Exists("Data\fwlink_acc.txt") = True Then
                fwacc = IO.File.ReadAllText("Data\fwlink_acc.txt")
                fwpwd = IO.File.ReadAllText("Data\fwlink_pwd.txt")
            Else
                SuperTabItem6.Visible = False
            End If
            Try
                If IO.File.Exists(My.Application.Info.DirectoryPath & "\Setup.upd") = True Then
                    If IO.File.Exists(My.Application.Info.DirectoryPath & "\Setup.exe") = True Then
                        IO.File.Delete(My.Application.Info.DirectoryPath & "\Setup.exe")
                    Else

                    End If
                    My.Computer.FileSystem.RenameFile(My.Application.Info.DirectoryPath & "\Setup.upd", "Setup.exe")
                End If
            Catch ex As Exception

            End Try
        Catch ex2 As Exception
            MessageBox.Show("Critical Error: " & ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.Enabled = False
        About.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If TextBox9.Text = "" Then
            Button15.Enabled = False
        Else
            If CheckBox4.Checked = True Then
                Button15.Enabled = True
            Else
                Button15.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox3.Text = "" Then
            MessageBox.Show("Error: No file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Button6.Visible = False
            Button10.Visible = False
            CircularProgress1.Visible = True
            Timer1.Enabled = True
            CheckBox2.Enabled = False
            CheckBox6.Enabled = False
            Button9.Enabled = False
            TextBox3.ReadOnly = True
            TextBox3.AllowDrop = False
            ButtonX27.Enabled = False
            errprc = ""
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        End
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then

        Else
            TextBox3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Clipboard.SetText(TextBox4.Text)
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        Clipboard.SetText(TextBox6.Text)
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        If IO.File.Exists("Data\metroimgup.log") = True Then
            Process.Start("Data\metroimgup.log")
        Else
            MessageBox.Show("Error, the log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        Button1_Click(sender, e)
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        WarningBox3.Visible = False
        If TextBox9.Text = "" Then
            MessageBox.Show("Error: No file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If CheckBox5.Checked = True Then
                delnewurl = TextBox9.Text
                delnewurl = delnewurl.Replace("http://" & GlobalHTTPServer & "/wuimguploader/", "vip/")
            Else
                delnewurl = TextBox9.Text
                delnewurl = delnewurl.Replace("http://" & GlobalHTTPServer & "/publicimgup/", "public/")
            End If
            Button15.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            Button16.Enabled = False
            TextBox9.ReadOnly = True
            Button17.Enabled = False
            Button15.Text = "Deleting..."
            errprc2 = ""
            filedel.RunWorkerAsync()
        End If

    End Sub

    Private Sub Button17_Click_1(sender As Object, e As EventArgs) Handles Button17.Click
        End
    End Sub

    Private Sub Button16_Click_1(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox9.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            'dragdrop mode
            Dim FileSZ As FileInfo = New FileInfo(TextBox3.Text)
            filextension123 = FileSZ.Extension
            newftpfilename = MD5CalcFile(TextBox3.Text) & filextension123
            'normal mode
            If proxied = "1" Then
                If CheckBox2.Checked = True Then
                    newftpfile = "ftp://" & proxy1 & ":" & proxy2 & "/vip/autoup/" & newftpfilename
                Else
                    newftpfile = "ftp://" & proxy1 & ":" & proxy2 & "/public/" & newftpfilename
                End If
            Else
                If CheckBox2.Checked = True Then
                    newftpfile = "ftp://" & GlobalFTPServer & "/vip/autoup/" & newftpfilename
                Else
                    newftpfile = "ftp://" & GlobalFTPServer & "/public/" & newftpfilename
                End If
            End If
            If CheckBox6.Checked = True Then
                My.Computer.Network.UploadFile(TextBox3.Text, newftpfile, imgupacc, imguppwd, True, 1000000000, FileIO.UICancelOption.ThrowException)
            Else
                ' set up request...

                If proxied = "1" Then
                    MessageBox.Show("Proxy feature is not supported at the moment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim clsRequest As System.Net.FtpWebRequest =
                    DirectCast(System.Net.WebRequest.Create(newftpfile), System.Net.FtpWebRequest)
                    clsRequest.Credentials = New System.Net.NetworkCredential(imgupacc, imguppwd)
                    clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                    clsRequest.Timeout = 1000000000
                    clsRequest.ReadWriteTimeout = 1000000000
                    clsRequest.KeepAlive = False
                    Dim bFile() As Byte = System.IO.File.ReadAllBytes(TextBox3.Text)
                    ' upload file...
                    Dim clsStream As System.IO.Stream =
                    clsRequest.GetRequestStream()
                    clsStream.Write(bFile, 0, bFile.Length)
                    clsStream.Close()
                    clsStream.Dispose()
                End If
            End If
        Catch ex As Exception
            errprc = "1"
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button8.Enabled = True
        ButtonItem1.Enabled = True
        Button6.Visible = True
        Button10.Visible = True
        ButtonX27.Enabled = True
        Timer1.Enabled = False
        CircularProgress1.Visible = False
        CheckBox2.Enabled = True
        CheckBox6.Enabled = True
        Button9.Enabled = True
        TextBox3.ReadOnly = False
        TextBox3.AllowDrop = True
        If errprc = "1" Then
            TextBox3.ReadOnly = False
            Button6.Visible = True
            Button6.Enabled = True
            Button10.Visible = True
            CircularProgress1.Visible = False
            Timer1.Enabled = False
            CheckBox2.Enabled = True
            CheckBox6.Enabled = True
            Button9.Enabled = True
            TextBox6.Text = ""
            TextBox4.Text = ""
        Else
            If CheckBox2.Checked = True Then
                TextBox6.Text = "[IMG]http://" & GlobalHTTPServer & "/wuimguploader/autoup/" & newftpfilename & "[/IMG]"
            Else
                TextBox6.Text = "[IMG]http://" & GlobalHTTPServer & "/publicimgup/" & newftpfilename & "[/IMG]"
            End If
            If CheckBox2.Checked = True Then
                TextBox4.Text = "http://" & GlobalHTTPServer & "/wuimguploader/autoup/" & newftpfilename
            Else
                TextBox4.Text = "http://" & GlobalHTTPServer & "/publicimgup/" & newftpfilename
            End If
            TextBox3.Text = ""
            TextBox5.Text = TextBox6.Text & vbCrLf
            My.Computer.FileSystem.WriteAllText("Data\metroimgup.log", TextBox5.Text, True)
            TextBox8.Text = TextBox4.Text & vbCrLf
            My.Computer.FileSystem.WriteAllText("Data\metroimgup_dl.log", TextBox8.Text, True)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CircularProgress1.Value = CircularProgress1.Value + 1
    End Sub

    Private Sub CircularProgress1_ValueChanged(sender As Object, e As EventArgs) Handles CircularProgress1.ValueChanged
        If CircularProgress1.Value = CircularProgress1.Maximum Then
            CircularProgress1.Value = "0"
        End If
    End Sub

    Private Sub checkupd_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles checkupd.DoWork
        Try
            updater.DownloadFile(updadd, updfile)
        Catch ex As Exception
            chkerr = "1"
        Finally
        End Try
    End Sub

    Private Sub checkupd_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles checkupd.RunWorkerCompleted

    End Sub

    Private Sub delfile_Tick(sender As Object, e As EventArgs) Handles delfile.Tick
        WarningBox3.Visible = False
        delfile.Enabled = False
    End Sub

    Private Sub dlupd_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles dlupd.DoWork
        Try
            updater.DownloadFile(updadd, updfile)
        Catch ex As Exception
            errprc3 = "1"
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

    Private Sub dlupd_ProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs) Handles dlupd.ProgressChanged

    End Sub

    Private Sub dlupd_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles dlupd.RunWorkerCompleted

    End Sub

    Private Sub updtimer_Tick(sender As Object, e As EventArgs) Handles updtimer.Tick

    End Sub

    Private Sub filedel_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles filedel.DoWork
        Try
            Dim ftp As FtpWebRequest = DirectCast(WebRequest.Create("ftp://" & GlobalFTPServer & "/" & delnewurl), FtpWebRequest)
            ftp.Credentials = New System.Net.NetworkCredential(imgupacc, imguppwd)
            ftp.Method = WebRequestMethods.Ftp.DeleteFile
            Dim ftpResponse As FtpWebResponse = CType(ftp.GetResponse(), FtpWebResponse)
            ftpResponse = ftp.GetResponse()
            ftpResponse.Close()
        Catch ex As Exception
            errprc2 = "1"
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub

    Private Sub filedel_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles filedel.RunWorkerCompleted
        TextBox9.Text = ""
        delfile.Enabled = True
        CheckBox4.Checked = False
        CheckBox4.Enabled = True
        CheckBox5.Enabled = True
        Button16.Enabled = True
        TextBox9.ReadOnly = False
        Button17.Enabled = True
        Button15.Text = "Delete"
        If errprc2 = "1" Then
            Button17.Enabled = True
            Button15.Text = "Delete"
            CheckBox4.Enabled = True
            CheckBox5.Enabled = True
            Button16.Enabled = True
            TextBox9.ReadOnly = False
        Else
            WarningBox3.Visible = True
        End If
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        ButtonX6.Enabled = False
        Form2.Show()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "" Then
            Button7.Enabled = False
        Else
            Button7.Enabled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            Button11.Enabled = False
        Else
            Button11.Enabled = True
        End If
    End Sub

    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        If IO.File.Exists("Data\metroimgup_dl.log") = True Then
            Process.Start("Data\metroimgup_dl.log")
        Else
            MessageBox.Show("Error, the DL log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UpdatesAdministratorToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX19_Click(sender As Object, e As EventArgs) Handles ButtonX19.Click
        If TextBox17.Text = "" Then
            MessageBox.Show("Error, link string is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TextBox17.ReadOnly = True
            ButtonX17.Enabled = False
            ButtonX19.Enabled = False
            ButtonX18.Enabled = False
            addlinkworker.RunWorkerAsync()
        End If
    End Sub

    Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs) Handles TextBox17.TextChanged
        If TextBox17.Text = "" Then
            ButtonX19.Enabled = False
        Else
            ButtonX19.Enabled = True
        End If
    End Sub

    Private Sub ButtonX18_Click(sender As Object, e As EventArgs) Handles ButtonX18.Click
        End
    End Sub

    Private Sub ButtonX17_Click(sender As Object, e As EventArgs) Handles ButtonX17.Click
        TextBox17.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX16_Click(sender As Object, e As EventArgs) Handles ButtonX16.Click
        Clipboard.SetText(TextBox20.Text)
    End Sub

    Private Sub addlinkworker_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles addlinkworker.DoWork
        Try
            Dim htmlfile As String
            htmlfile = html1.Text & TextBox17.Text & html2.Text
            If IO.File.Exists("Data\temp.html") = True Then
                IO.File.Delete("Data\temp.html")
            Else

            End If
            IO.File.WriteAllText("Data\temp.html", htmlfile)
            FTPSettings.IP = GlobalFTPServer
            FTPSettings.UserID = fwacc
            FTPSettings.Password = fwpwd
            Dim reqFTP As FtpWebRequest = Nothing
            Dim ftpStream As Stream = Nothing
            Randomize()
            dirname = "LinkID=" & CInt(Int((1000000000 * Rnd()) + 10))
            reqFTP = DirectCast(FtpWebRequest.Create(New Uri("ftp://" + FTPSettings.IP + "/" + dirname)), FtpWebRequest)
            reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(FTPSettings.UserID, FTPSettings.Password)
            Dim response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
            ftpStream = response.GetResponseStream()
            ftpStream.Close()
            response.Close()
            My.Computer.Network.UploadFile("Data\temp.html", "ftp://" + FTPSettings.IP + "/" + dirname + "/index.html", fwacc, fwpwd, False, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            erradd1 = "1"
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub addlinkworker_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles addlinkworker.RunWorkerCompleted
        TextBox17.ReadOnly = False
        ButtonX17.Enabled = True
        ButtonX19.Enabled = True
        ButtonX18.Enabled = True
        If erradd1 = "1" Then
            erradd1 = "0"
            TextBox20.Text = ""
        Else
            TextBox20.Text = "http://" & GlobalHTTPServer2 & "/fwlink/" & dirname
            TextBox17.Text = ""
            TextBox19.Text = TextBox20.Text & vbCrLf
            My.Computer.FileSystem.WriteAllText("Data\metroimgup_fwlink.log", TextBox19.Text, True)
            ButtonX14.Enabled = True
        End If
    End Sub

    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        If TextBox20.Text = "" Then
            ButtonX16.Enabled = False
        Else
            ButtonX16.Enabled = True
        End If
    End Sub

    Private Sub ButtonX14_Click(sender As Object, e As EventArgs) Handles ButtonX14.Click
        If IO.File.Exists("Data\metroimgup_fwlink.log") = True Then
            Process.Start("Data\metroimgup_fwlink.log")
        Else
            MessageBox.Show("Error, the log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub checkfw_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles checkfw.DoWork
        If IO.File.Exists("Data\editfile.html") = True Then
            IO.File.Delete("Data\editfile.html")
        Else

        End If

        My.Computer.Network.DownloadFile(TextBox14.Text & "/index.html", "Data\editfile.html")
    End Sub

    Private Sub checkfw_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles checkfw.RunWorkerCompleted
        ButtonX12.Enabled = True
        ButtonX8.Enabled = True
        TextBox14.ReadOnly = False
        ButtonX10.Enabled = True
        Dim temptxt As String
        Dim temptxt1 As String
        temptxt = IO.File.ReadAllText("Data\editfile.html")
        temptxt1 = temptxt.Replace(html1.Text, "")
        TextBox15.Text = temptxt1.Replace(html2.Text, "")
        ButtonX7.Enabled = True
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If TextBox15.Text = "" Then
            ButtonX9.Enabled = False
        Else
            ButtonX9.Enabled = True
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        TextBox14.Text = Clipboard.GetText()
    End Sub

    Private Sub ButtonX9_Click(sender As Object, e As EventArgs) Handles ButtonX9.Click
        Clipboard.SetText(TextBox15.Text)
    End Sub

    Private Sub ButtonX11_Click(sender As Object, e As EventArgs) Handles ButtonX11.Click
        TextBox13.Text = Clipboard.GetText()
    End Sub

    Private Sub editfw_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles editfw.DoWork
        Try
            My.Computer.Network.UploadFile("Data\temp.html", "ftp://" & GlobalFTPServer & "/" & newtxt & "/index.html", fwacc, fwpwd, False, 1000000000, FileIO.UICancelOption.ThrowException)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            erradd2 = "1"
        End Try
    End Sub

    Private Sub ButtonX12_Click(sender As Object, e As EventArgs) Handles ButtonX12.Click
        If TextBox13.Text = "" Then
            MessageBox.Show("Error, no new link found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If TextBox14.Text.Contains("www") = True Then
                newtxt = TextBox14.Text.Replace("http://" & GlobalHTTPServer & "/fwlink/", "")
            Else
                newtxt = TextBox14.Text.Replace("http://" & GlobalHTTPServer2 & "/fwlink/", "")
            End If
            Dim htmlfile2 As String
            htmlfile2 = html1.Text & TextBox13.Text & html2.Text
            If IO.File.Exists("Data\temp.html") = True Then
                IO.File.Delete("Data\temp.html")
            Else

            End If
            IO.File.WriteAllText("Data\temp.html", htmlfile2)
            ButtonX10.Enabled = False
            ButtonX12.Enabled = False
            ButtonX7.Enabled = False
            ButtonX8.Enabled = False
            TextBox14.ReadOnly = True
            editfw.RunWorkerAsync()
        End If
    End Sub

    Private Sub editfw_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles editfw.RunWorkerCompleted
        If erradd2 = "1" Then
            erradd2 = "0"
        Else
            WarningBox5.Visible = True
            TextBox15.Text = ""
            TextBox13.Text = ""
            editlink.Enabled = True
        End If
        ButtonX8.Enabled = True
        ButtonX10.Enabled = True
        ButtonX12.Enabled = True
        TextBox14.ReadOnly = False
        ButtonX7.Enabled = True
    End Sub

    Private Sub editlink_Tick(sender As Object, e As EventArgs) Handles editlink.Tick
        WarningBox5.Visible = False
        editlink.Enabled = False
    End Sub

    Private Sub ButtonX10_Click(sender As Object, e As EventArgs) Handles ButtonX10.Click
        End
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        ButtonX8.Enabled = False
        TextBox14.ReadOnly = True
        ButtonX10.Enabled = False
        ButtonX7.Enabled = False
        checkfw.RunWorkerAsync()
    End Sub

    Private Sub ButtonX21_Click(sender As Object, e As EventArgs) Handles ButtonX21.Click
        TextBox21.Text = Clipboard.GetText()
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged
        If TextBox21.Text = "" Then
            ButtonX22.Enabled = False
        Else
            If CheckBox12.Checked = True Then
                ButtonX22.Enabled = True
            Else
                ButtonX22.Enabled = False
            End If
        End If
    End Sub

    Private Sub ButtonX20_Click(sender As Object, e As EventArgs) Handles ButtonX20.Click
        End
    End Sub

    Private Sub delfw_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles delfw.DoWork
        Try
            FTPSettings.IP = GlobalFTPServer & "/"
            FTPSettings.UserID = fwacc
            FTPSettings.Password = fwpwd
            Dim reqFTP As FtpWebRequest = Nothing
            Dim ftpStream As Stream = Nothing
            Randomize()
            If dirname.Contains("www") = True Then
                dirname = TextBox21.Text.Replace("http://" & GlobalHTTPServer & "/fwlink/", "")
            Else
                dirname = TextBox21.Text.Replace("http://" & GlobalHTTPServer2 & "/fwlink/", "")
            End If

            reqFTP = DirectCast(FtpWebRequest.Create(New Uri("ftp://" + FTPSettings.IP + "/" + dirname + "/index.html")), FtpWebRequest)
            reqFTP.Method = WebRequestMethods.Ftp.DeleteFile
            reqFTP.UseBinary = True
            reqFTP.Credentials = New NetworkCredential(FTPSettings.UserID, FTPSettings.Password)
            Dim response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
            ftpStream = response.GetResponseStream()
            ftpStream.Close()
            response.Close()
        Catch ex As Exception
            erradd3 = "1"
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonX22_Click(sender As Object, e As EventArgs) Handles ButtonX22.Click
        If TextBox21.Text = "" Then
            MessageBox.Show("Error: no link to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TextBox21.ReadOnly = True
            ButtonX21.Enabled = False
            CheckBox12.Enabled = False
            ButtonX20.Enabled = False
            ButtonX22.Enabled = False
            delfw.RunWorkerAsync()
        End If
    End Sub

    Private Sub delfw_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles delfw.RunWorkerCompleted
        TextBox21.ReadOnly = False
        ButtonX21.Enabled = True
        CheckBox12.Enabled = True
        If erradd3 = "1" Then
            erradd3 = "0"
            ButtonX22.Enabled = True
        Else
            WarningBox6.Visible = True
            delfwtimer.Enabled = True
            TextBox21.Text = ""
            CheckBox12.Checked = False
        End If
        ButtonX20.Enabled = True
    End Sub

    Private Sub delfwtimer_Tick(sender As Object, e As EventArgs) Handles delfwtimer.Tick
        WarningBox6.Visible = False
        delfwtimer.Enabled = False
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text = "" Then
            ButtonX7.Enabled = False
        Else
            ButtonX7.Enabled = True
        End If
    End Sub

    Private Sub ButtonX23_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub WarningBox7_OptionsClick(sender As Object, e As EventArgs)
        MessageBox.Show("Feature not implemented.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        ButtonItem2.Enabled = False
        PasswordManager.Show()
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

    Private Sub TextBox3_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If TextBox9.Text = "" Then
            Button15.Enabled = False
        Else
            If CheckBox4.Checked = True Then
                Button15.Enabled = True
            Else
                Button15.Enabled = False
            End If
        End If
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged
        If TextBox21.Text = "" Then
            ButtonX22.Enabled = False
        Else
            If CheckBox12.Checked = True Then
                ButtonX22.Enabled = True
            Else
                ButtonX22.Enabled = False
            End If
        End If
    End Sub
    Private Sub ButtonX27_Click(sender As Object, e As EventArgs) Handles ButtonX27.Click
        If System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            MessageBox.Show("Error: Your operating system does not support this feature, Please upgrade your version of Windows now!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ButtonX27.Enabled = False
            ImageClipboard.Show()
        End If
    End Sub

    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        ImageClipboard.Button1_Click(sender, e)
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        If System.Environment.OSVersion.Platform = PlatformID.Win32Windows Then
            MessageBox.Show("Error: Your operating system does not support this feature, Please upgrade your version of Windows now!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ImageClipboard.Button2_Click(sender, e)
        End If
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        ImageClipboard.Button4_Click(sender, e)
    End Sub

    Private Sub ButtonX28_Click(sender As Object, e As EventArgs) Handles ButtonX28.Click
        VSTools.OpenDonationPage()
    End Sub

    ' The structure we use for the information
    ' to be interpreted correctly by API.
    Public Structure Struct_INTERNET_PROXY_INFO
        Public dwAccessType As Integer
        Public proxy As IntPtr
        Public proxyBypass As IntPtr
    End Structure

    ' The Windows API function that allows us to manipulate
    ' IE settings programmatically.
    Private Declare Auto Function InternetSetOption Lib "wininet.dll" _
    (ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr,
     ByVal lpdwBufferLength As Integer) As Boolean

    ' The function we will be using to set the proxy settings.
    Public Sub RefreshIESettings(ByVal strProxy As String)
        Const INTERNET_OPTION_PROXY As Integer = 38
        Const INTERNET_OPEN_TYPE_PROXY As Integer = 3
        Dim struct_IPI As Struct_INTERNET_PROXY_INFO

        ' Filling in structure
        struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY
        struct_IPI.proxy = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(strProxy)
        struct_IPI.proxyBypass = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi("local")

        ' Allocating memory
        Dim intptrStruct As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI))

        ' Converting structure to IntPtr
        System.Runtime.InteropServices.Marshal.StructureToPtr(struct_IPI, intptrStruct, True)
        Dim iReturn As Boolean = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI))
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Process.Start("https://www.twitter.com/VisualSoftCorp")
    End Sub

    Private Sub TakeAFullScreenshotOfAllScreensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TakeAFullScreenshotOfAllScreensToolStripMenuItem.Click
        VSTools.TakeFullScreenshotOfAllScreens()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        ImageEd.ShowDialog()
    End Sub

    Private Sub ButtonX30_Click(sender As Object, e As EventArgs) Handles ButtonX30.Click

    End Sub
End Class

Public NotInheritable Class FTPSettings
    Private Sub New()
    End Sub
    Public Shared Property IP() As String
        Get
            Return m_IP
        End Get
        Set(ByVal value As String)
            m_IP = Value
        End Set
    End Property
    Private Shared m_IP As String
    Public Shared Property UserID() As String
        Get
            Return m_UserID
        End Get
        Set(ByVal value As String)
            m_UserID = Value
        End Set
    End Property
    Private Shared m_UserID As String
    Public Shared Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            m_Password = Value
        End Set
    End Property
    Private Shared m_Password As String
End Class

Namespace APing
    Structure AGL_PING
#Region "VARIABLES"
        Dim Data() As Byte
        Dim Type_Message As Byte
        Dim SubCode_type As Byte
        Dim Complement_CheckSum As UInt16
        Dim Identifier As UInt16
        Dim SequenceNumber As UInt16
#End Region
#Region "Metodos"
        Public Sub Initialize(ByVal type As Byte, ByVal subCode As Byte, ByVal payload() As Byte)
            Dim Buffer_IcmpPacket() As Byte
            Dim CksumBuffer() As UInt16
            Dim IcmpHeaderBufferIndex As Int32 = 0
            Dim Index As Integer
            Me.Type_Message = type
            Me.SubCode_type = subCode
            Complement_CheckSum = UInt16.Parse("0")
            Identifier = UInt16.Parse("45")
            SequenceNumber = UInt16.Parse("0")
            Data = payload
            Buffer_IcmpPacket = Serialize()
            ReDim CksumBuffer((Buffer_IcmpPacket.Length() \ 2) - 1)
            For Index = 0 To (CksumBuffer.Length() - 1)
                CksumBuffer(Index) = BitConverter.ToUInt16(Buffer_IcmpPacket, IcmpHeaderBufferIndex)
                IcmpHeaderBufferIndex += 2
            Next Index
            Complement_CheckSum = MCheckSum.Calculate(CksumBuffer, CksumBuffer.Length())
        End Sub
        Public Function Size() As Integer
            Return (8 + Data.Length())
        End Function
        Public Function Serialize() As Byte()
            Dim Buffer() As Byte
            Dim B_Seq() As Byte = BitConverter.GetBytes(SequenceNumber)
            Dim B_Cksum() As Byte = BitConverter.GetBytes(Complement_CheckSum)
            Dim B_Id() As Byte = BitConverter.GetBytes(Identifier)
            Dim Index As Int32 = 0
            ReDim Buffer(Size() - 1)
            Buffer(0) = Type_Message
            Buffer(1) = SubCode_type
            Index += 2
            Array.Copy(B_Cksum, 0, Buffer, Index, 2) : Index += 2
            Array.Copy(B_Id, 0, Buffer, Index, 2) : Index += 2
            Array.Copy(B_Seq, 0, Buffer, Index, 2) : Index += 2
            If (Data.Length() > 0) Then Array.Copy(Data, 0, Buffer, Index, Data.Length())
            Return Buffer
        End Function
#End Region
    End Structure
    Public Class CPing
#Region "Contactos"
        Private Const DATA_SIZE As Integer = 32
        Private Const DEFAULT_TIMEOUT As Integer = 1000
        Private Const ICMP_ECHO As Integer = 8
        Private Const SOCKET_ERROR As Integer = -1
        Private Const PING_ERROR As Integer = -1
        Private Const RECV_SIZE As Integer = 128
#End Region
#Region "VARIABLES"
        Private _Open As Boolean = False
        Private _Initialized As Boolean
        Private _RecvBuffer() As Byte
        Private _Packet As AGL_PING
        Private _HostName As String
        Private _Server As EndPoint
        Private _Local As EndPoint
        Private _Socket As Socket
#End Region
#Region "CONSTRUCTORS & FINALIZER"
        Public Sub New(ByVal hostName As String)
            Me.HostName() = hostName
            ReDim _recvBuffer(RECV_SIZE - 1)
        End Sub
        Public Sub New()
            Me.HostName() = Dns.GetHostName()
            ReDim _recvBuffer(RECV_SIZE - 1)
        End Sub
        Private Overloads Sub finalize()
            Me.Close()
            Erase _recvBuffer
        End Sub
#End Region
#Region "Metodos"
        Public Property HostName() As String
            Get
                Return _hostName
            End Get
            Set(ByVal Value As String)
                _hostName = Value
                If (_open) Then
                    Me.Close()
                    Me.Open()
                End If
            End Set
        End Property
        Public ReadOnly Property IsOpen() As Boolean
            Get
                Return _open
            End Get
        End Property
        Public Function Open() As Boolean
            Dim Payload() As Byte
            If (Not _open) Then
                Try
                    ReDim payload(DATA_SIZE)
                    _packet.Initialize(ICMP_ECHO, 0, payload)
                    _socket = New Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp)
                    _Server = New IPEndPoint(Dns.GetHostByName(_HostName).AddressList(0), 0)
                    _Local = New IPEndPoint(Dns.GetHostByName(Dns.GetHostName()).AddressList(0), 0)
                    _open = True
                Catch
                    Return False
                End Try
            End If
            Return True
        End Function
        Public Function Close() As Boolean
            If (_open) Then
                _socket.Close()
                _socket = Nothing
                _server = Nothing
                _local = Nothing
                _open = False
            End If
            Return True
        End Function
        Public Overloads Function Ping() As Integer
            Return Ping(DEFAULT_TIMEOUT)
        End Function
        Public Overloads Function Ping(ByVal timeOutMilliSeconds As Integer) As Integer
            Dim TimeOut As Integer = timeOutMilliSeconds + Environment.TickCount()
            Try
                If (SOCKET_ERROR = _socket.SendTo(_packet.Serialize(), _packet.Size(), 0, _server)) Then
                    Return PING_ERROR
                End If
            Catch
            End Try
            Do
                If (_socket.Poll(1000, SelectMode.SelectRead)) Then
                    _socket.ReceiveFrom(_recvBuffer, RECV_SIZE, 0, _local)
                    Return (timeOutMilliSeconds - (timeOut - Environment.TickCount()))
                ElseIf (Environment.TickCount() >= timeOut) Then
                    Return PING_ERROR
                End If
            Loop While (True)
        End Function
#End Region
    End Class
    Module MCheckSum
#Region "Metodos"
        <StructLayout(LayoutKind.Explicit)> Structure UNION_INT16
            <FieldOffset(0)> Dim lsb As Byte
            <FieldOffset(1)> Dim msb As Byte
            <FieldOffset(0)> Dim w16 As Short
        End Structure
        <StructLayout(LayoutKind.Explicit)> Structure UNION_INT32
            <FieldOffset(0)> Dim lsw As UNION_INT16
            <FieldOffset(2)> Dim msw As UNION_INT16     '
            <FieldOffset(0)> Dim w32 As Integer
        End Structure
        Public Function Calculate(ByRef buffer() As UInt16, ByVal size As Int32) As UInt16
            Dim Counter As Int32 = 0
            Dim Cksum32 As UNION_INT32
            Do While (size > 0)
                cksum32.w32 += Convert.ToInt32(buffer(counter))
                counter += 1
                size -= 1
            Loop
            cksum32.w32 = cksum32.msw.w16 + cksum32.lsw.w16 + cksum32.msw.w16
            Return Convert.ToUInt16(cksum32.lsw.w16 Xor &HFFFF)
        End Function
#End Region
    End Module
End Namespace

