Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Common
Imports SSP.Data.EntityFrameworkX.Models.GitModels
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Contexts.Core
#End Region

Namespace Contexts

	Public Class GitContext

		Inherits DbContext
		Implements IContextBase(Of GitContext)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _contextBase As ContextBase(Of GitContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal dbConnection As DbConnection)
			Me.New(dbConnection, False)
			_contextBase = New ContextBase(Of GitContext)(Me)
		End Sub

		Public Sub New(ByVal dbConnection As DbConnection, ByVal contextOwnsConnection As Boolean)
			MyBase.New(dbConnection, contextOwnsConnection)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property Repositories As DbSet(Of Repository)
		Public Property RepositoryDependencies As DbSet(Of RepositoryDependency)
		Public Property RepositoryDeveloper As DbSet(Of RepositoryDeveloper)
		Public Property RepositoryProductowner As DbSet(Of RepositoryProductowner)
		Public Property Kacheln As DbSet(Of Kachel)
		Public Property PersonenKacheln As DbSet(Of PersonenKachel)
		Public Property Schlagworte As DbSet(Of Schlagwort)
		Public Property KachelSchlagworte As DbSet(Of KachelSchlagwort)
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
		Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
			AddToModelBuilder(modelBuilder)
			MyBase.OnModelCreating(modelBuilder)
		End Sub
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Shared Sub AddToModelBuilder(modelBuilder As DbModelBuilder)
			Repository.GetModelCore.AddToModelBuilder(modelBuilder)
			RepositoryDependency.GetModelCore.AddToModelBuilder(modelBuilder)
			Kachel.GetModelCore().AddToModelBuilder(modelBuilder)
			PersonenKachel.GetModelCore().AddToModelBuilder(modelBuilder)
			Models.GitModels.RepositoryDeveloper.GetModelCore().AddToModelBuilder(modelBuilder)
			Models.GitModels.RepositoryProductowner.GetModelCore().AddToModelBuilder(modelBuilder)
			Schlagwort.GetModelCore().AddToModelBuilder(modelBuilder)
			KachelSchlagwort.GetModelCore().AddToModelBuilder(modelBuilder)
		End Sub

		Public Function ContextBase() As ContextBase(Of GitContext) _
		Implements IContextBase(Of GitContext).ContextBase
			Return _contextBase
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
