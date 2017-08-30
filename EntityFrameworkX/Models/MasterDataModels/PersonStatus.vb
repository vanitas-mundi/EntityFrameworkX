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

    Partial Public Class PersonStatus

        Inherits ModelBase(Of PersonStatus)
        Implements IModelBase(Of PersonStatus, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
        Public Enum PropertyNames
            RowId
            PersonenStatusID
            PersonenFID
            Status
            Erfasst
            ErfasstUserFID
            GeaendertAm
            GeaendertUserFID
        End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _modelCore As ModelCore(Of PersonStatus, PropertyNames, MasterDataContext)

        Private _rowId As Int64
        Private _personenStatusID As Int64
        Private _personenFID As Int64
        Private _status As String
        Private _erfasst As DateTime
        Private _erfasstUserFID As Int64
        Private _geaendertAm As DateTime
        Private _geaendertUserFID As Int64
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
            _modelCore = New ModelCore(Of PersonStatus, PropertyNames, MasterDataContext)("datapool.t_personenstati")
            _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
            _modelCore.AddMappingInformation(PropertyNames.PersonenStatusID, "PersonenStatusID")
            _modelCore.AddMappingInformation(PropertyNames.PersonenFID, "PersonenFID")
            _modelCore.AddMappingInformation(PropertyNames.Status, "Status")
            _modelCore.AddMappingInformation(PropertyNames.Erfasst, "Erfasst")
            _modelCore.AddMappingInformation(PropertyNames.ErfasstUserFID, "ErfasstUserFID")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertAm, "GeaendertAm")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertUserFID, "GeaendertUserFID")
        End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property RowId As Int64 Implements IModelBase _
        (Of PersonStatus, PropertyNames, MasterDataContext).RowId
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
        Public Property PersonenStatusID As Int64
            Get
                Return _personenStatusID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.PersonenStatusID), _personenStatusID, value)
            End Set
        End Property

        Public Property PersonenFID As Int64
            Get
                Return _personenFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.PersonenFID), _personenFID, value)
            End Set
        End Property

        Public Property Status As String
            Get
                Return _status
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Status), _status, value)
            End Set
        End Property

        Public Property Erfasst As DateTime
            Get
                Return _erfasst
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.Erfasst), _erfasst, value)
            End Set
        End Property
        Public Property ErfasstUserFID As Int64
            Get
                Return _erfasstUserFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.ErfasstUserFID), _erfasstUserFID, value)
            End Set
        End Property

        Public Property GeaendertAm As DateTime
            Get
                Return _geaendertAm
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.GeaendertAm), _geaendertAm, value)
            End Set
        End Property

        Public Property GeaendertUserFID As Int64
            Get
                Return _geaendertUserFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.GeaendertUserFID), _geaendertUserFID, value)
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
        (Of PersonStatus, PropertyNames, MasterDataContext)
            Return _modelCore
        End Function

        Private Function IModelBase_ModelCore() As ModelCore(Of PersonStatus, PropertyNames, MasterDataContext) _
        Implements IModelBase(Of PersonStatus, PropertyNames, MasterDataContext).ModelCore
            Return _modelCore
        End Function

        Private Function IModelBase_ModelBase() As ModelBase(Of PersonStatus) _
        Implements IModelBase(Of PersonStatus, PropertyNames, MasterDataContext).ModelBase
            Return DirectCast(Me, ModelBase(Of PersonStatus))
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace