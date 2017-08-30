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

	Partial Public Class PersonenKachel

		Inherits ModelBase(Of PersonenKachel)
		Implements IModelBase(Of PersonenKachel, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			PersonenKachelID
			KachelFID
			PersonenFID
			UserKachelInformationFID
			Gruppenname
			Parameter
			PositionIndex
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of PersonenKachel, PropertyNames, GitContext)

		Private _rowId as Int64
		Private _personenKachelId AS Int64
		Private _kachelFID AS Int64
		Private _personenFID AS Int64
		Private _userKachelInformationFID AS Int64
		Private _gruppenname AS string
		Private _parameter AS string
		Private _positionIndex AS string
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore(Of PersonenKachel, PropertyNames, GitContext)("git.t_personen_kacheln")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.PersonenKachelID, "PersonenKachelId")
			_modelCore.AddMappingInformation(PropertyNames.KachelFID, "KachelFID")
			_modelCore.AddMappingInformation(PropertyNames.PersonenFID, "PersonenFID")
			_modelCore.AddMappingInformation(PropertyNames.UserKachelInformationFID, "UserKachelInformationFID")
			_modelCore.AddMappingInformation(PropertyNames.Gruppenname, "Gruppenname")
			_modelCore.AddMappingInformation(PropertyNames.Parameter, "Parameter")
			_modelCore.AddMappingInformation(PropertyNames.PositionIndex, "PositionIndex")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of PersonenKachel, PropertyNames, GitContext).RowId
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
		Public Property PersonenKachelID As Int64
			Get
				Return _personenKachelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.PersonenKachelID), _personenKachelId, value)
			End Set
		End Property

		Public Property KachelFID As Int64
			Get
				Return _kachelFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.KachelFID), _kachelFID, value)
			End Set
		End Property

		Public Property PersonenFID As Int64
			Get
				Return _personenFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.PersonenFID), _personenFID, value)
			End Set
		End Property

		Public Property UserKachelInformationFID As Int64
			Get
				Return _userKachelInformationFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.UserKachelInformationFID), _userKachelInformationFID, value)
			End Set
		End Property

		Public Property Gruppenname As String
			Get
				Return _gruppenname
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Gruppenname), _gruppenname, value)
			End Set
		End Property

		Public Property Parameter As String
			Get
				Return _parameter
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Parameter), _parameter, value)
			End Set
		End Property

		Public Property PositionIndex As String
			Get
				Return _positionIndex
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.PositionIndex), _positionIndex, value)
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
		(Of PersonenKachel, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of PersonenKachel, PropertyNames, GitContext) _
		Implements IModelBase(Of PersonenKachel, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of PersonenKachel) _
		Implements IModelBase(Of PersonenKachel, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of PersonenKachel))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace