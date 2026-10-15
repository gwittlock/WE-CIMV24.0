Imports System.ComponentModel

Public Class clsMoveableForm
    Inherits Form


    Private Const WM_NCLBUTTONDOWN As Int32 = &HA1
    Private Const WM_SYSCOMMAND As Int32 = &H112

    Private Const HTCAPTION As Int32 = &H2

    Private Const SC_MOVE As Int32 = &HF010

    Private m_Moveable As Boolean

    Public Sub New()
        MyBase.New()
        Me.Moveable = True
    End Sub

    < _
        Category("Behavior"), _
        Description("Allows the form to be moved.") _
    > _
    Public Property Moveable() As Boolean
        Get
            Return m_Moveable
        End Get
        Set(ByVal Value As Boolean)
            m_Moveable = Value
        End Set
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        If Not m_Moveable Then
            If _
                ( _
                    m.Msg = WM_SYSCOMMAND AndAlso _
                    m.WParam.ToInt32() = SC_MOVE _
                ) _
                OrElse _
                ( _
                    m.Msg = WM_NCLBUTTONDOWN AndAlso _
                    m.WParam.ToInt32() = HTCAPTION _
                ) _
            Then
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub

End Class
