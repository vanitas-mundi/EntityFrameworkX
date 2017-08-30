Option Explicit On
Option Infer On
Option Strict On
Imports System.ComponentModel.DataAnnotations

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
#End Region

Namespace Models.GitModels

	Partial Public Class RepositoryDependency

		Inherits ModelBase(Of RepositoryDependency)
		Implements IModelBase(Of RepositoryDependency, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			RepositoryDependencyId
			RepositoryId
			DependencyId
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of RepositoryDependency, PropertyNames, GitContext)

		Private _rowId As Int64
		Private _repositoryDependencyId As Int64
		Private _repositoryId As Int64
		Private _dependencyId As Int64
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of RepositoryDependency, PropertyNames, GitContext)("git.t_repository_dependencies")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.RepositoryDependencyId, "Id")
			_modelCore.AddMappingInformation(PropertyNames.RepositoryId, "RepositoryFId")
			_modelCore.AddMappingInformation(PropertyNames.DependencyId, "DependencyFId")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of RepositoryDependency, PropertyNames, GitContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		'''<summary>Id.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RepositoryDependencyId As Int64
			Get
				Return _repositoryDependencyId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged(Of Int64) _
				(NameOf(Me.RepositoryDependencyId), _repositoryDependencyId, value)
			End Set
		End Property

		'''<summary>Id des Repostorys.</summary>
		<Required>
		Public Property RepositoryId As Int64
			Get
				Return _repositoryId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged(Of Int64) _
				(NameOf(Me.RepositoryId), _repositoryId, value)
			End Set
		End Property

		'''<summary>Id der Abhängigkeit.</summary>
		<Required>
		Public Property DependencyId As Int64
			Get
				Return _dependencyId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.DependencyId), _dependencyId, value)
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Shared Function GetModelCore() As ModelCore _
		(Of RepositoryDependency, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Public Overrides Function ToString() As String
			Return MyBase.ToString
		End Function

		Private Function ModelCore() As ModelCore(Of RepositoryDependency, PropertyNames, GitContext) _
		Implements IModelBase(Of RepositoryDependency, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of RepositoryDependency) _
		Implements IModelBase(Of RepositoryDependency, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of RepositoryDependency))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace