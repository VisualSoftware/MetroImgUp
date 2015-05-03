'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: Globalization.vb
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

Imports System.Threading
Imports System.Globalization

Public Class Globalization

    Public applang As String
    Private Sub Globalization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists("Data\Language.dat") = True Then
                applang = IO.File.ReadAllText("Data\Language.dat")
                Thread.CurrentThread.CurrentCulture = New CultureInfo(applang)
                Thread.CurrentThread.CurrentUICulture = New CultureInfo(applang)
                If applang = "he-IL" Then
                    'Enable RTL Settings
                    My.Forms.Form1.ButtonItem2.BeginGroup = False
                    My.Forms.Form1.ButtonX27.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.Form1.Button8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.Form2.Button8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.Form2.Button11.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.Form2.ButtonX11.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.Form2.ButtonX13.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    My.Forms.ImageClipboard.ButtonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Near
                End If
            Else
                applang = "en-US"
                Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
            End If
            Form1.ShowDialog()
            End
        Catch ex As Exception
            Label1.Text = Label1.Text & ex.Message
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("mailto:alex.cartagena@hotmail.com")
    End Sub

    Private Sub CopyErrorMessageToTheClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyErrorMessageToTheClipboardToolStripMenuItem.Click
        Clipboard.SetText(Label1.Text)
    End Sub
End Class