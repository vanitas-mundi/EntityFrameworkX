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

	Partial Public Class Schlagwort

		Inherits ModelBase(Of Schlagwort)
		Implements IModelBase(Of Schlagwort, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			SchlagwortId
			Schlagwort
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of Schlagwort, PropertyNames, GitContext)

		Private _rowId as Int64
		Private _schlagwortId AS Int64
		Private _schlagwort As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore(Of Schlagwort, PropertyNames, GitContext)("db.table")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.SchlagwortId, "SchlagwortId")
			_modelCore.AddMappingInformation(PropertyNames.Schlagwort, "Schlagwort")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of Schlagwort, PropertyNames, GitContext).RowId
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
		Public Property SchlagwortID As Int64
			Get
				Return _schlagwortId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.SchlagwortID), _schlagwortId, value)
			End Set
		End Property
		Public Property Schlagwort As String
			Get
				Return _schlagwort
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Schlagwort), _schlagwort, value)
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
		(Of Schlagwort, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of Schlagwort, PropertyNames, GitContext) _
		Implements IModelBase(Of Schlagwort, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of Schlagwort) _
		Implements IModelBase(Of Schlagwort, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of Schlagwort))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace