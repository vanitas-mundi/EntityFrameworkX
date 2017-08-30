Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
#End Region

Namespace Models.Test

	Partial Public Class ValueModel

		Inherits ModelBase(Of ValueModel)
		Implements IModelBase(Of ValueModel, PropertyNames, TestContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			ValueModelId
			NameModelId
			Value
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of ValueModel, PropertyNames, TestContext)

		Private _rowId As Int64
		Private _valueModelId As Int64
		Private _nameModelId As Int64
		Private _value As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of ValueModel, PropertyNames, TestContext)("test.t_values")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.ValueModelId, "ValueId")
			_modelCore.AddMappingInformation(PropertyNames.NameModelId, "NameFId")
			_modelCore.AddMappingInformation(PropertyNames.Value, "Value")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of ValueModel, PropertyNames, TestContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property ValueModelId As Int64
			Get
				Return _valueModelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.ValueModelId), _valueModelId, value)
			End Set
		End Property

		Public Property NameModelId As Int64
			Get
				Return _nameModelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.NameModelId), _nameModelId, value)
			End Set
		End Property

		Public Property Value As String
			Get
				Return _value
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Value), _value, value)
			End Set
		End Property

		'Public Property NameModel As NameModel
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return Me.Value
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of ValueModel, PropertyNames, TestContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of ValueModel, PropertyNames, TestContext) _
		Implements IModelBase(Of ValueModel, PropertyNames, TestContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of ValueModel) _
		Implements IModelBase(Of ValueModel, PropertyNames, TestContext).ModelBase
			Return DirectCast(Me, ModelBase(Of ValueModel))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace

