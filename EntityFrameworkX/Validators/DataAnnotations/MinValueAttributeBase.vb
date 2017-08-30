Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
#End Region

Namespace Validators.DataAnnotations

    '''<summary>Stellt allgemeine generische-Funktionalität für MinValueAttribute bereit.</summary>
    Public Class MinValueAttributeBase(Of T As {Structure})

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private _minValue As T
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        '''<summary>Konstruktor.</summary>
        ''' <param name="minValue">Der für die Eigenschaft festgelegte Minimalwert.</param>
        Public Sub New(ByVal minValue As T)
            _minValue = minValue
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        Public ReadOnly Property MinValue As T
            Get
                Return _minValue
            End Get
        End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
        Public Function IsValid(value As T, validationContext As ValidationContext) As ValidationResult

            If StructuralComparisons.StructuralComparer.Compare(value, _minValue) >= 0 Then
                Return ValidationResult.Success
            Else
                Dim s = "Der Wert für das Feld ""{0}"" muss mindestens ""{1}"" betragen!"
                Return New ValidationResult(String.Format _
                (s, validationContext.MemberName, _minValue) _
                , New String() {validationContext.MemberName})
            End If
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace



