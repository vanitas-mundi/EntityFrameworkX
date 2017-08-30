Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels
Imports SSP.Data.EntityFrameworkX.Repositories.Core
Imports Enumerable = System.Linq.Enumerable
#End Region

Namespace Repositories.MasterDataRepositories

	Partial Public Class MasterDataRepository

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As MasterDataRepository

		Private _personsRepository As New RepositoryBase _
		(Of Person, Person.PropertyNames, MasterDataContext)

		Private _addressesRepository As New RepositoryBase _
		(Of Address, Address.PropertyNames, MasterDataContext)

		Private _communicationsRepository As New RepositoryBase _
		(Of Communication, Communication.PropertyNames, MasterDataContext)

		Private _personAcademicTitlesRepository As New RepositoryBase _
		(Of PersonAcademicTitle, PersonAcademicTitle.PropertyNames, MasterDataContext)

		Private _personPhotosRepository As New RepositoryBase _
		(Of PersonPhoto, PersonPhoto.PropertyNames, MasterDataContext)

		Private _personStatus As New RepositoryBase _
		(Of PersonStatus, PersonStatus.PropertyNames, MasterDataContext)

		Private _personEducation As New RepositoryBase _
		(Of PersonEducation, PersonEducation.PropertyNames, MasterDataContext)

		Private _company As New RepositoryBase _
		(Of Company, Company.PropertyNames, MasterDataContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Private Sub New()
		End Sub

		Shared Sub New()
			_instance = New MasterDataRepository
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As MasterDataRepository
			Get
				Return _instance
			End Get
		End Property

		Public ReadOnly Property PersonsRepository As RepositoryBase _
		(Of Person, Person.PropertyNames, MasterDataContext)
			Get
				Return _personsRepository
			End Get
		End Property

		Public ReadOnly Property AddressesRepository As RepositoryBase _
		(Of Address, Address.PropertyNames, MasterDataContext)
			Get
				Return _addressesRepository
			End Get
		End Property

		Public ReadOnly Property CommunicationsRepository As RepositoryBase _
		(Of Communication, Communication.PropertyNames, MasterDataContext)
			Get
				Return _communicationsRepository
			End Get
		End Property

		Public ReadOnly Property PersonAcademicTitlesRepository As RepositoryBase _
		(Of PersonAcademicTitle, PersonAcademicTitle.PropertyNames, MasterDataContext)
			Get
				Return _personAcademicTitlesRepository
			End Get
		End Property

		Public ReadOnly Property PersonPhotosRepository As RepositoryBase _
	(Of PersonPhoto, PersonPhoto.PropertyNames, MasterDataContext)
			Get
				Return _personPhotosRepository
			End Get
		End Property


		Public ReadOnly Property PersonStatusRepository As RepositoryBase _
			(Of PersonStatus, PersonStatus.PropertyNames, MasterDataContext)
			Get
				Return _personStatus
			End Get
		End Property

		Public ReadOnly Property PersonEducationRepository As RepositoryBase _
			(Of PersonEducation, PersonEducation.PropertyNames, MasterDataContext)
			Get
				Return _personEducation
			End Get
		End Property

		Public ReadOnly Property CompanyRepository As RepositoryBase _
			(Of Company, Company.PropertyNames, MasterDataContext)
			Get
				Return _company
			End Get
		End Property

		

#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function GetAddressesByPersonId _
		(ByVal personId As Int64) As List(Of Address)

			Return ContextManager.Instance.CreateContext(Of MasterDataContext).Addresses.Where _
			(Function(x) x.PersonId = personId).ToList
			'Return Me.AddressesRepository.AsQueryable.Where _
			'(Function(x) x.PersonId = personId).ToList
		End Function

		public Function GetPersonAcademicTitleByAcademicTitleId(ByVal academicTitleId As Int64) As PersonAcademicTitle
			Return Enumerable.FirstOrDefault(ContextManager.Instance.CreateContext(Of MasterDataContext).PersonAcademicTitles, Function(x) x.AcademicTitleId = academicTitleId)
		End Function

		public Shared function HolePersonPhotoZurPersonId(ByVal personId As Int64 ) As PersonPhoto

			Dim photo = New PersonPhoto
			dim photoQry = Instance.PersonPhotosRepository.AsQueryable _
			.Where(Function(x) (x.PersonId.HasValue) AndAlso(x.PersonId.Value = personId)) _
			.OrderByDescending(Function(x) x.PersonPhotoId).ToList
			if (photoQry.Any()) then
				photo = photoQry.FirstOrDefault
			End If

			return photo
		End Function
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
