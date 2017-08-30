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

Namespace Models.Test

	Partial Public Class ValidationTestModel

		Inherits ModelBase(Of ValidationTestModel)
		Implements IModelBase(Of ValidationTestModel, PropertyNames, TestContext)

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			ValidationTestModelId
			Name
			NameNull
			Number
			NumberNull
			DateField
			DateFieldNull
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of ValidationTestModel, PropertyNames, TestContext)

		Private _rowId As Int64
		Private _validationTestModelId As Int64
		Private _name As String
		Private _nameNull As String
		Private _number As Int64
		Private _numberNull As Int64?
		Private _dateField As DateTime
		Private _dateFieldNull As DateTime?
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of ValidationTestModel, PropertyNames, TestContext)("test.t_validation_tests")

			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.ValidationTestModelId, "id")
			_modelCore.AddMappingInformation(PropertyNames.Name, "name")
			_modelCore.AddMappingInformation(PropertyNames.NameNull, "namenull")
			_modelCore.AddMappingInformation(PropertyNames.Number, "number")
			_modelCore.AddMappingInformation(PropertyNames.NumberNull, "numbernull")
			_modelCore.AddMappingInformation(PropertyNames.DateField, "datefield")
			_modelCore.AddMappingInformation(PropertyNames.DateFieldNull, "datefieldnull")
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of ValidationTestModel, PropertyNames, TestContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

		<DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		Public Property ValidationTestModelId As Int64
			Get
				Return _validationTestModelId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.ValidationTestModelId), _validationTestModelId, value)
			End Set
		End Property

        '<IsLocalizeable>
        <MaxLength(20)>
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Name), _name, value)
            End Set
        End Property

        '<IsLocalizeable>
        <Required>
        Public Property NameNull As String
            Get
                Return _nameNull
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.NameNull), _nameNull, value)
            End Set
        End Property

        Public Property Number As Int64
			Get
				Return _number
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.Number), _number, value)
			End Set
		End Property

		Public Property NumberNull As Int64?
			Get
				Return _numberNull
			End Get
			Set(value As Int64?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64?)(NameOf(Me.NumberNull), _numberNull, value)
			End Set
		End Property

		'<BCW.Foundation.Data.EntityFrameworkHandling.Validators.Core.DataAnnotations.InvokeValidationErrorAttribute>
		Public Property DateField As DateTime
			Get
				Return _dateField
			End Get
			Set(value As DateTime)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime)(NameOf(Me.DateField), _dateField, value)
			End Set
		End Property

		Public Property DateFieldNull As DateTime?
			Get
				Return _dateFieldNull
			End Get
			Set(value As DateTime?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime?)(NameOf(Me.DateFieldNull), _dateFieldNull, value)
			End Set
		End Property
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
		(Of ValidationTestModel, PropertyNames, TestContext)
			Return _modelCore
		End Function

		Private Function IModelBase_ModelCore() As ModelCore(Of ValidationTestModel, PropertyNames, TestContext) _
		Implements IModelBase(Of ValidationTestModel, PropertyNames, TestContext).ModelCore
			Return _modelCore
		End Function

		Private Function IModelBase_ModelBase() As ModelBase(Of ValidationTestModel) _
		Implements IModelBase(Of ValidationTestModel, PropertyNames, TestContext).ModelBase
			Return DirectCast(Me, ModelBase(Of ValidationTestModel))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
