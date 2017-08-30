Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces

#End Region

Namespace Models.GitModels

	Partial Public Class KachelSchlagwort

		Inherits ModelBase(Of KachelSchlagwort)
		Implements IModelBase(Of KachelSchlagwort, PropertyNames, GitContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			KachelSchlagworteId
			KachelFID
			SchlagwortFID
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of KachelSchlagwort, PropertyNames, GitContext)

		Private _rowId as Int64
		Private _kachelSchlagwortId AS Int64
		Private _kachelFID As Int64
		Private _schlagwortFID As Int64
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore(Of KachelSchlagwort, PropertyNames, GitContext)("git.t_mn_kachel_schlagworte")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.KachelSchlagworteId, "KachelSchlagwortId")
			_modelCore.AddMappingInformation(PropertyNames.KachelFID, "KachelFID")
			_modelCore.AddMappingInformation(PropertyNames.SchlagwortFID, "SchlagwortFID")
		End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of KachelSchlagwort, PropertyNames, GitContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property KachelSchlagwortId As Int64
			Get
				Return _kachelSchlagwortId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.KachelSchlagwortId), _kachelSchlagwortId, value)
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

		Public Property SchlagwortFID As Int64
			Get
				Return _schlagwortFID
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.SchlagwortFID), _schlagwortFID, value)
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
		(Of KachelSchlagwort, PropertyNames, GitContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of KachelSchlagwort, PropertyNames, GitContext) _
		Implements IModelBase(Of KachelSchlagwort, PropertyNames, GitContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of KachelSchlagwort) _
		Implements IModelBase(Of KachelSchlagwort, PropertyNames, GitContext).ModelBase
			Return DirectCast(Me, ModelBase(Of KachelSchlagwort))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace