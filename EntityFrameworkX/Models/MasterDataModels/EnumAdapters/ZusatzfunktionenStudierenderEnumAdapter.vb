	Option Explicit On
	Option Infer On
	Option Strict On

#Region " --------------->> Imports/ usings "

Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums

#End Region

Namespace Models.MasterDataModels.EnumAdapters

	Public Class FunktionEnumAdapter

		Inherits EnumValueAdapterBase(Of FunktionEnum)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As FunktionEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New FunktionEnumAdapter
		End Sub

		Private Sub New()
			Dim initializer = New EnumValueAdapterInitializer(Of FunktionEnum)
			initializer.AddToDictionary(FunktionEnum.Prüfungsausschuss, "Prüfungsausschuss", "Prüfungsausschuss")
			initializer.AddToDictionary(FunktionEnum.Berufungskommission, "Berufungskommission", "Berufungskommission")
			initializer.AddToDictionary(FunktionEnum.Delegiertenversammlung, "Delegiertenversammlung", "Delegiertenversammlung")
			initializer.AddToDictionary(FunktionEnum.Qualitätsmanagement, "Qualitätsmanagement", "Qualitätsmanagement")
			initializer.AddToDictionary(FunktionEnum.Semestersprecher, "Semestersprecher", "Semestersprecher")
			initializer.AddToDictionary(FunktionEnum.Studienparlament, "Studienparlament", "Studienparlament")
			Me.InitializeAdapter(initializer)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As FunktionEnumAdapter
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