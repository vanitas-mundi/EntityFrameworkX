Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces

#End Region

Namespace Models.Common

	''' <summary>
	''' Database: bcw_allgemein
	''' Table: t_kbg
	''' </summary>
	Partial Public Class CashCarrierBookingGroup

		Inherits ModelBase(Of CashCarrierBookingGroup)
		Implements IModelBase(Of CashCarrierBookingGroup, PropertyNames, CommonContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			CashCarrierBookingGroupId
			GroupNumber
			GroupName
			CourseGroup
			Franchising
			Institute
			Selectable
			ValueAddedTax
			Project
			HonorariumPayOff
			JobAttendant
			Mba
			BillingFullTime
			Changed
			Comment
			SpecialLawOfTaxation
			Assignment
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore _
		(Of CashCarrierBookingGroup, PropertyNames, CommonContext)

		Private _rowId As Int64
		Private _cashCarrierBookingGroupId As Int64
		Private _groupNumber As Int64
		Private _groupName As String = ""
		Private _courseGroup As String = ""
		Private _franchising As String = ""
		Private _institute As String = ""
		Private _selectable As String = "Y"
		Private _valueAddedTax As Double = 0.00
		'Private _project As String = "N"
		Private _honorariumPayOffIn As String = ""
		Private _jobAttendant As String = "J"
		Private _mba As String = "N"
		Private _billingFullTime As String = "N"
		Private _manipulation As DateTime
		Private _comment As String = ""
		Private _specialLawOfTaxation As String = "N"
		Private _assignment As String = "2"

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of CashCarrierBookingGroup, PropertyNames, CommonContext)("bcw_allgemein.t_kbg")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.CashCarrierBookingGroupId, "ID")
			_modelCore.AddMappingInformation(PropertyNames.GroupNumber, "Gruppennr")
			_modelCore.AddMappingInformation(PropertyNames.GroupName, "Gruppenname")
			_modelCore.AddMappingInformation(PropertyNames.CourseGroup, "Lehrgangsgruppe")
			_modelCore.AddMappingInformation(PropertyNames.Franchising, "Franchising")
			_modelCore.AddMappingInformation(PropertyNames.Institute, "Institut")
			_modelCore.AddMappingInformation(PropertyNames.Selectable, "Wählbar")
			_modelCore.AddMappingInformation(PropertyNames.ValueAddedTax, "MwstSatz")
			_modelCore.AddMappingInformation(PropertyNames.Project, "Projekt")
			_modelCore.AddMappingInformation(PropertyNames.HonorariumPayOff, "HonorarAbrechnungIn")
			_modelCore.AddMappingInformation(PropertyNames.JobAttendant, "berufsbegleitend")
			_modelCore.AddMappingInformation(PropertyNames.Mba, "MBA")
			_modelCore.AddMappingInformation(PropertyNames.BillingFullTime, "AbrechnenHB")
			_modelCore.AddMappingInformation(PropertyNames.Changed, "Geändert")
			_modelCore.AddMappingInformation(PropertyNames.Comment, "Bemerkung")
			_modelCore.AddMappingInformation(PropertyNames.SpecialLawOfTaxation, "spezSteuerrecht")
			_modelCore.AddMappingInformation(PropertyNames.Assignment, "Zuweisung")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Primärschlüssel (ID.)</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of CashCarrierBookingGroup, PropertyNames, CommonContext).RowId
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
		Public Property CashCarrierBookingGroupId As Int64
			Get
				Return _cashCarrierBookingGroupId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.CashCarrierBookingGroupId), _cashCarrierBookingGroupId, value)
			End Set
		End Property

		'''<summary>Gruppennr.</summary>
		Public Property GroupNumber As Int64
			Get
				Return _groupNumber
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.GroupNumber), _groupNumber, value)
			End Set
		End Property

		'''<summary>Gruppenname.</summary>
		Public Property GroupName As String
			Get
				Return _groupName
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.GroupName), _groupName, value)
			End Set
		End Property

		'''<summary>Lehrgangsgruppe.</summary>
		<Range(0, 50)>
		Public Property CourseGroup As String
			Get
				Return _courseGroup
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.CourseGroup), _courseGroup, value)
			End Set
		End Property

		'''<summary>Franchising.</summary>
		<Range(0, 50)>
		Public Property Franchising As String
			Get
				Return _franchising
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Franchising), _franchising, value)
			End Set
		End Property

		'''<summary>Institut.</summary>
		<Range(0, 100)>
		Public Property Institut As String
			Get
				Return _institute
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Institut), _institute, value)
			End Set
		End Property

		''''<summary>Wählbar.</summary>
		'<Range(0, 100)>
		'Public Property Selectable As Enum
		'	Get
		'		Return _selectable
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.Selectable), _selectable, value)
		'	End Set
		'End Property

		'''<summary>MwstSatz.</summary>
		Public Property ValueAddedTax As Double
			Get
				Return _valueAddedTax
			End Get
			Set(value As Double)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Double)(NameOf(Me.ValueAddedTax), _valueAddedTax, value)
			End Set
		End Property

		''''<summary>Projekt.</summary>
		'Public Property Project As Enum
		'	Get
		'		Return _project
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.Project), _project, value)
		'	End Set
		'End Property

		'''<summary>HonorarAbrechnungIn.</summary>
		Public Property HonorariumPayOffIn As String
			Get
				Return _honorariumPayOffIn
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.HonorariumPayOffIn), _honorariumPayOffIn, value)
			End Set
		End Property

		''''<summary>berufsbegleitend.</summary>
		'Public Property JobAttendant As Enum
		'	Get
		'		Return _jobAttendant
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.JobAttendant), _jobAttendant, value)
		'	End Set
		'End Property

		''''<summary>MBA.</summary>
		'Public Property Mba As Enum
		'	Get
		'		Return _mba
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.Mba), _mba, value)
		'	End Set
		'End Property

		''''<summary>AbrechnenHB.</summary>
		'Public Property BillingFullTime As Enum
		'	Get
		'		Return _billingFullTime
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.BillingFullTime), _billingFullTime, value)
		'	End Set
		'End Property

		'''<summary>Geändert.</summary>
		Public Property Manipulation As DateTime
			Get
				Return _manipulation
			End Get
			Set(value As DateTime)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime)(NameOf(Me.Manipulation), _manipulation, value)
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

		'''<summary>spezSteuerrecht.</summary>
		<Range(0, 10)>
		Public Property SpecialLawOfTaxation As String
			Get
				Return _specialLawOfTaxation
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.SpecialLawOfTaxation), _specialLawOfTaxation, value)
			End Set
		End Property

		''''<summary>Zuweisung.</summary>
		'Public Property Assignment As Enum
		'	Get
		'		Return _assignment
		'	End Get
		'	Set(value As Enum)
		'		MyBase.SetPropertyValueAndRaisePropertyChanged _
		'		(Of Enum)(NameOf(Me.Assignment), _assignment, value)
		'	End Set
		'End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String

			Throw New NotImplementedException()
			'	Return String.Concat _
			'	("PersonId:", Me.PersonId.ToString _
			'	, "|AcademicTitleId:", Me.AcademicTitleId.ToString _
			'	, "|Priority:", Me.Priority)
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of CashCarrierBookingGroup, PropertyNames, CommonContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of CashCarrierBookingGroup, PropertyNames, CommonContext) _
		Implements IModelBase(Of CashCarrierBookingGroup, PropertyNames, CommonContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of CashCarrierBookingGroup) _
		Implements IModelBase(Of CashCarrierBookingGroup, PropertyNames, CommonContext).ModelBase
			Return DirectCast(Me, ModelBase(Of CashCarrierBookingGroup))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace