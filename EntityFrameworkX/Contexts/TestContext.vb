Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Common
Imports SSP.Data.EntityFrameworkX.Models.Test
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Contexts.Core
#End Region

Namespace Contexts

	Public Class TestContext

		Inherits DbContext
		Implements IContextBase(Of TestContext)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _contextBase As ContextBase(Of TestContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal dbConnection As DbConnection)
			Me.New(dbConnection, False)
			_contextBase = New ContextBase(Of TestContext)(Me)
		End Sub

		Public Sub New(ByVal dbConnection As DbConnection, ByVal contextOwnsConnection As Boolean)
			MyBase.New(dbConnection, contextOwnsConnection)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Property IdCards As DbSet(Of IdCard)
    Public Property ValidationTestModels As DbSet(Of ValidationTestModel)
    Public Property NameModels As DbSet(Of NameModel)
    Public Property ValueModels As DbSet(Of ValueModel)
    Public Property SchulungsteilnehmerCollection As DbSet(Of SchulungsTeilnehmer)
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
      ValidationTestModel.GetModelCore.AddToModelBuilder(modelBuilder)
      NameModel.GetModelCore.AddToModelBuilder(modelBuilder)
      ValueModel.GetModelCore.AddToModelBuilder(modelBuilder)
      SchulungsTeilnehmer.GetModelCore.AddToModelBuilder(modelBuilder)
      IdCard.GetModelCore.AddToModelBuilder(modelBuilder)
    End Sub

    Public Function ContextBase() As ContextBase(Of TestContext) _
		Implements IContextBase(Of TestContext).ContextBase
			Return _contextBase
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
