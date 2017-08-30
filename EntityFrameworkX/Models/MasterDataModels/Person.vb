Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Enums
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
Imports SSP.Base.Attributes
#End Region

Namespace Models.MasterDataModels

	Partial Public Class Person

		Inherits ModelBase(Of Person)
		Implements IModelBase(Of Person, PropertyNames, MasterDataContext)
		Implements IModifiedUpdater

#Region " --------------->> Enumerationen der Klasse "
		Public Enum PropertyNames
			RowId
			PersonId
			LastName
			FirstName
			GenderDatabaseValue
			DateOfBirth
			Nationality
			CountryOfBirthId
			CountryOfBirth
			PlaceOfBirth
			BirthName
			ShortName

			FormOfAddress
			TitleGerman
			TitleInternational
			TitleTraining
			TitleJob

			LoginName
			AccountDisabledDatabaseValue
			AccountExpireDate
			PersonCultureCode

			CreationUserId
			CreationDate
			ManipulationUserId
			ManipulationDate
			Comment

			Password
			PasswordWLAN
			LastModifiedPasswordDate

			WeitereStaatsangehoerigkeit
            Office365MailAddress
		End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _modelCore As ModelCore(Of Person, PropertyNames, MasterDataContext)

		Private _lastname As String
		Private _firstname As String
		Private _personId As Int64
		Private _rowId As Int64
		Private _dateOfBirth As DateTime?
		Private _nationality As String = ""
		Private _countryOfBirthId As Int64 = 0
		Private _countryOfBirth As String = ""
		Private _placeOfBirth As String = ""
		Private _birthName As String = ""
		Private _shortName As String = ""
		Private _formOfAddress As String = ""
		Private _titelGerman As String = ""
		Private _titelInternational As String = ""
		Private _titelTraining As String = ""
		Private _titelJob As String = ""
		Private _loginName As String = ""
		Private _accountExpireDate As DateTime?
		Private _personCultureCode As String = "de-DE"
		Private _creationUserId As Int64
		Private _creationDate As DateTime
		Private _manipulationUserId As Int64
		Private _manipulationDate As DateTime?
		Private _comment As String = ""
		Private _accountDisabledDatabaseValue As String
		Private _genderDatabaseValue As String
		Private _weitereStaatsangehoerigkeit as string
        Private _office365MailAddress As String
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Shared Sub New()
			_modelCore = New ModelCore _
			(Of Person, PropertyNames, MasterDataContext)("datapool.t_personen")
			_modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
			_modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenID")
			_modelCore.AddMappingInformation(PropertyNames.LastName, "Nachname")
			_modelCore.AddMappingInformation(PropertyNames.FirstName, "Vorname")
			_modelCore.AddMappingInformation(PropertyNames.GenderDatabaseValue, "Geschlecht")
			_modelCore.AddMappingInformation(PropertyNames.DateOfBirth, "Geburtsdatum")
			_modelCore.AddMappingInformation(PropertyNames.Nationality, "Staatsangehörigkeit")
			_modelCore.AddMappingInformation(PropertyNames.CountryOfBirthId, "GeburtslandIntFID")
			_modelCore.AddMappingInformation(PropertyNames.CountryOfBirth, "Geburtsland")
			_modelCore.AddMappingInformation(PropertyNames.PlaceOfBirth, "Geburtsort")
			_modelCore.AddMappingInformation(PropertyNames.BirthName, "Geburtsname")
			_modelCore.AddMappingInformation(PropertyNames.ShortName, "Kürzel")
			_modelCore.AddMappingInformation(PropertyNames.FormOfAddress, "Anrede")
			_modelCore.AddMappingInformation(PropertyNames.TitleGerman, "Titel_de")
			_modelCore.AddMappingInformation(PropertyNames.TitleInternational, "Titel_int")
			_modelCore.AddMappingInformation(PropertyNames.TitleTraining, "Titel_abf")
			_modelCore.AddMappingInformation(PropertyNames.TitleJob, "Berufstitel")

			_modelCore.AddMappingInformation(PropertyNames.LoginName, "LoginName")
			_modelCore.AddMappingInformation(PropertyNames.AccountDisabledDatabaseValue, "Deaktiviert")
			_modelCore.AddMappingInformation(PropertyNames.AccountExpireDate, "Ausgeschieden")
			_modelCore.AddMappingInformation(PropertyNames.PersonCultureCode, "CultureCode")

			_modelCore.AddMappingInformation(PropertyNames.CreationUserId, "ErfasstUserFID")
			_modelCore.AddMappingInformation(PropertyNames.CreationDate, "Erfasst")

			_modelCore.AddMappingInformation(PropertyNames.ManipulationUserId, "GeaendertUserFID")
			_modelCore.AddMappingInformation(PropertyNames.ManipulationDate, "GeaendertAm")
			_modelCore.AddMappingInformation(PropertyNames.Comment, "Bemerkung")

			_modelCore.AddMappingInformation(PropertyNames.Password, "Passwort")
			_modelCore.AddMappingInformation(PropertyNames.PasswordWLAN, "pw_nthash")
			_modelCore.AddMappingInformation(PropertyNames.LastModifiedPasswordDate, "pw_datum")
			_modelCore.AddMappingInformation(PropertyNames.WeitereStaatsangehoerigkeit, "WeitereStaatsangehoerigkeit")
            _modelCore.AddMappingInformation(PropertyNames.Office365MailAddress, "office365")
		End Sub

		Public Sub New()
			Me.AccountDisabled = YesNoEnum.No
			Me.Gender = GenderEnum.Unknown
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Primärschlüssel (Personen-Id.)</summary>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
		<ViewGenerator(IsBrowseable:=False)>
		Public Property RowId As Int64 Implements IModelBase _
		(Of Person, PropertyNames, MasterDataContext).RowId
			Get
				Return _rowId
			End Get
			Set(value As Int64)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of Int64)(NameOf(Me.RowId), _rowId, value)
			End Set
		End Property

    '''<summary>Personen-Id.</summary>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <ViewGenerator(CustomViewOrder:=1, Category:="1|Stammdaten", IsReadonly:=True)>
    Public Property PersonId As Int64
      Get
        Return _personId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.PersonId), _personId, value)
      End Set
    End Property

    '''<summary>Nachname.</summary>
    <Required>
		<MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=2, Category:="1|Stammdaten", DisplayName:="Nachname")>
    Public Property LastName As String
      Get
        Return _lastname
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.LastName), _lastname, value)
        MyBase.RaisePropertyChanged(NameOf(Me.FullName))
      End Set
    End Property

    '''<summary>Vorname.</summary>
    <Required>
    <MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=3, Category:="1|Stammdaten", DisplayName:="Vorname")>
    Public Property FirstName As String
      Get
        Return _firstname
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.FirstName), _firstname, value)
        MyBase.RaisePropertyChanged(NameOf(Me.FullName))
      End Set
    End Property

    '''<summary>Vor- und Nachname der Person (Format: Nachname, Vorname).</summary>
    <NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public ReadOnly Property FullName As String
      Get
        Return String.Concat(Me.LastName, ", ", Me.FirstName)
      End Get
    End Property

#Region " Gender "
    '''<summary>GenderDatabaseValue - Bitte zum setzen des Geschlechts die Gender-Eigenschaft benutzen!!!</summary>
    <Required>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property GenderDatabaseValue As String
			Get
				Return _genderDatabaseValue
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.GenderDatabaseValue), _genderDatabaseValue, value)
				MyBase.RaisePropertyChanged(NameOf(Me.Gender))
				MyBase.RaisePropertyChanged(NameOf(Me.GenderDisplayValue))
			End Set
		End Property

		'''<summary>Geschlecht.</summary>
		<NotMapped>
    <ViewGenerator(CustomViewOrder:=4, Category:="1|Stammdaten", DisplayName:="Geschlecht", ViewType:=ViewTypes.Enum)>
    Public Property Gender As GenderEnum
      Get
        Return GenderEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.GenderDatabaseValue)
      End Get
      Set(value As GenderEnum)
        Me.GenderDatabaseValue = GenderEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
      End Set
    End Property

    '''<summary>Geschlecht-Anzeige-String. für DataBinding benutzen</summary>
    <NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property GenderDisplayValue As String
      Get
        Return GenderEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.Gender)
      End Get
      Set(value As String)
        Me.Gender = GenderEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
      End Set
    End Property
#End Region

    '''<summary>Geburtsdatum.</summary>
    <ViewGenerator(CustomViewOrder:=5, Category:="1|Stammdaten", DisplayName:="Geburtsdatum", ViewType:=ViewTypes.DatePicker)>
    Public Property DateOfBirth As DateTime?
      Get
        Return _dateOfBirth
      End Get
      Set(value As DateTime?)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of DateTime?)(NameOf(Me.DateOfBirth), _dateOfBirth, value)
      End Set
    End Property

    '''<summary>Namenskürzel.</summary>
    <MaxLength(10)>
    <ViewGenerator(CustomViewOrder:=6, Category:="1|Stammdaten", DisplayName:="Namenskürzel")>
    Public Property ShortName As String
      Get
        Return _shortName
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.ShortName), _shortName, value)
      End Set
    End Property

    '''<summary>Anrede.</summary>
    <MaxLength(30)>
    <ViewGenerator(CustomViewOrder:=7, Category:="1|Stammdaten", DisplayName:="Anrede")>
    Public Property FormOfAddress As String
      Get
        Return _formOfAddress
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.FormOfAddress), _formOfAddress, value)
      End Set
    End Property

    '''<summary>Staatsangehörigkeit.</summary>
    <MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=8, Category:="2|Herkunft", DisplayName:="Staatsangehörigkeit")>
    Public Property Nationality As String
			Get
				Return _nationality
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.Nationality), _nationality, value)
			End Set
		End Property

    '''<summary>Geburtsland-Id.</summary>
    <ViewGenerator(CustomViewOrder:=9, Category:="2|Herkunft", DisplayName:="Geburtsland-Id", IsBrowseable:=False)>
    Public Property CountryOfBirthId As Int64
      Get
        Return _countryOfBirthId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.CountryOfBirthId), _countryOfBirthId, value)
      End Set
    End Property

    '''<summary>Geburtsland.</summary>
    <MaxLength(100)>
    <ViewGenerator(CustomViewOrder:=10, Category:="2|Herkunft", DisplayName:="Geburtsland")>
    Public Property CountryOfBirth As String
			Get
				Return _countryOfBirth
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.CountryOfBirth), _countryOfBirth, value)
			End Set
		End Property

    '''<summary>Geburtsort.</summary>
    <MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=11, Category:="2|Herkunft", DisplayName:="Geburtsort")>
    Public Property PlaceOfBirth As String
			Get
				Return _placeOfBirth
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.PlaceOfBirth), _placeOfBirth, value)
			End Set
		End Property

    '''<summary>Geburtsname.</summary>
    <MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=12, Category:="2|Herkunft", DisplayName:="Geburtsname")>
    Public Property BirthName As String
      Get
        Return _birthName
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.BirthName), _birthName, value)
      End Set
    End Property

    '''<summary>Deutscher Titel der Person.</summary>
    <ViewGenerator(CustomViewOrder:=13, Category:="1|Titel", DisplayName:="Titel, deutsch")>
    Public Property TitleGerman As String
      Get
        Return _titelGerman
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.TitleGerman), _titelGerman, value)
      End Set
    End Property

    '''<summary>Internationaler Titel der Person.</summary>
    <ViewGenerator(CustomViewOrder:=14, Category:="1|Titel", DisplayName:="Titel, international")>
    Public Property TitleInternational As String
      Get
        Return _titelInternational
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.TitleInternational), _titelInternational, value)
      End Set
    End Property

    '''<summary>Titel, abf - Ausbildungs-, Berufs- und Funktionsbeschreibung der Person.</summary>
    <ViewGenerator(CustomViewOrder:=15, Category:="1|Titel", DisplayName:="Titel, abf" _
    , ToolTipText:="Ausbildungs-, Berufs- und Funktionsbeschreibung der Person.")>
    Public Property TitleTraining As String
      Get
        Return _titelTraining
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.TitleTraining), _titelTraining, value)
      End Set
    End Property

    '''<summary>Berufstitel der Person (z.B. Rechtsanwalt).</summary>
    <ViewGenerator(CustomViewOrder:=16, Category:="1|Titel", DisplayName:="Titel, Beruf" _
    , ToolTipText:="Berufstitel der Person (z.B. Rechtsanwalt).")>
    Public Property TitleJob As String
      Get
        Return _titelJob
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.TitleJob), _titelJob, value)
      End Set
    End Property

    '''<summary>Login-Name.</summary>
    <MaxLength(50)>
    <ViewGenerator(CustomViewOrder:=17, Category:="3|Zusatzinformationen", IsCategoryCollapsed:=True, DisplayName:="Login-Name")>
    Public Property LoginName() As String
			Get
				Return _loginName
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.LoginName), _loginName, value)
			End Set
		End Property

#Region " AccountDisabled "
    '''<summary>AccountDisabledDatabaseValue. Bitte zum Konto-(De)Aktivieren die AccountDisabled-Eigenschaft benutzen!!!</summary>
    <Required>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property AccountDisabledDatabaseValue As String
			Get
				Return _accountDisabledDatabaseValue
			End Get
			Set(value As String)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of String)(NameOf(Me.AccountDisabledDatabaseValue), _accountDisabledDatabaseValue, value)
				MyBase.RaisePropertyChanged(NameOf(Me.AccountDisabled))
				MyBase.RaisePropertyChanged(NameOf(Me.AccountDisabledDisplayValue))
			End Set
		End Property

		'''<summary>Konto deaktiviert.</summary>
		<NotMapped>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property AccountDisabled As YesNoEnum
      Get
        Return YesNoEnumAdapter.Instance.ParseDatabaseStringToEnumValue(Me.AccountDisabledDatabaseValue)
      End Get
      Set(value As YesNoEnum)
        Me.AccountDisabledDatabaseValue = YesNoEnumAdapter.Instance.ParseEnumValueToDatabaseString(value)
      End Set
    End Property

    '''<summary>Konto-Deaktiviert-Anzeige-String.</summary>
    <NotMapped>
    <ViewGenerator(CustomViewOrder:=18, Category:="3|Zusatzinformationen", DisplayName:="Konto deaktiviert")>
    Public Property AccountDisabledDisplayValue As String
      Get
        Return YesNoEnumAdapter.Instance.ParseEnumValueToDisplayString(Me.AccountDisabled)
      End Get
      Set(value As String)
        Me.AccountDisabled = YesNoEnumAdapter.Instance.ParseDisplayStringToEnumValue(value)
      End Set
    End Property
#End Region

    '''<summary>Kontoverfallsdatum.</summary>
    <ViewGenerator(CustomViewOrder:=19, Category:="3|Zusatzinformationen", DisplayName:="Kontoverfallsdatum")>
    Public Property AccountExpireDate As DateTime?
      Get
        Return _accountExpireDate
      End Get
      Set(value As DateTime?)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of DateTime?)(NameOf(Me.AccountExpireDate), _accountExpireDate, value)
      End Set
    End Property

    '''<summary>Culture Code.</summary>
    <MaxLength(5)>
    <ViewGenerator(CustomViewOrder:=20, DisplayName:="Culture Code", IsBrowseable:=False)>
    Public Property PersonCultureCode As String
      Get
        Return _personCultureCode
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.PersonCultureCode), _personCultureCode, value)
      End Set
    End Property

    '''<summary>Personen-Id. des Erstellers.</summary>
    <ViewGenerator(CustomViewOrder:=21, DisplayName:="Ersteller-Id", IsBrowseable:=False)>
    Public Property CreationUserId() As Int64 Implements IModifiedUpdater.CreationUserId
      Get
        Return _creationUserId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.CreationUserId), _creationUserId, value)
      End Set
    End Property

    '''<summary>Datum der Erstellung.</summary>
    <ViewGenerator(CustomViewOrder:=22, DisplayName:="Erstelldatum", IsBrowseable:=False)>
    Public Property CreationDate As DateTime Implements IModifiedUpdater.CreationDate
      Get
        Return _creationDate
      End Get
      Set(value As DateTime)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of DateTime)(NameOf(Me.CreationDate), _creationDate, value)
      End Set
    End Property

    '''<summary>Personen-Id. des GeändertUsers.</summary>
    <ViewGenerator(CustomViewOrder:=23, DisplayName:="Letzte Änderung Personen-Id", IsBrowseable:=False)>
    Public Property ManipulationUserId() As Int64 Implements IModifiedUpdater.ManipulationUserId
      Get
        Return _manipulationUserId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.ManipulationUserId), _manipulationUserId, value)
      End Set
    End Property

    <ViewGenerator(CustomViewOrder:=24, DisplayName:="Letzte Änderung", IsBrowseable:=False)>
    Public Property ManipulationDate As DateTime? Implements IModifiedUpdater.ManipulationDate
			Get
				Return _manipulationDate
			End Get
			Set(value As DateTime?)
				MyBase.SetPropertyValueAndRaisePropertyChanged _
				(Of DateTime?)(NameOf(Me.ManipulationDate), _manipulationDate, value)
			End Set
		End Property

    '''<summary>Bemerkung.</summary>
    <ViewGenerator(CustomViewOrder:=25, Category:="3|Zusatzinformationen", DisplayName:="Bemerkung")>
    Public Property Comment As String
      Get
        Return _comment
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.Comment), _comment, value)
      End Set
    End Property

	Public Property WeitereStaatsangehoerigkeit As String
      Get
        Return _weitereStaatsangehoerigkeit
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.WeitereStaatsangehoerigkeit), _weitereStaatsangehoerigkeit, value)
      End Set
    End Property

    Public Property Office365MailAddress As String
      Get
        Return _office365MailAddress
      End Get
      Set(value As String)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of String)(NameOf(Me.Office365MailAddress), _office365MailAddress, value)
      End Set
    End Property

    ''''<summary>Kennwort - Zum Setzen des Kennwortes bitte die Methode SetPassword benutzen.</summary>
    'Public Property Password() As String

    ''''<summary>Passwort, WLAN.</summary>
    'Public Property PasswordWLAN() As String

    ''''<summary>Letzte Änderung des Kennworts.</summary>
    'Public ReadOnly Property LastModifiedPasswordDate As DateTime
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Overrides Function ToString() As String
			Return Me.FullName
		End Function

		Public Shared Function GetModelCore() As ModelCore _
		(Of Person, PropertyNames, MasterDataContext)
			Return _modelCore
		End Function

		Private Function ModelCore() As ModelCore(Of Person, PropertyNames, MasterDataContext) _
		Implements IModelBase(Of Person, PropertyNames, MasterDataContext).ModelCore
			Return _modelCore
		End Function

		Private Function ModelBase() As ModelBase(Of Person) _
		Implements IModelBase(Of Person, PropertyNames, MasterDataContext).ModelBase
			Return DirectCast(Me, ModelBase(Of Person))
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace