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

    Partial Public Class PersonEducation

        Inherits ModelBase(Of PersonEducation)
        Implements IModelBase(Of PersonEducation, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
        Public Enum PropertyNames
            RowId
            PersonenBildungID
            PersonenFID
            SchulbildungFID
            SchulbildungLandFID
            HoechsterAbschlussFID
            HoechsterAbschlussLandFID
            Ausbildung
            AusbildungLandFID
            Erfasst
            ErfasstUserFID
            GeaendertAm
            GeaendertUserFID
        End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _modelCore As ModelCore(Of PersonEducation, PropertyNames, MasterDataContext)

        Private _rowId As Int64
        Private _personenBildungID As Int64
        Private _personenFID As Int64
        Private _schulbildungFID As Int64
        Private _schulbildungLandFID As Int64
        Private _hoechsterAbschlussFID As Int64
        Private _hoechsterAbschlussLandFID As Int64
        Private _ausbildung As String
        Private _ausbildungLandFID As Int64
        Private _erfasst As DateTime
        Private _erfasstUserFID As Int64
        Private _geaendertAm As DateTime
        Private _geaendertUserFID As Int64
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
            _modelCore = New ModelCore(Of PersonEducation, PropertyNames, MasterDataContext)("datapool.t_personen_bildung")
            _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
            _modelCore.AddMappingInformation(PropertyNames.PersonenBildungID, "PersonenBildungID")
            _modelCore.AddMappingInformation(PropertyNames.PersonenFID, "PersonenFID")
            _modelCore.AddMappingInformation(PropertyNames.SchulbildungFID, "SchulbildungFID")
            _modelCore.AddMappingInformation(PropertyNames.SchulbildungLandFID, "SchulbildungLandFID")
            _modelCore.AddMappingInformation(PropertyNames.HoechsterAbschlussFID, "HoechsterAbschlussFID")
            _modelCore.AddMappingInformation(PropertyNames.HoechsterAbschlussLandFID, "HoechsterAbschlussLandFID")
            _modelCore.AddMappingInformation(PropertyNames.Ausbildung, "Ausbildung")
            _modelCore.AddMappingInformation(PropertyNames.AusbildungLandFID, "AusbildungLandFID")
            _modelCore.AddMappingInformation(PropertyNames.Erfasst, "Erfasst")
            _modelCore.AddMappingInformation(PropertyNames.ErfasstUserFID, "ErfasstUserFID")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertAm, "GeaendertAm")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertUserFID, "GeaendertUserFID")
        End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property RowId As Int64 Implements IModelBase _
        (Of PersonEducation, PropertyNames, MasterDataContext).RowId
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
        Public Property PersonenBildungID As Int64
            Get
                Return _personenBildungID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.PersonenBildungID), _personenBildungID, value)
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

        Public Property SchulbildungFID As Int64
            Get
                Return _schulbildungFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.SchulbildungFID), _schulbildungFID, value)
            End Set
        End Property

        Public Property SchulbildungLandFID As Int64
            Get
                Return _schulbildungLandFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.SchulbildungLandFID), _schulbildungLandFID, value)
            End Set
        End Property

        Public Property HoechsterAbschlussFID As Int64
            Get
                Return _hoechsterAbschlussFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.HoechsterAbschlussFID), _hoechsterAbschlussFID, value)
            End Set
        End Property

        Public Property HoechsterAbschlussLandFID As Int64
            Get
                Return _hoechsterAbschlussLandFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.HoechsterAbschlussLandFID), _hoechsterAbschlussLandFID, value)
            End Set
        End Property

        Public Property Ausbildung As String
            Get
                Return _ausbildung
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Ausbildung), _ausbildung, value)
            End Set
        End Property

        Public Property AusbildungLandFID As Int64
            Get
                Return _ausbildungLandFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.AusbildungLandFID), _ausbildungLandFID, value)
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
        (Of PersonEducation, PropertyNames, MasterDataContext)
            Return _modelCore
        End Function

        Private Function IModelBase_ModelCore() As ModelCore(Of PersonEducation, PropertyNames, MasterDataContext) _
        Implements IModelBase(Of PersonEducation, PropertyNames, MasterDataContext).ModelCore
            Return _modelCore
        End Function

        Private Function IModelBase_ModelBase() As ModelBase(Of PersonEducation) _
        Implements IModelBase(Of PersonEducation, PropertyNames, MasterDataContext).ModelBase
            Return DirectCast(Me, ModelBase(Of PersonEducation))
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace