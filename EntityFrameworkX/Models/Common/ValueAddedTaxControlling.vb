Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces

#End Region

Namespace Models.Common

	''' <summary>
	''' Database: bcw_allgemein
	''' Table: t_mwst_steuerung
	''' </summary>
	Partial Public Class ValueAddedTaxControlling

		Inherits ModelBase(Of ValueAddedTaxControlling)
		Implements IModelBase(Of ValueAddedTaxControlling, PropertyNames, CommonContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			ValueAddedTaxControllingId
			Name
			EffortPositionFID
			FiscalDomicile
			StudyLocation
			TypeOfFee
			Controllable
			TaxDuty
			ValueAddedTaxRate
			MethodOfTaxation
			Comment
			PrepaidTax
			MethodOfTaxationText
			FeeAccount
			TravelExpensesAccount
			ExaminationAccount
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of ValueAddedTaxControlling, PropertyNames, CommonContext)

		Private _rowId As Int64
		Private _valueAddedTaxControllingId As Int64
		Private _name As String = ""
		Private _effortPositionFID As Int64
		Private _fiscalDomicile As String = ""
		Private _studyLocation As String = ""
		Private _typeOfFee As String = ""
		Private _controllable As String = ""
		Private _taxDuty As String = ""
		Private _valueAddedTaxRate As Double?
		Private _methodOfTaxation As String = ""
		Private _comment As String = ""
		Private _prepaidTax As String = ""
		Private _methodOfTaxationText As String = ""
		Private _feeAccount As String = ""
		Private _travelExpensesAccount As String = ""
		Private _examinationAccount As String = ""

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of ValueAddedTaxControlling, PropertyNames, CommonContext)("bcw_allgemein.t_mwst_steuerung")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.ValueAddedTaxControllingId, "id_mwst")
			_modelCore.AddMappingInformation(PropertyNames.Name, "Name")
			_modelCore.AddMappingInformation(PropertyNames.EffortPositionFID, "aufwandposFID")
			_modelCore.AddMappingInformation(PropertyNames.FiscalDomicile, "Steuerwohnsitz")
			_modelCore.AddMappingInformation(PropertyNames.StudyLocation, "Studienort")
			_modelCore.AddMappingInformation(PropertyNames.TypeOfFee, "Honorarart")
			_modelCore.AddMappingInformation(PropertyNames.Controllable, "steuerbar")
			_modelCore.AddMappingInformation(PropertyNames.TaxDuty, "steuerpflichtig")
			_modelCore.AddMappingInformation(PropertyNames.ValueAddedTaxRate, "mwstsatz")
			_modelCore.AddMappingInformation(PropertyNames.MethodOfTaxation, "SteuerVerfahren")
			_modelCore.AddMappingInformation(PropertyNames.Comment, "Bemerkung")
			_modelCore.AddMappingInformation(PropertyNames.PrepaidTax, "Vorsteuer")
			_modelCore.AddMappingInformation(PropertyNames.MethodOfTaxationText, "Steuerverfahrentext")
			_modelCore.AddMappingInformation(PropertyNames.FeeAccount, "Honorarkonto")
			_modelCore.AddMappingInformation(PropertyNames.TravelExpensesAccount, "Fahrtkostenkonto")
			_modelCore.AddMappingInformation(PropertyNames.ExaminationAccount, "Pruefungskonto")

		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Primärschlüssel (ID.)</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of ValueAddedTaxControlling, PropertyNames, CommonContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		'''<summary>Primärschlüssel.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property ValueAddedTaxControllingId As Int64
			Get
				Return _valueAddedTaxControllingId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.ValueAddedTaxControllingId), _valueAddedTaxControllingId, value)
			End Set
		End Property

		'''<summary>Name.</summary>
		Public Property Name As String
			Get
				Return _name
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Name), _name, value)
			End Set
		End Property

		'''<summary>aufwandposFID.</summary>
		Public Property EffortPositionFID As Int64
			Get
				Return _effortPositionFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.EffortPositionFID), _effortPositionFID, value)
			End Set
		End Property

		'''<summary>Steuerwohnsitz.</summary>
		Public Property FiscalDomicile As String
			Get
				Return _fiscalDomicile
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.FiscalDomicile), _fiscalDomicile, value)
			End Set
		End Property

		'''<summary>Studienort.</summary>
		Public Property StudyLocation As String
			Get
				Return _studyLocation
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.StudyLocation), _studyLocation, value)
			End Set
		End Property

		'''<summary>Honorarart.</summary>
		Public Property TypeOfFee As String
			Get
				Return _typeOfFee
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.TypeOfFee), _typeOfFee, value)
			End Set
		End Property

		'''<summary>steuerbar.</summary>
		Public Property Controllable As String
			Get
				Return _controllable
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Controllable), _controllable, value)
			End Set
		End Property

		'''<summary>Steuerpflichtig.</summary>
		Public Property TaxDuty As String
			Get
				Return _taxDuty
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.TaxDuty), _taxDuty, value)
			End Set
		End Property

		'''<summary>mwstsatz.</summary>
		Public Property ValueAddedTaxRate As Double?
			Get
				Return _valueAddedTaxRate
			End Get
			Set(value As Double?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Double?)(NameOf(Me.ValueAddedTaxRate), _valueAddedTaxRate, value)
			End Set
		End Property

		'''<summary>SteuerVerfahren.</summary>
		Public Property MethodOfTaxation As String
			Get
				Return _methodOfTaxation
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.MethodOfTaxation), _methodOfTaxation, value)
			End Set
		End Property

		'''<summary>Bemerkung.</summary>
		Public Property Comment As String
			Get
				Return _comment
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Comment), _comment, value)
			End Set
		End Property

		'''<summary>Vorsteuer.</summary>
		Public Property PrepaidTax As String
			Get
				Return _prepaidTax
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.PrepaidTax), _prepaidTax, value)
			End Set
		End Property

		'''<summary>Steuerverfahrentext.</summary>
		Public Property MethodOfTaxationText As String
			Get
				Return _methodOfTaxationText
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.MethodOfTaxationText), _methodOfTaxationText, value)
			End Set
		End Property

		'''<summary>Honorarkonto.</summary>
		Public Property FeeAccount As String
			Get
				Return _feeAccount
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.FeeAccount), _feeAccount, value)
			End Set
		End Property

		'''<summary>Fahrtkostenkonto.</summary>
		Public Property TravelExpensesAccount As String
			Get
				Return _travelExpensesAccount
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.TravelExpensesAccount), _travelExpensesAccount, value)
			End Set
		End Property

		'''<summary>Pruefungskonto.</summary>
		Public Property ExaminationAccount As String
			Get
				Return _examinationAccount
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.ExaminationAccount), _examinationAccount, value)
			End Set
		End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "

		Public Shared Function GetModelCore() As ModelCore _
		(Of ValueAddedTaxControlling, PropertyNames, CommonContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of ValueAddedTaxControlling, PropertyNames, CommonContext) _
		Implements IModelBase(Of ValueAddedTaxControlling, PropertyNames, CommonContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of ValueAddedTaxControlling) _
		Implements IModelBase(Of ValueAddedTaxControlling, PropertyNames, CommonContext).ModelBase
			Return DirectCast(Me, ModelBase(Of ValueAddedTaxControlling))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace