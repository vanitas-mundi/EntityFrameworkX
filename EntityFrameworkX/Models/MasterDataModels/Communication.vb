Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Base.Attributes
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
#End Region

Namespace Models.MasterDataModels

	Partial Public Class Communication

		Inherits ModelBase(Of Communication)
		Implements IModelBase(Of Communication, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			CommunicationId
			PersonId
			Value
			Name
            BenachrichtigungOnlineCampusDatabaseValue
            IstGeloescht
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore _
		(Of Communication, PropertyNames, MasterDataContext)

		Private _rowId As Int64
		Private _communicationId As Int64
		Private _personId As Int64
		Private _value As String
		Private _name As String
        Private _benachrichtigungOnlineCampus As String
        Private _istGeloescht As DateTime?
            
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of Communication, PropertyNames, MasterDataContext)("datapool.t_kommunikation")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.CommunicationId, "KommunikationsID")
			_modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenFID")
			_modelCore.AddMappingInformation(PropertyNames.Value, "Value")
			_modelCore.AddMappingInformation(PropertyNames.Name, "Name")
            _modelCore.AddMappingInformation(PropertyNames.BenachrichtigungOnlineCampusDatabaseValue, "BenachrichtigungOC")
            _modelCore.AddMappingInformation(PropertyNames.IstGeloescht, "IstGeloescht")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Primärschlüssel.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of Communication, PropertyNames, MasterDataContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		'''<summary>Kommunikations-Id.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property CommunicationId As Int64
			Get
				Return _communicationId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.CommunicationId), _communicationId, value)
			End Set
		End Property

		'''<summary>Personen-Id.</summary>
		<Required>
		Public Property PersonId As Int64
			Get
				Return _personId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.PersonId), _personId, value)
			End Set
		End Property

		'''<summary>Wert des Kommunikationsmediums.</summary>
		<Required>
		Public Property Value As String
			Get
				Return _value
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Value), _value, value)
			End Set
		End Property

		'''<summary>Name des Kommunikationsmediums.</summary>
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

#Region " BenachrichtigungOnlineCampus "
        '''<summary>GenderDatabaseValue - Bitte zum setzen des Geschlechts die BenachrichtigungOnlineCampus-Eigenschaft benutzen!!!</summary>
        <Required>
        <ViewGenerator(IsBrowseable:=False)>
        Public Property BenachrichtigungOnlineCampusDatabaseValue As String
            Get
                Return _benachrichtigungOnlineCampus
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.BenachrichtigungOnlineCampusDatabaseValue), _benachrichtigungOnlineCampus, value)
                MyBase.RaisePropertyChanged(NameOf(Me.BenachrichtigungOnlineCampus))
                MyBase.RaisePropertyChanged(NameOf(Me.BenachrichtigungOnlineCampusDisplayValue))
            End Set
        End Property

        '''<summary>BenachrichtigungOnlineCampus.</summary>
        <NotMapped>
        <ViewGenerator(DisplayName:="BenachrichtigungOnlineCampus", ViewType:=ViewTypes.Enum)>
        Public Property BenachrichtigungOnlineCampus As YesNoEnum
            Get
                Return YesNoEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.BenachrichtigungOnlineCampusDatabaseValue)
            End Get
            Set(value As YesNoEnum)
                Me.BenachrichtigungOnlineCampusDatabaseValue = YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
            End Set
        End Property

        '''<summary>BenachrichtigungOnlineCampus-Anzeige-String. für DataBinding benutzen</summary>
        <NotMapped>
        <ViewGenerator(IsBrowseable:=False)>
        Public Property BenachrichtigungOnlineCampusDisplayValue As String
            Get
                Return YesNoEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.BenachrichtigungOnlineCampus)
            End Get
            Set(value As String)
                Me.BenachrichtigungOnlineCampus = YesNoEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
            End Set
        End Property
#End Region

        Public Property IstGeloescht As DateTime?
			Get
				Return _istGeloescht
			End Get
			Set(value As DateTime?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime?)(NameOf(Me.IstGeloescht), _istGeloescht, value)
			End Set
		End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return String.Concat(Me.Name, ": ", Me.Value)
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of Communication, PropertyNames, MasterDataContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of Communication, PropertyNames, MasterDataContext) _
		Implements IModelBase(Of Communication, PropertyNames, MasterDataContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of Communication) _
		Implements IModelBase(Of Communication, PropertyNames, MasterDataContext).ModelBase
			Return DirectCast(Me, ModelBase(Of Communication))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
