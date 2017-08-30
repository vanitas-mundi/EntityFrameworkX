Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums

#End Region

Namespace Models.MasterDataModels.EnumAdapters

	Public Class GenderEnumAdapter

		Inherits EnumValueAdapterBase(Of GenderEnum)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As GenderEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New GenderEnumAdapter
		End Sub

		Private Sub New()
			Dim initializer = New EnumValueAdapterInitializer(Of GenderEnum)
			initializer.AddToDictionary(GenderEnum.Unknown, "unbekannt", "-")
			initializer.AddToDictionary(GenderEnum.Male, "männlich", "M")
			initializer.AddToDictionary(GenderEnum.Female, "weiblich", "W")
			Me.InitializeAdapter(initializer)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As GenderEnumAdapter
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
