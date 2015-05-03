'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: VSSharedSource.vb
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

Public Class VSSharedSource
    Dim donationpage As String = "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=XTCNPRUDFH4UA&lc=ES&item_name=Metro%20Image%20Uploader&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted"
    Dim appname As String = "MetroImgUp"

    Function OpenDonationPage()
        Try
            Process.Start(donationpage)
        Catch ex As Exception
            MessageBox.Show("Error: The Donation page couldn't be opened. Open your favorite browser and go to: " & donationpage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Function

    Function GetCopyrightDate() As String
        Dim cpdate As String
        If Now.Year > 2013 Then
            cpdate = " © 2013-" & Now.Year
        Else
            cpdate = " © 2013"
        End If
        Return cpdate
    End Function

    Function TakeFullScreenshotOfAllScreens()
        Dim picname As String
        picname = "Data\" & Now.Year & "-" & Now.Month & "-" & Now.Day & "-" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".png"
        ImageClipboard.PictureBox1.BackgroundImage = GetScreenCapture(True)
        ImageClipboard.PictureBox1.BackgroundImage.Save(picname, System.Drawing.Imaging.ImageFormat.Png)
        My.Forms.Form1.TextBox3.Text = My.Application.Info.DirectoryPath & "\" & picname
    End Function

    Public Function GetScreenCapture(
   Optional ByVal FullScreen As Boolean = False) As Image
        ' Captures the current screen and returns as an Image
        ' object
        If FullScreen = True Then
            ' Print Screen pressed twice here as some systems
            ' grab active window "accidentally" on first run
            SendKeys.SendWait("{PRTSC 2}")
        Else
            SendKeys.SendWait("%{PRTSC}")
        End If
        Dim objData As IDataObject = Clipboard.GetDataObject()
        Return objData.GetData(DataFormats.Bitmap)
    End Function
End Class
