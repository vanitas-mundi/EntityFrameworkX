Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.GitModels.EnumAdapters

#End Region

Namespace Models.GitModels

	Partial Public Class Kachel

		Inherits ModelBase(Of Kachel)
		Implements IModelBase(Of Kachel, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			KachelID
			RepositoryFID
			Anwendung
			KacheltypDatabaseValue
			Controller
			Iconname
			Refreshrate
			Beschreibung
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of Kachel, PropertyNames, GitContext)

		Private _rowId as Int64
		Private _kachelId AS Int64
		Private _repositoryFID AS Int64
		Private _anwendung As String
		Private _kacheltyp As String
		Private _controller As String
		Private _iconname As String
		Private _refreshrate As String
		Private _beschreibung As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore(Of Kachel, PropertyNames, GitContext)("git.t_kacheln")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.KachelID, "KachelID")
			_modelCore.AddMappingInformation(PropertyNames.RepositoryFID, "RepositoryFID")
			_modelCore.AddMappingInformation(PropertyNames.Anwendung, "Anwendung")
			_modelCore.AddMappingInformation(PropertyNames.KacheltypDatabaseValue, "Kacheltyp")
			_modelCore.AddMappingInformation(PropertyNames.Controller, "Controller")
			_modelCore.AddMappingInformation(PropertyNames.Iconname, "Iconname")
			_modelCore.AddMappingInformation(PropertyNames.Refreshrate, "Refreshrate")
			_modelCore.AddMappingInformation(PropertyNames.Beschreibung, "Beschreibung")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of Kachel, PropertyNames, GitContext).RowId
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
		Public Property KachelID As Int64
			Get
				Return _kachelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.KachelID), _kachelId, value)
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

		Public Property Anwendung As String
			Get
				Return _anwendung
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Anwendung), _anwendung, value)
			End Set
		End Property

#Region " KacheltypEnum "
		'''<summary>GenderDatabaseValue - Bitte zum setzen des Geschlechts die NewPropertyEnum-Eigenschaft benutzen!!!</summary>
		Public Property KacheltypDatabaseValue As String
			Get
				Return _kacheltyp
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.KacheltypDatabaseValue), _kacheltyp, value)
				MyBase.RaisePropertyChanged(NameOf(Me.Kacheltyp))
				MyBase.RaisePropertyChanged(NameOf(Me.KacheltypDisplayValue))
			End Set
		End Property

		'''<summary>AnzeigeName.</summary>
		<NotMapped>
		Public Property Kacheltyp As KachelEnum
			Get
				Return KachelEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.KacheltypDatabaseValue)
			End Get
			Set(value As KachelEnum)
				Me.KacheltypDatabaseValue = KachelEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
			End Set
		End Property

		'''<summary>AnzeigeName-Anzeige-String. für DataBinding benutzen</summary>
		<NotMapped>
		Public Property KacheltypDisplayValue As String
			Get
				Return KachelEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.Kacheltyp)
			End Get
			Set(value As String)
				Me.Kacheltyp = KachelEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
			End Set
		End Property
#End Region

		Public Property Controller As String
			Get
				Return _controller
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Controller), _controller, value)
			End Set
		End Property

		Public Property Iconname As String
			Get
				Return _iconname
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Iconname), _iconname, value)
			End Set
		End Property

		Public Property Refreshrate As String
			Get
				Return _refreshrate
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Refreshrate), _refreshrate, value)
			End Set
		End Property

		Public Property Beschreibung As String
			Get
				Return _beschreibung
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Beschreibung), _beschreibung, value)
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
		(Of Kachel, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of Kachel, PropertyNames, GitContext) _
		Implements IModelBase(Of Kachel, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of Kachel) _
		Implements IModelBase(Of Kachel, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of Kachel))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace