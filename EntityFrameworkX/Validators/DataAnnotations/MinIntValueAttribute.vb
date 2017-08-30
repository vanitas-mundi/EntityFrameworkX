Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
#End Region

Namespace Validators.DataAnnotations

    '''<summary>Legt für eine Eigenschaft einen Integer-Minimalwert fest.</summary>
    Public Class MinIntValueAttribute

        Inherits ValidationAttribute

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private _base As MinValueAttributeBase(Of Int64)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        '''<summary>Konstruktor.</summary>
        ''' <param name="minValue">Der für die Eigenschaft festgelegte Minimalwert.</param>
        Public Sub New(ByVal minValue As Int64)
            _base = New MinValueAttributeBase(Of Int64)(minValue)
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
        Protected Overrides Function IsValid _
        (value As Object, validationContext As ValidationContext) As ValidationResult

            Return _base.IsValid(Convert.ToInt64(value), validationContext)
        End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace



