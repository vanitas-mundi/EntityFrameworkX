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

Namespace Models.Common

	''' <summary>
	''' Database: datapool
	''' Table: t_rechnungen
	''' </summary>
	Partial Public Class IdCardBill

		Inherits ModelBase(Of IdCardBill)
		Implements IModelBase(Of IdCardBill, PropertyNames, CommonContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			'''<summary>Rechnungs-Id.</summary>
			IdCardBillId
			'''<summary>Personen-Id.</summary>
			PersonId
			'''<summary>Debitorennummer</summary>
			DebtorNumber
			'''<summary>Rechnungsnummer</summary>
			BillNumber
			'''<summary>Rechnungsdatum</summary>
			BillDate
			'''<summary>Formatierte Anschrift</summary>
			FormattedAddress
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore _
		(Of IdCardBill, PropertyNames, CommonContext)

		Private _rowId As Int64
		Private _idCardBillId As Int64
		Private _personId As Int64?
		Private _debtorNumber As Int64
		Private _billNumber As Int64
		Private _billDate As DateTime
		Private _formattedAddress As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of IdCardBill, PropertyNames, CommonContext)("datenpool.t_rechnungen_idcard")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.IdCardBillId, "Id")
			_modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenFID")
			_modelCore.AddMappingInformation(PropertyNames.DebtorNumber, "DebitorenNummer")
			_modelCore.AddMappingInformation(PropertyNames.BillNumber, "RechnungsNummer")
			_modelCore.AddMappingInformation(PropertyNames.BillDate, "RechnungsDatum")
			_modelCore.AddMappingInformation(PropertyNames.FormattedAddress, "FormatierteAnschrift")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Primärschlüssel (ID.)</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of IdCardBill, PropertyNames, CommonContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		'''<summary>Primärschlüssel. - Rechnungs-Id.</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property IdCardBillId As Int64
			Get
				Return _idCardBillId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.IdCardBillId), _idCardBillId, value)
			End Set
		End Property

		'''<summary>Personen-Id.</summary>
		<Required>
		Public Property PersonId As Int64?
			Get
				Return _personId
			End Get
			Set(value As Int64?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64?)(NameOf(Me.PersonId), _personId, value)
			End Set
		End Property

		'''<summary>Debitorennummer</summary>
		<Required>
		Public Property DebtorNumber As Int64
			Get
				Return _debtorNumber
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.DebtorNumber), _debtorNumber, value)
			End Set
		End Property

		'''<summary>Rechnungsnummer</summary>
		<Required>
		Public Property BillNumber As Int64
			Get
				Return _billNumber
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.BillNumber), _billNumber, value)
			End Set
		End Property

		'''<summary>Rechnungsdatum</summary>
		<Required>
		Public Property BillDate As DateTime
			Get
				Return _billDate
			End Get
			Set(value As DateTime)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime)(NameOf(Me.BillDate), _billDate, value)
			End Set
		End Property

		'''<summary>Formatierte Anschrift</summary>
		<Required>
		Public Property FormattedAddress As String
			Get
				Return _formattedAddress
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.FormattedAddress), _formattedAddress, value)
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return String.Format("{0} vom {1}", Me.BillNumber, Me.BillDate.ToString("yyyy-MM-dd"))
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of IdCardBill, PropertyNames, CommonContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of IdCardBill, PropertyNames, CommonContext) _
		Implements IModelBase(Of IdCardBill, PropertyNames, CommonContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of IdCardBill) _
		Implements IModelBase(Of IdCardBill, PropertyNames, CommonContext).ModelBase
			Return DirectCast(Me, ModelBase(Of IdCardBill))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace