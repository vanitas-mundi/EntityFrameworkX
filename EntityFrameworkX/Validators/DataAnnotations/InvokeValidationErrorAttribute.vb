Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
#End Region

Namespace Validators.DataAnnotations

    '''<summary>
    '''Kann benutzt werden, um unabhängig vom zugeweisenen Eigenschaften-Wert,
    '''einen Validierungsverstoß auszulösen (und dient zugleich als Beispiel für eine ValidationAttribute-Implementierung :)).
    '''</summary>
    Public Class InvokeValidationErrorAttributeAttribute

        Inherits ValidationAttribute

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
        Protected Overrides Function IsValid(value As Object, validationContext As ValidationContext) As ValidationResult

            'Return ValidationResult.Success ' wenn kein Validierungsverstoß existiert

            Return New ValidationResult("Das Feld """ & validationContext.MemberName _
            & """ wurde mit der DataAnnotation ""InvokeValidationErrorAttributeAttribute""" _
            & " markiert und löst deshalb immer diesen Valdierungsverstoß aus!!!" _
            , New String() {validationContext.MemberName})
        End Function
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace



