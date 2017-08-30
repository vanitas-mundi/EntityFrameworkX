Option Explicit On
Option Infer On
Option Strict On

Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Common
Imports SSP.Data.EntityFrameworkX.Repositories.Core

#Region " --------------->> Imports/ usings "

#End Region

Namespace Repositories.Common
	Partial Public Class CommonRepository

#Region " --------------->> Enumerationen der Klasse "

#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "

		Private Shared _instance As CommonRepository

		Private _valueAddedTaxControllingsRepository _
		As New RepositoryBase(Of ValueAddedTaxControlling _
		, ValueAddedTaxControlling.PropertyNames, CommonContext)

		Private _idCardBillsRepository _
		As New RepositoryBase(Of IdCardBill _
		, IdCardBill.PropertyNames, CommonContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "

		Private Sub New()
		End Sub

		Shared Sub New()
			_instance = New CommonRepository
		End Sub

#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "

		Public Shared ReadOnly Property Instance As CommonRepository
			Get
				Return _instance
			End Get
		End Property

		Public ReadOnly Property ValueAddedTaxControllingsRepository As _
		RepositoryBase(Of ValueAddedTaxControlling, ValueAddedTaxControlling.PropertyNames, CommonContext)
			Get
				Return _valueAddedTaxControllingsRepository
			End Get
		End Property

		'''<summary>RechnungenIdCards</summary>
		Public ReadOnly Property IdCardBillsRepository As _
		RepositoryBase(Of IdCardBill, IdCardBill.PropertyNames, CommonContext)
			Get
				Return _idCardBillsRepository
			End Get
		End Property

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "

#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "

#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "

#End Region '{Öffentliche Methoden der Klasse}
	End Class
End Namespace
