Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Common
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Contexts.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels
#End Region

Namespace Contexts

	Public Class MasterDataContext

		Inherits DbContext
		Implements IContextBase(Of MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _contextBase As ContextBase(Of MasterDataContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal dbConnection As DbConnection)
			Me.New(dbConnection, False)
			_contextBase = New ContextBase(Of MasterDataContext)(Me)
		End Sub

		Public Sub New(ByVal dbConnection As DbConnection, ByVal contextOwnsConnection As Boolean)
			MyBase.New(dbConnection, contextOwnsConnection)
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property Persons As DbSet(Of Person)
		Public Property Communications As DbSet(Of Communication)
		Public Property Addresses As DbSet(Of Address)
		Public Property PersonAcademicTitles As DbSet(Of PersonAcademicTitle)
		Public Property PersonPhotos As DbSet(Of PersonPhoto)
		Public Property PersonStati As DbSet(Of PersonStatus)

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
            Person.GetModelCore.AddToModelBuilder(modelBuilder)
            Communication.GetModelCore.AddToModelBuilder(modelBuilder)
            Address.GetModelCore.AddToModelBuilder(modelBuilder)
            PersonAcademicTitle.GetModelCore.AddToModelBuilder(modelBuilder)
            PersonPhoto.GetModelCore.AddToModelBuilder(modelBuilder)
            PersonStatus.GetModelCore.AddToModelBuilder(modelBuilder)
            PersonEducation.GetModelCore.AddToModelBuilder(modelBuilder)
            Company.GetModelCore.AddToModelBuilder(modelBuilder)
        End Sub

        Public Function ContextBase() As ContextBase(Of MasterDataContext) _
		Implements IContextBase(Of MasterDataContext).ContextBase
			Return _contextBase
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
