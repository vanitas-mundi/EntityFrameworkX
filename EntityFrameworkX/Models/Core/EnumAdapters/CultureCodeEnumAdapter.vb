Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.StringHandling
#End Region

Namespace Models.Core.EnumAdapters

	Public Class CultureCodeEnumAdapter

		Inherits EnumValueAdapterBase(Of CultureCodes)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As CultureCodeEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New CultureCodeEnumAdapter
		End Sub

		Private Sub New()
			Dim initializer = New EnumValueAdapterInitializer(Of CultureCodes)

			Dim temp = System.Enum.GetValues _
			(GetType(CultureCodes)).OfType(Of CultureCodes).Select(Function(x) New With
			{.Value = x, .DisplayName = x.ToString.Replace("_", "-").Replace("a_Default", "")}).ToList
			temp.ForEach(Sub(x) initializer.AddToDictionary(x.Value, x.DisplayName))

			Me.InitializeAdapter(initializer)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As CultureCodeEnumAdapter
			Get
				Return _instance
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}


	End Class

End Namespace
