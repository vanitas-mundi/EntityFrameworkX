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

	Partial Public Class NameModel

		Inherits ModelBase(Of NameModel)
		Implements IModelBase(Of NameModel, PropertyNames, TestContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			NameModelId
			Name
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of NameModel, PropertyNames, TestContext)

		Private _rowId As Int64
		Private _nameModelId As Int64
		Private _name As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of NameModel, PropertyNames, TestContext)("test.t_names")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.NameModelId, "NameId")
			_modelCore.AddMappingInformation(PropertyNames.Name, "Name")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of NameModel, PropertyNames, TestContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property NameModelId As Int64
			Get
				Return _nameModelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.NameModelId), _nameModelId, value)
			End Set
		End Property

		Public Property Name As String
			Get
				Return _name
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Name), _name, value)
			End Set
		End Property

		<ForeignKey("NameModelId")>
		Public Property ValueCollection As List(Of ValueModel)
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Overrides Function ToString() As String
			Return Me.Name
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of NameModel, PropertyNames, TestContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of NameModel, PropertyNames, TestContext) _
		Implements IModelBase(Of NameModel, PropertyNames, TestContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of NameModel) _
		Implements IModelBase(Of NameModel, PropertyNames, TestContext).ModelBase
			Return DirectCast(Me, ModelBase(Of NameModel))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace



