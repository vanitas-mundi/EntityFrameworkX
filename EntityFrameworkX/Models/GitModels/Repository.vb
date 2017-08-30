Option Explicit On
Option Infer On
Option Strict On
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.GitModels.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.GitModels.Enums
#End Region

Namespace Models.GitModels

	Partial Public Class Repository

		Inherits ModelBase(Of Repository)
		Implements IModelBase(Of Repository, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			RepositoryId
			Name
			DisplayName
			LocalPath
			Comment
			TechnologyDatabaseValue
			TeamCityDatabaseValue
			ShowInCommitHelperDatabaseValue
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of Repository, PropertyNames, GitContext)

		Private _rowId As Int64
		Private _repositoryId As Int64
		Private _name As String
		Private _displayName As String
		Private _localPath As String
		Private _comment As String = ""
		Private _technologyDatabaseValue As String
		Private _teamCityDatabaseValue As String
		Private _showInCommitHelperDatabaseValue As String
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of Repository, PropertyNames, GitContext)("git.t_repositories")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.RepositoryId, "Id")
			_modelCore.AddMappingInformation(PropertyNames.Name, "Name")
			_modelCore.AddMappingInformation(PropertyNames.DisplayName, "DisplayName")
			_modelCore.AddMappingInformation(PropertyNames.LocalPath, "LocalPath")
			_modelCore.AddMappingInformation(PropertyNames.Comment, "Comment")
			_modelCore.AddMappingInformation(PropertyNames.TechnologyDatabaseValue, "Technology")
			_modelCore.AddMappingInformation(PropertyNames.TeamCityDatabaseValue, "TeamCity")
			_modelCore.AddMappingInformation(PropertyNames.ShowInCommitHelperDatabaseValue, "ShowInCommitHelper")
		End Sub

		Public Sub New()
			Me.Technology = RepositoryTechnologies.None
			Me.TeamCity = YesNoEnum.No
			Me.ShowInCommitHelper = YesNoEnum.No
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of Repository, PropertyNames, GitContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		'''<summary>Id - Repository-Id.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RepositoryId As Int64
			Get
				Return _repositoryId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RepositoryId), _repositoryId, value)
			End Set
		End Property

		'''<summary>Name des Repositorys.</summary>
		<Required>
		<MaxLength(80)>
		Public Property Name As String
			Get
				Return _name
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Name), _name, value)
			End Set
		End Property

		'''<summary>Anzeigename des Repositorys.</summary>
		<Required>
		<MaxLength(80)>
		Public Property DisplayName As String
			Get
				Return _displayName
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.DisplayName), _displayName, value)
			End Set
		End Property

		'''<summary>Lokaler Pfad des Repositorys.</summary>
		<Required>
		Public Property LocalPath As String
			Get
				Return _localPath
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.LocalPath), _localPath, value)
			End Set
		End Property

		'''<summary>Bemerkung des Repositorys.</summary>
		Public Property Comment As String
			Get
				Return _comment
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Comment), _comment, value)
			End Set
		End Property

#Region " Technology "
		'''<summary>TechnologyDatabaseValue - Bitte zum setzen die Technology-Eigenschaft benutzen!!!</summary>
		Public Property TechnologyDatabaseValue As String
			Get
				Return _technologyDatabaseValue
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.TechnologyDatabaseValue), _technologyDatabaseValue, value)
				MyBase.RaisePropertyChanged(NameOf(Me.Technology))
				MyBase.RaisePropertyChanged(NameOf(Me.TechnologyDisplayValue))
			End Set
		End Property

		'''<summary>Eingesetzte Technologie.</summary>
		<NotMapped>
		Public Property Technology As RepositoryTechnologies
			Get
				Return RepositoryTechnologyEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.TechnologyDatabaseValue)
			End Get
			Set(value As RepositoryTechnologies)
				Me.TechnologyDatabaseValue = RepositoryTechnologyEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
			End Set
		End Property

		'''<summary>Technologie-Anzeige-String. für DataBinding benutzen</summary>
		<NotMapped>
		Public Property TechnologyDisplayValue As String
			Get
				Return RepositoryTechnologyEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.Technology)
			End Get
			Set(value As String)
				Me.Technology = RepositoryTechnologyEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
			End Set
		End Property
#End Region

#Region " TeamCity "
		'''<summary>TeamCityDatabaseValue - Bitte zum setzen die TeamCity-Eigenschaft benutzen!!!</summary>
		Public Property TeamCityDatabaseValue As String
			Get
				Return _teamCityDatabaseValue
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.TeamCityDatabaseValue), _teamCityDatabaseValue, value)
				MyBase.RaisePropertyChanged(NameOf(Me.TeamCity))
				MyBase.RaisePropertyChanged(NameOf(Me.TeamCityDisplayValue))
			End Set
		End Property

		'''<summary>Anzeige in TeamCity.</summary>
		<NotMapped>
		Public Property TeamCity As YesNoEnum
			Get
				Return YesNoEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.TeamCityDatabaseValue)
			End Get
			Set(value As YesNoEnum)
				Me.TeamCityDatabaseValue = YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
			End Set
		End Property

		'''<summary>Anzeige-in-TeamCity-Anzeige-String. für DataBinding benutzen</summary>
		<NotMapped>
		Public Property TeamCityDisplayValue As String
			Get
				Return YesNoEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.TeamCity)
			End Get
			Set(value As String)
				Me.TeamCity = YesNoEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
			End Set
		End Property
#End Region

#Region " ShowInCommitHelper "
		'''<summary>ShowInCommitHelperDatabaseValue - Bitte zum Setzen die ShowInCommitHelper-Eigenschaft benutzen!!!</summary>
		Public Property ShowInCommitHelperDatabaseValue As String
			Get
				Return _showInCommitHelperDatabaseValue
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.ShowInCommitHelperDatabaseValue), _showInCommitHelperDatabaseValue, value)
				MyBase.RaisePropertyChanged(NameOf(Me.ShowInCommitHelper))
				MyBase.RaisePropertyChanged(NameOf(Me.ShowInCommitHelperDisplayValue))
			End Set
		End Property

		'''<summary>Repository wird in CommitHelper angezeigt.</summary>
		<NotMapped>
		Public Property ShowInCommitHelper As YesNoEnum
			Get
				Return YesNoEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.ShowInCommitHelperDatabaseValue)
			End Get
			Set(value As YesNoEnum)
				Me.ShowInCommitHelperDatabaseValue = YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
			End Set
		End Property

		'''<summary>ShowInCommitHelper-Anzeige-String. für DataBinding benutzen</summary>
		<NotMapped>
		Public Property ShowInCommitHelperDisplayValue As String
			Get
				Return YesNoEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.ShowInCommitHelper)
			End Get
			Set(value As String)
				Me.ShowInCommitHelper = YesNoEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
			End Set
		End Property
#End Region

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Shared Function GetModelCore() As ModelCore(Of Repository, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Public Overloads Overrides Function ToString() As String
			Return Me.ToString(False)
		End Function

		Public Overloads Function ToString(ByVal includeRepositoryName As Boolean) As String
			Return String.Concat(Me.DisplayName, If(includeRepositoryName, String.Format(" [{0}.git]", Me.Name), ""))
		End Function

		Private Function ModelCore() As ModelCore(Of Repository, PropertyNames, GitContext) _
		Implements IModelBase(Of Repository, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of Repository) _
		Implements IModelBase(Of Repository, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of Repository))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace