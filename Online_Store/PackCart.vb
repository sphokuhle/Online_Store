Option Explicit On
Option Strict On

Public Class PackCart
    Private Pr_Id As Integer
    Private P_Price As Double
    Private P_Quantity As Integer
    Private ProductTotal As Double
    Private P_Name As String

    Public ImgLocation As String

    Public Sub New(ByVal id As Integer)
        Pr_Id = id
    End Sub

    Public Property P_Id() As Integer
        Get
            Return Pr_Id
        End Get

        Set(value As Integer)
            Pr_Id = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return P_Name
        End Get
        Set(value As String)
            P_Name = value
        End Set
    End Property

    Public Property Price() As Double
        Get
            Return P_Price
        End Get
        Set(value As Double)
            P_Price = value
        End Set
    End Property

    Public Function CalculateTotal() As Double
        Return Quantity * P_Price
    End Function

    Public ReadOnly Property Product_Total() As Double
        Get
            ProductTotal = CalculateTotal()
            Return ProductTotal
        End Get
    End Property

    Public Property Quantity() As Integer
        Get
            Return P_Quantity
        End Get
        Set(value As Integer)
            P_Quantity = value
            ProductTotal = CalculateTotal()
        End Set
    End Property
End Class
