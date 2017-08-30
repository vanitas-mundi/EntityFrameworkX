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

    Partial Public Class Company

        Inherits ModelBase(Of Company)
        Implements IModelBase(Of Company, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
        Public Enum PropertyNames
            RowId
            FirmenID
            FirmenAltID
            Firmenname
            Kuerzel
            Ersterfassung
            VIP
            Standort
            Kooperationspartner
            Dublettenpruefung
            FuerInstitut
            FuerStandort
            Prioritaet
            Kommentar
            Key1
            Key2
            Key3
            KoopfuerAdmin
            Zuzahler
            VerwendungFID
            UrsprungFID
            AdressenGruppeFID
            BrancheFID
            GroesseFID
            IstZuzahlerSeit
            QualifiziertDatum
            QualifiziertUserFID
            ErstkontaktDatum
            Aktiv
            IstGeloescht
            Werbung
            Firma1
            Firma2
            Firma3
            Firma4
            Erfasst
            ErfasstUserFID
            GeaendertAm
            GeaendertUserFID
        End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _modelCore As ModelCore(Of Company, PropertyNames, MasterDataContext)

        Private _rowId As Int64
        Private _firmenID As Int64
        Private _firmenAltID As Int64
        Private _firmenname As String
        Private _kuerzel As String
        Private _ersterfassung As Date
        Private _vip As String
        Private _standort As String
        Private _kooperationspartner As String
        Private _dublettenpruefung As String
        Private _fuerInstitut As String
        Private _fuerStandort As String
        Private _prioritaet As String
        Private _kommentar As String
        Private _key1 As String
        Private _key2 As String
        Private _key3 As String
        Private _koopfuerAdmin As String
        Private _zuzahler As String
        Private _verwendungFID As Int64
        Private _ursprungFID As Int64
        Private _adressenGruppenFID As Int64
        Private _brancheFID As Int64
        Private _groesseFID As Int64
        Private _istZuzahlerSeit As DateTime
        Private _qualifiziertDatum As DateTime
        Private _qualifiziertUserFID As Int64
        Private _erstkontaktDatum As DateTime
        Private _aktiv As String
        Private _istGeloescht As DateTime
        Private _werbung As String
        Private _firma1 As String
        Private _firma2 As String
        Private _firma3 As String
        Private _firma4 As String
        Private _erfasst As DateTime
        Private _erfasstUserFID As Int64
        Private _geaendertAm As DateTime
        Private _geaendertUserFID As Int64
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
            _modelCore = New ModelCore(Of Company, PropertyNames, MasterDataContext)("datapool.t_firmen")
            _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
            _modelCore.AddMappingInformation(PropertyNames.FirmenID, "FirmenID")
            _modelCore.AddMappingInformation(PropertyNames.FirmenAltID, "FirmenAltID")
            _modelCore.AddMappingInformation(PropertyNames.Firmenname, "Firmenname")
            _modelCore.AddMappingInformation(PropertyNames.Kuerzel, "Kürzel")
            _modelCore.AddMappingInformation(PropertyNames.Ersterfassung, "Ersterfassung")
            _modelCore.AddMappingInformation(PropertyNames.VIP, "VIP")
            _modelCore.AddMappingInformation(PropertyNames.Standort, "Standort")
            _modelCore.AddMappingInformation(PropertyNames.Kooperationspartner, "Kooperationspartner")
            _modelCore.AddMappingInformation(PropertyNames.Dublettenpruefung, "Dublettenprüfung")
            _modelCore.AddMappingInformation(PropertyNames.FuerInstitut, "FürInstitut")
            _modelCore.AddMappingInformation(PropertyNames.FuerStandort, "FürStandort")
            _modelCore.AddMappingInformation(PropertyNames.Prioritaet, "Priorität")
            _modelCore.AddMappingInformation(PropertyNames.Kommentar, "Kommentar")
            _modelCore.AddMappingInformation(PropertyNames.Key1, "Key1")
            _modelCore.AddMappingInformation(PropertyNames.Key2, "Key2")
            _modelCore.AddMappingInformation(PropertyNames.Key3, "Key3")
            _modelCore.AddMappingInformation(PropertyNames.KoopfuerAdmin, "KoopfuerAdmin")
            _modelCore.AddMappingInformation(PropertyNames.Zuzahler, "Zuzahler")
            _modelCore.AddMappingInformation(PropertyNames.VerwendungFID, "VerwendungFID")
            _modelCore.AddMappingInformation(PropertyNames.UrsprungFID, "UrsprungFID")
            _modelCore.AddMappingInformation(PropertyNames.AdressenGruppeFID, "AdressenGruppeFID")
            _modelCore.AddMappingInformation(PropertyNames.BrancheFID, "BrancheFID")
            _modelCore.AddMappingInformation(PropertyNames.GroesseFID, "GroesseFID")
            _modelCore.AddMappingInformation(PropertyNames.IstZuzahlerSeit, "IstZuzahlerSeit")
            _modelCore.AddMappingInformation(PropertyNames.QualifiziertDatum, "QualifiziertDatum")
            _modelCore.AddMappingInformation(PropertyNames.QualifiziertUserFID, "QualifiziertUserFID")
            _modelCore.AddMappingInformation(PropertyNames.ErstkontaktDatum, "ErstkontaktDatum")
            _modelCore.AddMappingInformation(PropertyNames.Aktiv, "Aktiv")
            _modelCore.AddMappingInformation(PropertyNames.IstGeloescht, "IstGeloescht")
            _modelCore.AddMappingInformation(PropertyNames.Werbung, "Werbung")
            _modelCore.AddMappingInformation(PropertyNames.Firma1, "Firma1")
            _modelCore.AddMappingInformation(PropertyNames.Firma2, "Firma2")
            _modelCore.AddMappingInformation(PropertyNames.Firma3, "Firma3")
            _modelCore.AddMappingInformation(PropertyNames.Firma4, "Firma4")
            _modelCore.AddMappingInformation(PropertyNames.Erfasst, "Erfasst")
            _modelCore.AddMappingInformation(PropertyNames.ErfasstUserFID, "ErfasstUserFID")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertAm, "GeaendertAm")
            _modelCore.AddMappingInformation(PropertyNames.GeaendertUserFID, "GeaendertUserFID")
        End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property RowId As Int64 Implements IModelBase _
        (Of Company, PropertyNames, MasterDataContext).RowId
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
        Public Property FirmenID As Int64
            Get
                Return _firmenID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.FirmenID), _firmenID, value)
            End Set
        End Property

        Public Property FirmenAltID As Int64
            Get
                Return _firmenAltID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.FirmenAltID), _firmenAltID, value)
            End Set
        End Property

        Public Property Firmenname As String
            Get
                Return _firmenname
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Firmenname), _firmenname, value)
            End Set
        End Property

        Public Property Kuerzel As String
            Get
                Return _kuerzel
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Kuerzel), _kuerzel, value)
            End Set
        End Property

        Public Property Ersterfassung As Date
            Get
                Return _ersterfassung
            End Get
            Set(value As Date)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Date)(NameOf(Me.Ersterfassung), _ersterfassung, value)
            End Set
        End Property

        Public Property VIP As String
            Get
                Return _vip
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.VIP), _vip, value)
            End Set
        End Property

        Public Property Standort As String
            Get
                Return _standort
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Standort), _standort, value)
            End Set
        End Property

        Public Property Kooperationspartner As String
            Get
                Return _kooperationspartner
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Kooperationspartner), _kooperationspartner, value)
            End Set
        End Property

        Public Property Dublettenpruefung As String
            Get
                Return _dublettenpruefung
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Dublettenpruefung), _dublettenpruefung, value)
            End Set
        End Property

        Public Property FuerInstitut As String
            Get
                Return _fuerInstitut
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.FuerInstitut), _fuerInstitut, value)
            End Set
        End Property

        Public Property FuerStandort As String
            Get
                Return _fuerStandort
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.FuerStandort), _fuerStandort, value)
            End Set
        End Property

        Public Property Prioritaet As String
            Get
                Return _prioritaet
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Prioritaet), _prioritaet, value)
            End Set
        End Property

        Public Property Kommentar As String
            Get
                Return _kommentar
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Kommentar), _kommentar, value)
            End Set
        End Property

        Public Property Key1 As String
            Get
                Return _key1
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Key1), _key1, value)
            End Set
        End Property

        Public Property Key2 As String
            Get
                Return _key2
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Key2), _key2, value)
            End Set
        End Property

        Public Property Key3 As String
            Get
                Return _key3
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Key3), _key3, value)
            End Set
        End Property

        Public Property KoopfuerAdmin As String
            Get
                Return _koopfuerAdmin
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.KoopfuerAdmin), _koopfuerAdmin, value)
            End Set
        End Property

        Public Property Zuzahler As String
            Get
                Return _zuzahler
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Zuzahler), _zuzahler, value)
            End Set
        End Property

        Public Property VerwendungFID As Int64
            Get
                Return _verwendungFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.VerwendungFID), _verwendungFID, value)
            End Set
        End Property

        Public Property UrsprungFID As Int64
            Get
                Return _ursprungFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.UrsprungFID), _ursprungFID, value)
            End Set
        End Property

        Public Property AdressenGruppeFID As Int64
            Get
                Return _adressenGruppenFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.AdressenGruppeFID), _adressenGruppenFID, value)
            End Set
        End Property

        Public Property BrancheFID As Int64
            Get
                Return _brancheFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.BrancheFID), _brancheFID, value)
            End Set
        End Property

        Public Property GroesseFID As Int64
            Get
                Return _groesseFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.GroesseFID), _groesseFID, value)
            End Set
        End Property

        Public Property IstZuzahlerSeit As DateTime
            Get
                Return _istZuzahlerSeit
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.IstZuzahlerSeit), _istZuzahlerSeit, value)
            End Set
        End Property

        Public Property QualifiziertDatum As DateTime
            Get
                Return _qualifiziertDatum
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.QualifiziertDatum), _qualifiziertDatum, value)
            End Set
        End Property

        Public Property QualifiziertUserFID As Int64
            Get
                Return _qualifiziertUserFID
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.QualifiziertUserFID), _qualifiziertUserFID, value)
            End Set
        End Property

        Public Property ErstkontaktDatum As DateTime
            Get
                Return _erstkontaktDatum
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.ErstkontaktDatum), _erstkontaktDatum, value)
            End Set
        End Property

        Public Property Aktiv As String
            Get
                Return _aktiv
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Aktiv), _aktiv, value)
            End Set
        End Property

        Public Property IstGeloescht As DateTime
            Get
                Return _istGeloescht
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.IstGeloescht), _istGeloescht, value)
            End Set
        End Property

        Public Property Werbung As String
            Get
                Return _werbung
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Werbung), _werbung, value)
            End Set
        End Property

        Public Property Firma1 As String
            Get
                Return _firma1
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Firma1), _firma1, value)
            End Set
        End Property

        Public Property Firma2 As String
            Get
                Return _firma2
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Firma2), _firma2, value)
            End Set
        End Property

        Public Property Firma3 As String
            Get
                Return _firma3
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Firma3), _firma3, value)
            End Set
        End Property

        Public Property Firma4 As String
            Get
                Return _firma4
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Firma4), _firma4, value)
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
        (Of Company, PropertyNames, MasterDataContext)
            Return _modelCore
        End Function

        Private Function IModelBase_ModelCore() As ModelCore(Of Company, PropertyNames, MasterDataContext) _
        Implements IModelBase(Of Company, PropertyNames, MasterDataContext).ModelCore
            Return _modelCore
        End Function

        Private Function IModelBase_ModelBase() As ModelBase(Of Company) _
        Implements IModelBase(Of Company, PropertyNames, MasterDataContext).ModelBase
            Return DirectCast(Me, ModelBase(Of Company))
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace