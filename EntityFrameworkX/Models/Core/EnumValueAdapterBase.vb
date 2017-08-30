Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Collections.ObjectModel
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
#End Region

Namespace Models.Core

	'''<summary></summary>
	Public Class EnumValueAdapterBase(Of TEnum As Structure)

		Implements IEnumValueAdapter(Of TEnum)

#Region " --------------->> Enumerationen der Klasse "
		Private _enumValueDictionary As New EnumValueAdapterInitializer(Of TEnum)
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public ReadOnly Property EnumValueDictionary As EnumValueAdapterInitializer(Of TEnum) _
		Implements IEnumValueAdapter(Of TEnum).EnumValueDictionary
			Get
				Return _enumValueDictionary
			End Get
		End Property

		Public ReadOnly Property DisplayValues As ReadOnlyCollection(Of String) _
		Implements IEnumValueAdapter(Of TEnum).DisplayValues
			Get
				Return _enumValueDictionary.Values.Select(Function(x) x.DisplayValue).ToList.AsReadOnly()
			End Get
		End Property

		Public ReadOnly Property DatabaseValues As ReadOnlyCollection(Of String) _
		Implements IEnumValueAdapter(Of TEnum).DatabaseValues
			Get
				Return _enumValueDictionary.Values.Select(Function(x) x.DatabaseValue).ToList.AsReadOnly()
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		'''<summary>Schlägt im hinterlegten Dictionary den entsprechenden DisplayString value nach und liefert dessen Enum-Wert.</summary>
		Public Function ParseDisplayStringToEnumValue(value As String) As TEnum _
		Implements IEnumValueAdapter(Of TEnum).ParseDisplayStringToEnumValue

			Return _enumValueDictionary.Keys.Where _
			(Function(x) String.Compare(_enumValueDictionary.Item(x).DisplayValue, value, True) = 0).First
		End Function

		'''<summary>Schlägt im hinterlegten Dictionary den entsprechenden Enum-Wert value nach und liefert dessen DisplayString.</summary>
		Public Function ParseEnumValueToDisplayString(value As TEnum) As String _
		Implements IEnumValueAdapter(Of TEnum).ParseEnumValueToDisplayString

			Return _enumValueDictionary.Item(value).DisplayValue
		End Function

		'''<summary>Schlägt im hinterlegten Dictionary den entsprechenden DatabaseString value nach und liefert dessen Enum-Wert.</summary>
		Public Function ParseDatabaseStringToEnumValue(value As String) As TEnum _
		Implements IEnumValueAdapter(Of TEnum).ParseDatabaseStringToEnumValue

			Return _enumValueDictionary.Keys.Where _
			(Function(x) String.Compare(_enumValueDictionary.Item(x).DatabaseValue, value, True) = 0).First
		End Function

		'''<summary>Schlägt im hinterlegten Dictionary den entsprechenden Enum-Wert value nach und liefert dessen DatabaseString.</summary>
		Public Function ParseEnumValueToDatabaseString(value As TEnum) As String _
		Implements IEnumValueAdapter(Of TEnum).ParseEnumValueToDatabaseString

			Return _enumValueDictionary.Item(value).DatabaseValue
		End Function

		'''<summary>Wandelt den übergebenen DisplayString value in einen Enum-Wert um und liefert diesen zurück.</summary>
		Public Function ParseToEnumValue(value As String) As TEnum _
		Implements IEnumValueAdapter(Of TEnum).ParseToEnumValue

			Return CType(System.Enum.Parse(GetType(TEnum), value), TEnum)
		End Function

		'''<summary>Initialisiert das Dictionary des Adapters.</summary>
		Public Sub InitializeAdapter(initializer As EnumValueAdapterInitializer(Of TEnum)) _
		Implements IEnumValueAdapter(Of TEnum).InitializeAdapter

			_enumValueDictionary = New EnumValueAdapterInitializer(Of TEnum)
			_enumValueDictionary = initializer
		End Sub
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace

