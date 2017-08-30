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

  Partial Public Class SchulungsTeilnehmer

    Inherits ModelBase(Of SchulungsTeilnehmer)
    Implements IModelBase(Of SchulungsTeilnehmer, PropertyNames, TestContext)

#Region " --------------->> Enumerationen der Klasse "
    Public Enum PropertyNames
      RowId
      '''<summary>Id zum Schulungsteilnehmer</summary>
      SchulungsTeilnehmerId
      '''<summary>Nachname des TN</summary>
      Name
      FirstName
      Birthday
      Comment
    End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private Shared _modelCore As ModelCore(Of SchulungsTeilnehmer, PropertyNames, TestContext)

    Private _rowId As Int64
    Private _schulungsTeilnehmerId As Int64
    Private _name As String
    Private _firstName As String
    Private _birthday As DateTime? 'nullable(of datetime)
    Private _comment As String = ""
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Shared Sub New()
      _modelCore = New ModelCore(Of SchulungsTeilnehmer, PropertyNames, TestContext)("test.t_schulungs_teilnehmer")
      _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
      _modelCore.AddMappingInformation(PropertyNames.SchulungsTeilnehmerId, "Id")
      _modelCore.AddMappingInformation(PropertyNames.Name, "Name")
      _modelCore.AddMappingInformation(PropertyNames.FirstName, "Vorname")
      _modelCore.AddMappingInformation(PropertyNames.Birthday, "Geburtstag")
      _modelCore.AddMappingInformation(PropertyNames.Comment, "Bemerkung")
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property RowId As Int64 Implements IModelBase _
    (Of SchulungsTeilnehmer, PropertyNames, TestContext).RowId
      Get
        Return _rowId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.RowId), _rowId, value)
      End Set
    End Property

    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property SchulungsTeilnehmerId As Int64
      Get
        Return _schulungsTeilnehmerId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.SchulungsTeilnehmerId), _schulungsTeilnehmerId, value)
      End Set
    End Property

    <MaxLength(45)>
    Public Property Name As String
      Get
        Return _name
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.Name), _name, value)
      End Set
    End Property

    <MaxLength(45)>
    Public Property FirstName As String
      Get
        Return _firstName
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.FirstName), _firstName, value)
      End Set
    End Property

    Public Property Birthday As DateTime?
      Get
        Return _birthday
      End Get
      Set(value As DateTime?)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of DateTime?)(NameOf(Me.Birthday), _birthday, value)
      End Set
    End Property

    Public Property Comment As String
      Get
        Return _comment
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.Comment), _comment, value)
      End Set
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
      Return $"{Me.Name}, {Me.FirstName}"
    End Function

    Public Shared Function GetModelCore() As ModelCore _
    (Of SchulungsTeilnehmer, PropertyNames, TestContext)
      Return _modelCore
    End Function

    Private Function IModelBase_ModelCore() As ModelCore(Of SchulungsTeilnehmer, PropertyNames, TestContext) _
    Implements IModelBase(Of SchulungsTeilnehmer, PropertyNames, TestContext).ModelCore
      Return _modelCore
    End Function

    Private Function IModelBase_ModelBase() As ModelBase(Of SchulungsTeilnehmer) _
    Implements IModelBase(Of SchulungsTeilnehmer, PropertyNames, TestContext).ModelBase
      Return DirectCast(Me, ModelBase(Of SchulungsTeilnehmer))
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace