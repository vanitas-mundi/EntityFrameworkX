Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
'Bsp: Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
#End Region

Namespace Models.MasterDataModels.EnumAdapters

	Public Class RolleEnumAdapter

		Inherits EnumValueAdapterBase(Of RolleEnum)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As RolleEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New RolleEnumAdapter
		End Sub

		Private Sub New()
			Dim initializer = New EnumValueAdapterInitializer(Of RolleEnum)
			initializer.AddToDictionary(RolleEnum.Vertreter, "Vertreter", "Vertreter")
			initializer.AddToDictionary(RolleEnum.Stellvertreter, "Stellvertreter", "Stellvertreter")
			Me.InitializeAdapter(initializer)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As RolleEnumAdapter
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