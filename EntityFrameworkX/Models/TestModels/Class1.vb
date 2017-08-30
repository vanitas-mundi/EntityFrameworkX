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

  Partial Public Class IdCard

    Inherits ModelBase(Of IdCard)
    Implements IModelBase(Of IdCard, PropertyNames, TestContext)

#Region " --------------->> Enumerationen der Klasse "
    Public Enum PropertyNames
      RowId
      Id
      Name
      'Beispiel für weitere Eigenschaften
      'Property1
    End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private Shared _modelCore As ModelCore(Of IdCard, PropertyNames, TestContext)

    Private _rowId As Int64
    Private _Id As Int64
    Private _name As String
    'Beispiel für weitere Eigenschaften
    'Private _property1 As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Shared Sub New()
      _modelCore = New ModelCore(Of IdCard, PropertyNames, TestContext)("db.table")
      _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
      _modelCore.AddMappingInformation(PropertyNames.Id, "PrimaryKeyFieldName")
      _modelCore.AddMappingInformation(PropertyNames.Name, "Nachname")
      'Beispiel für weitere Eigenschaften
      '_modelCore.AddMappingInformation(PropertyNames.Property1, "FieldName")
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property RowId As Int64 Implements IModelBase _
    (Of IdCard, PropertyNames, TestContext).RowId
      Get
        Return _rowId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.RowId), _rowId, value)
      End Set
    End Property

    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property Id As Int64
      Get
        Return _Id
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.Id), _Id, value)
      End Set
    End Property

    'Beispiel für weitere Eigenschaften
    '<MaxLength>
    'Public Property Property1 As String
    '	Get
    '		Return _property1
    '	End Get
    '	Set(value As String)
    '		MyBase.SetPropertyValueAndRaisePropertyChanged _
    '		(Of String)(NameOf(Me.Property1), _property1, value)
    '	End Set
    'End Property

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
    (Of IdCard, PropertyNames, TestContext)
      Return _modelCore
    End Function

    Private Function IModelBase_ModelCore() As ModelCore(Of IdCard, PropertyNames, TestContext) _
    Implements IModelBase(Of IdCard, PropertyNames, TestContext).ModelCore
      Return _modelCore
    End Function

    Private Function IModelBase_ModelBase() As ModelBase(Of IdCard) _
    Implements IModelBase(Of IdCard, PropertyNames, TestContext).ModelBase
      Return DirectCast(Me, ModelBase(Of IdCard))
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace

Public Class Class1

End Class
