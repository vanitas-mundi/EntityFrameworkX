Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Models.GitModels.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core
#End Region

Namespace Models.GitModels.EnumAdapters

	Public Class RepositoryTechnologyEnumAdapter

		Inherits EnumValueAdapterBase(Of RepositoryTechnologies)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As RepositoryTechnologyEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_instance = New RepositoryTechnologyEnumAdapter
		End Sub

		Private Sub New()
			Dim initializer = New EnumValueAdapterInitializer(Of RepositoryTechnologies)
			initializer.AddToDictionary(RepositoryTechnologies.None, "-")
			initializer.AddToDictionary(RepositoryTechnologies.NET, ".NET")
			initializer.AddToDictionary(RepositoryTechnologies.Console)
			initializer.AddToDictionary(RepositoryTechnologies.WindowsForms)
			initializer.AddToDictionary(RepositoryTechnologies.WPF)
			initializer.AddToDictionary(RepositoryTechnologies.VB6)
			initializer.AddToDictionary(RepositoryTechnologies.WebService)
			Me.InitializeAdapter(initializer)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As RepositoryTechnologyEnumAdapter
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
