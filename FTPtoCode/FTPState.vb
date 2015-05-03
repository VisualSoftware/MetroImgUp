'============================================================================
'
'    MetroImgUp
'    Copyright (C) 2012 - 2015 Visual Software Corporation
'
'    Author: ASV93
'    File: FTPState.vb
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
Imports System.Threading
Imports System.IO

Public Class FtpState
    Private wait As ManualResetEvent
    Private _request As FtpWebRequest
    Private _fileName As String
    Private _operationException As Exception = Nothing
    Private status As String

    Public Sub New()
        wait = New ManualResetEvent(False)
    End Sub

    Public ReadOnly Property OperationComplete() As ManualResetEvent
        Get
            Return wait
        End Get
    End Property

    Public Property Request() As FtpWebRequest
        Get
            Return _request
        End Get
        Set(ByVal value As FtpWebRequest)
            _request = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _fileName
        End Get
        Set(ByVal value As String)
            _fileName = value
        End Set
    End Property
    Public Property OperationException() As Exception
        Get
            Return _operationException
        End Get
        Set(ByVal value As Exception)
            _operationException = value
        End Set
    End Property
    Public Property StatusDescription() As String
        Get
            Return status
        End Get
        Set(ByVal value As String)
            status = value
        End Set
    End Property
End Class

