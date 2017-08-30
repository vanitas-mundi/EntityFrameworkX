Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Base.Attributes
Imports SSP.Base.Binding
Imports SSP.Base.ReflectionHandling
Imports SSP.Base.Serialization
Imports SSP.Base.StringHandling
#End Region

Namespace Models.Core

  Public MustInherit Class ModelBase(Of TModel As {Class})
    Inherits NotifyPropertyChangedBase

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New()
      Me.ReflectionInfo = New ReflectionInfo(Me)
      Me.Serializer = New ObjectSerializer(Of TModel)(Me)
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Stellt Funktionalität zur Serialisierung zur Verfügung.</summary>
    <NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public ReadOnly Property Serializer As ObjectSerializer(Of TModel)

    '''<summary>Stellt Funktionalität zum Auslesen von Eigenschaften zur Verfügung.</summary>
    <NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public ReadOnly Property ReflectionInfo As ReflectionInfo

    '''<summary>Liefert den aktuellen CultureCode oder legt diesen fest.</summary>
    <NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property ModelCultureCode As CultureCodes
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    'Protected Overrides Function SetPropertyValueAndRaisePropertyChanged(Of T) _
    '(propertyName As String, ByRef oldValue As T, newValue As T) As Boolean

    '	Dim result = MyBase.SetPropertyValueAndRaisePropertyChanged(propertyName, oldValue, newValue)
    '	Select Case Me.State
    '		Case SelfTrackingModelStates.Added, SelfTrackingModelStates.Deleted
    '		Case Else
    '			Me.State = SelfTrackingModelStates.Modified
    '			If Not _changedProperties.Contains(propertyName) Then
    '				_changedProperties.Add(propertyName)
    '			End If
    '	End Select
    '	Return result
    'End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

