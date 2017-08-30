Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces

#End Region

Namespace Models.GitModels

	Partial Public Class RepositoryProductowner

		Inherits ModelBase(Of RepositoryProductowner)
		Implements IModelBase(Of RepositoryProductowner, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			id
			RepositoryFID
			PersonFID
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of RepositoryProductowner, PropertyNames, GitContext)

		Private _rowId as Int64
		Private _id AS Int64
		Private _repositoryFID AS Int64
		Private _personFID AS Int64
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore(Of RepositoryProductowner, PropertyNames, GitContext)("git.t_repository_productowner")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.id, "id")
			_modelCore.AddMappingInformation(PropertyNames.RepositoryFID, "RepositoryFID")
			_modelCore.AddMappingInformation(PropertyNames.PersonFID, "PersonFID")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of RepositoryProductowner, PropertyNames, GitContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		<Key>
		Public Property Id As Int64
			Get
				Return _id
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.Id), _id, value)
			End Set
		End Property

		Public Property RepositoryFID As Int64
			Get
				Return _repositoryFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RepositoryFID), _repositoryFID, value)
			End Set
		End Property

		Public Property PersonFID As Int64
			Get
				Return _personFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.PersonFID), _personFID, value)
			End Set
		End Property


#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return MyBase.ToString
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of RepositoryProductowner, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of RepositoryProductowner, PropertyNames, GitContext) _
		Implements IModelBase(Of RepositoryProductowner, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of RepositoryProductowner) _
		Implements IModelBase(Of RepositoryProductowner, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of RepositoryProductowner))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace