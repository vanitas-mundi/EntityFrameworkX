Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Base.Attributes
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
#End Region

Namespace Models.MasterDataModels

    Partial Public Class Address

        Inherits ModelBase(Of Address)
        Implements IModelBase(Of Address, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
        Public Enum PropertyNames
            RowId
            AddressId
            PersonId
            Recipient
            City
            Postcode
            Street
            HouseNumber
            AddressTypeEnumDatabaseValue
            Bundesland
            FormattedAddress
            Name
            PostanschriftDatabaseValue
            IstGeloescht
			Staat
            'IsMailingAddress
        End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _modelCore As ModelCore(Of Address, PropertyNames, MasterDataContext)

        Private _rowId As Int64
        Private _addressId As Int64
        Private _personId As Int64
        Private _recipient As String
        Private _city As String
        Private _postCode As String
        Private _street As String
        Private _houseNumber As String
        Private _formattedAddress As String
        Private _addressType As String = "Person"
        Private _bundesland As String
        Private _name As String
        Private _postanschriftDatabaseValue As String
        Private _istGeloescht As DateTime?
		Private _staat as string

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
            _modelCore = New ModelCore _
            (Of Address, PropertyNames, MasterDataContext)("datapool.t_anschriften")

            _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
            _modelCore.AddMappingInformation(PropertyNames.AddressId, "AnschriftenID")
            _modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenFID")
            _modelCore.AddMappingInformation(PropertyNames.Recipient, "Empfänger")
            _modelCore.AddMappingInformation(PropertyNames.City, "Stadt")
            _modelCore.AddMappingInformation(PropertyNames.Postcode, "PLZ")
            _modelCore.AddMappingInformation(PropertyNames.Street, "Strasse")
            _modelCore.AddMappingInformation(PropertyNames.HouseNumber, "HausNr")
            _modelCore.AddMappingInformation(PropertyNames.AddressTypeEnumDatabaseValue, "AnschriftenTyp")
            _modelCore.AddMappingInformation(PropertyNames.Bundesland, "Bundesland")
            _modelCore.AddMappingInformation(PropertyNames.FormattedAddress, "FormatierteAnschrift")
            _modelCore.AddMappingInformation(PropertyNames.Name, "Name")
            _modelCore.AddMappingInformation(PropertyNames.PostanschriftDatabaseValue, "Postanschrift")
            _modelCore.AddMappingInformation(PropertyNames.IstGeloescht, "IstGeloescht")
			_modelCore.AddMappingInformation(PropertyNames.Staat, "Staat")
            '_modelCore.AddMappingInformation(PropertyNames.IsMailingAddress, "Postanschrift")
        End Sub

        Public Sub New()
            'Me.IsMailingAddress = YesNoEnum.No
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        '''<summary>Primärschlüssel.</summary>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property RowId As Int64 Implements IModelBase _
        (Of Address, PropertyNames, MasterDataContext).RowId
            Get
                Return _rowId
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.RowId), _rowId, value)
            End Set
        End Property

        '''<summary>Anschriften-Id.)</summary>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property AddressId As Int64
            Get
                Return _addressId
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.AddressId), _addressId, value)
            End Set
        End Property

        '''<summary>Personen-Id.</summary>
        <Required>
        Public Property PersonId As Int64
            Get
                Return _personId
            End Get
            Set(value As Int64)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of Int64)(NameOf(Me.PersonId), _personId, value)
            End Set
        End Property
        Public Property Recipient As String
            Get
                Return _recipient
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Recipient), _recipient, value)
                MyBase.RaisePropertyChanged(NameOf(Me.PostcodeAndCity))
            End Set
        End Property
        '''<summary>Stadt.</summary>
        <Required>
        <MaxLength(80)>
        Public Property City As String
            Get
                Return _city
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.City), _city, value)
                MyBase.RaisePropertyChanged(NameOf(Me.PostcodeAndCity))
            End Set
        End Property

        '''<summary>Postleitzahl.</summary>
        <Required>
        <MaxLength(10)>
        Public Property Postcode As String
            Get
                Return _postCode
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Postcode), _postCode, value)
                MyBase.RaisePropertyChanged(NameOf(Me.PostcodeAndCity))
            End Set
        End Property

        '''<summary>Postleitzahl und Stadt.</summary>
        <NotMapped>
        Public ReadOnly Property PostcodeAndCity As String
            Get
                Return String.Concat(Me.Postcode, " ", Me.City)
            End Get
        End Property

        '''<summary>Straße.</summary>
        <Required>
        <MaxLength(80)>
        Public Property Street As String
            Get
                Return _street
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Street), _street, value)
                MyBase.RaisePropertyChanged(NameOf(Me.StreetAndHouseNumber))
            End Set
        End Property

        '''<summary>Hausnummer.</summary>
        <Required>
        <MaxLength(20)>
        Public Property HouseNumber As String
            Get
                Return _houseNumber
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.HouseNumber), _houseNumber, value)
                MyBase.RaisePropertyChanged(NameOf(Me.StreetAndHouseNumber))
            End Set
        End Property

        '''<summary>Formatierte-Anschrift.</summary>
        Public Property FormattedAddress As String
            Get
                Return _formattedAddress
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.FormattedAddress), _formattedAddress, value)
                MyBase.RaisePropertyChanged(NameOf(Me.FormattedAddress))
            End Set
        End Property

        <Required>
        <MaxLength(80)>
        Public Property Bundesland As String
            Get
                Return _bundesland
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Bundesland), _bundesland, value)
                MyBase.RaisePropertyChanged(NameOf(Me.Bundesland))
            End Set
        End Property

        <Required>
        <MaxLength(100)>
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.Name), _name, value)
                MyBase.RaisePropertyChanged(NameOf(Me.Name))
            End Set
        End Property

        Public Property IstGeloescht As DateTime?
            Get
                Return _istGeloescht
            End Get
            Set(value As DateTime?)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime?)(NameOf(Me.IstGeloescht), _istGeloescht, value)
            End Set
        End Property

        '''<summary>Straße und Hausnummer.</summary>
        <NotMapped>
        Public ReadOnly Property StreetAndHouseNumber As String
            Get
                Return String.Concat(Me.Street, " ", Me.HouseNumber)
            End Get
        End Property

#Region " AddressTypeEnum "
        '''<summary>GenderDatabaseValue - Bitte zum setzen des Geschlechts die AddressTypeEnum-Eigenschaft benutzen!!!</summary>
        <Required>
        <ViewGenerator(IsBrowseable:=False)>
        Public Property AddressTypeEnumDatabaseValue As String
            Get
                Return _addressType
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.AddressTypeEnumDatabaseValue), _addressType, value)
                MyBase.RaisePropertyChanged(NameOf(Me.AddressTypeEnum))
                MyBase.RaisePropertyChanged(NameOf(Me.AddressTypeEnumDisplayValue))
            End Set
        End Property

        '''<summary>AddressTypeEnum.</summary>
        <NotMapped>
        <ViewGenerator(DisplayName:="AddressTypeEnum", ViewType:=ViewTypes.Enum)>
        Public Property AddressTypeEnum As AddressTypeEnum
            Get
                Return AddressTypeEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.AddressTypeEnumDatabaseValue)
            End Get
            Set(value As AddressTypeEnum)
                Me.AddressTypeEnumDatabaseValue = AddressTypeEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
            End Set
        End Property

        '''<summary>AddressTypeEnum-Anzeige-String. für DataBinding benutzen</summary>
        <NotMapped>
        <ViewGenerator(IsBrowseable:=False)>
        Public Property AddressTypeEnumDisplayValue As String
            Get
                Return AddressTypeEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.AddressTypeEnum)
            End Get
            Set(value As String)
                Me.AddressTypeEnum = AddressTypeEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
            End Set
        End Property

#End Region

        <NotMapped()>
        Public Property Postanschrift As YesNoEnum
            Get
                Return YesNoEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.PostanschriftDatabaseValue)
            End Get
            Set(value As YesNoEnum)
                Me.PostanschriftDatabaseValue = YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
            End Set
        End Property
        Public Property PostanschriftDatabaseValue As String
            Get
                Return _postanschriftDatabaseValue
            End Get
            Set(value As String)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of String)(NameOf(Me.PostanschriftDatabaseValue), _postanschriftDatabaseValue, value)
                MyBase.RaisePropertyChanged(NameOf(Me.Postanschrift))
                MyBase.RaisePropertyChanged(NameOf(Me.PostanschriftDisplayValue))
            End Set
        End Property
        <NotMapped()>
        Public Property PostanschriftDisplayValue As String
            Get
                Return YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(Me.Postanschrift)
            End Get
            Set(value As String)
                Me.Postanschrift = YesNoEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
            End Set
        End Property

		Public Property Staat As string
            Get
                Return _staat
            End Get
            Set(value As string)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of string)(NameOf(Me.Staat), _staat, value)
            End Set
        End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
        Public Overrides Function ToString() As String
            Return If(String.IsNullOrEmpty(Me.FormattedAddress) _
            , String.Concat(Me.Street, " ", Me.HouseNumber, vbCrLf, Me.Postcode, " ", Me.City), Me.FormattedAddress)
        End Function

        Public Shared Function GetModelCore() As ModelCore _
        (Of Address, PropertyNames, MasterDataContext)
            Return _modelCore
        End Function

        Private Function ModelCore() As ModelCore(Of Address, PropertyNames, MasterDataContext) _
        Implements IModelBase(Of Address, PropertyNames, MasterDataContext).ModelCore
            Return _modelCore
        End Function

        Private Function ModelBase() As ModelBase(Of Address) _
        Implements IModelBase(Of Address, PropertyNames, MasterDataContext).ModelBase
            Return DirectCast(Me, ModelBase(Of Address))
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing OrElse Not Me.GetType() Is obj.GetType() Then
                Return False
            End If

            Dim s As Address = CType(obj, Address)
            Return Me.AddressId = s.AddressId
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace
