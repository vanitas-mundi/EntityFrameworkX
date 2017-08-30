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

Namespace Models.MasterDataModels

	Partial Public Class PersonAcademicTitle

		Inherits ModelBase(Of PersonAcademicTitle)
		Implements IModelBase(Of PersonAcademicTitle, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			PersonAcademicTitleId
			PersonId
			AcademicTitleId
			Priority
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of PersonAcademicTitle, PropertyNames, MasterDataContext)

		Private _rowId As Int64
		Private _personAcademicTitleId As Int64
		Private _personId As Int64
		Private _academicTitleId As Int64
		Private _priority As Int64 = 0
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of PersonAcademicTitle, PropertyNames, MasterDataContext)("datapool.t_mn_personen_titel")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.PersonAcademicTitleId, "ID")
			_modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenFID")
			_modelCore.AddMappingInformation(PropertyNames.AcademicTitleId, "TitelFID")
			_modelCore.AddMappingInformation(PropertyNames.Priority, "Prioritaet")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		'''<summary>Primärschlüssel (Personen-Id.)</summary>
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of PersonAcademicTitle, PropertyNames, MasterDataContext).RowId
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
		Public Property PersonAcademicTitleId As Int64
			Get
				Return _personAcademicTitleId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.PersonAcademicTitleId), _personAcademicTitleId, value)
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

		'''<summary>Titel-Id.</summary>
		<Required>
		Public Property AcademicTitleId As Int64
			Get
				Return _academicTitleId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.AcademicTitleId), _academicTitleId, value)
			End Set
		End Property

		'''<summary>Priorität.</summary>
		<Required>
		<Range(0, 8)>
		Public Property Priority As Int64
			Get
				Return _priority
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.Priority), _priority, value)
			End Set
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			'Dim priority = If(Me.Priority.HasValue, String.Concat("|Priority:", Me.Priority), "")
			Return String.Concat _
			("PersonId:", Me.PersonId.ToString _
			, "|AcademicTitleId:", Me.AcademicTitleId.ToString _
			, "|Priority:", Me.Priority)
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of PersonAcademicTitle, PropertyNames, MasterDataContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of PersonAcademicTitle, PropertyNames, MasterDataContext) _
		Implements IModelBase(Of PersonAcademicTitle, PropertyNames, MasterDataContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of PersonAcademicTitle) _
		Implements IModelBase(Of PersonAcademicTitle, PropertyNames, MasterDataContext).ModelBase
			Return DirectCast(Me, ModelBase(Of PersonAcademicTitle))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace