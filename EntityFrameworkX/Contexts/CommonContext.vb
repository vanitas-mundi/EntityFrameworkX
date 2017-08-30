Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Common
Imports SSP.Data.EntityFrameworkX.Models.Common
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Contexts.Core

#End Region

Namespace Contexts

	Public Class CommonContext

		Inherits DbContext
		Implements IContextBase(Of CommonContext)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _contextBase As ContextBase(Of CommonContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal dbConnection As DbConnection)
			Me.New(dbConnection, False)
			_contextBase = New ContextBase(Of CommonContext)(Me)
		End Sub

		Public Sub New(ByVal dbConnection As DbConnection, ByVal contextOwnsConnection As Boolean)
			MyBase.New(dbConnection, contextOwnsConnection)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property ValueAddedTaxControllings As DbSet(Of ValueAddedTaxControlling)
		'''<summary>RechnungenIdCards</summary>
		Public Property IdCardBills As DbSet(Of IdCardBill)
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
			ValueAddedTaxControlling.GetModelCore.AddToModelBuilder(modelBuilder)
			IdCardBill.GetModelCore.AddToModelBuilder(modelBuilder)
		End Sub

		Public Function ContextBase() As ContextBase(Of CommonContext) _
		Implements IContextBase(Of CommonContext).ContextBase
			Return _contextBase
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
