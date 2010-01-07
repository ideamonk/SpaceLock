VERSION 5.00
Object = "{BD6BB71B-5C9A-4FB3-877E-8B513D28B951}#1.0#0"; "hwinterface.ocx"
Begin VB.Form frmMain 
   BorderStyle     =   0  'None
   Caption         =   "SpaceLock Motor Controller"
   ClientHeight    =   1995
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2160
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1995
   ScaleWidth      =   2160
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin HWINTERFACELib.Hwinterface HwInf 
      Left            =   480
      Top             =   600
      _Version        =   65536
      _ExtentX        =   1720
      _ExtentY        =   1296
      _StockProps     =   0
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

Dim t As Variant

Private Const delay = 300
Private Const address = &H378

Private Const UP = 251
Private Const DOWN = 247
Private Const LFT = 254
Private Const RIGHT = 253

Private Sub Form_Load()
On Error Resume Next

If (App.PrevInstance) Then
    End
End If

Load Me
Me.Hide

If (Command$ = "SpaceLock left") Then
    HwInf.OutPort address, LFT
End If

If (Command$ = "SpaceLock right") Then
    HwInf.OutPort address, RIGHT
End If

If (Command$ = "SpaceLock up") Then
    HwInf.OutPort address, UP
End If

If (Command$ = "SpaceLock down") Then
    HwInf.OutPort address, DOWN
End If

Sleep delay
HwInf.OutPort address, 0

End

End Sub
