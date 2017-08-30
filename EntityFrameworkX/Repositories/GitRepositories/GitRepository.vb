Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "

Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.GitModels
Imports SSP.Data.EntityFrameworkX.Repositories.Core

#End Region

Namespace Repositories.GitRepositories

	Partial Public Class GitRepository

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private Shared _instance As GitRepository

		Private _repositoriesRepository As New RepositoryBase _
		(Of Repository, Repository.PropertyNames, GitContext)

		Private _repositoryDependenciesRepository As New RepositoryBase _
		(Of RepositoryDependency, RepositoryDependency.PropertyNames, GitContext)

		Private _repositoryDeveloperRepository As New RepositoryBase _
		(Of RepositoryDeveloper, RepositoryDeveloper.PropertyNames, GitContext)

		Private _repositoryProductownerRepository As New RepositoryBase _
		(Of RepositoryProductowner, RepositoryProductowner.PropertyNames, GitContext)

		Private _kachelRepository As New RepositoryBase _
		(Of Kachel, Kachel.PropertyNames, GitContext)

		Private _personenKachelRepository As New RepositoryBase _
		(Of PersonenKachel, PersonenKachel.PropertyNames, GitContext)

		Private _schlagwortRepository As New RepositoryBase _
		(Of Schlagwort, Schlagwort.PropertyNames, GitContext)

		Private _kachelSchlagwortRepository As New RepositoryBase _
		(Of KachelSchlagwort, KachelSchlagwort.PropertyNames, GitContext)

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Private Sub New()
		End Sub

		Shared Sub New()
			_instance = New GitRepository
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Shared ReadOnly Property Instance As GitRepository
			Get
				Return _instance
			End Get
		End Property

		Public ReadOnly Property RepositoriesRepository As RepositoryBase _
		(Of Repository, Repository.PropertyNames, GitContext)
			Get
				Return _repositoriesRepository
			End Get
		End Property

		Public ReadOnly Property RepositoryDependenciesRepository As RepositoryBase _
		(Of RepositoryDependency, RepositoryDependency.PropertyNames, GitContext)
			Get
				Return _repositoryDependenciesRepository
			End Get
		End Property

		Public ReadOnly Property RepositoryDeveloperRepository As RepositoryBase _
		(Of RepositoryDeveloper, RepositoryDeveloper.PropertyNames, GitContext)
			Get
				Return _repositoryDeveloperRepository
			End Get
		End Property

		Public ReadOnly Property KachelRepository As RepositoryBase _
		(Of Kachel, Kachel.PropertyNames, GitContext)
			Get
				Return _kachelRepository
			End Get
		End Property

		Public ReadOnly Property PersonenKachelRepository As RepositoryBase _
		(Of PersonenKachel, PersonenKachel.PropertyNames, GitContext)
			Get
				Return _personenKachelRepository
			End Get
		End Property

		Public ReadOnly Property RepositoryProductownerRepository As RepositoryBase _
		(Of RepositoryProductowner, RepositoryProductowner.PropertyNames, GitContext)
			Get
				Return _repositoryProductownerRepository
			End Get
		End Property

		Public ReadOnly Property SchlagwortRepository As RepositoryBase _
		(Of Schlagwort, Schlagwort.PropertyNames, GitContext)
			Get
				Return _schlagwortRepository
			End Get
		End Property

		Public ReadOnly Property KachelSchlagwortRepository As RepositoryBase _
		(Of KachelSchlagwort, KachelSchlagwort.PropertyNames, GitContext)
			Get
				Return _kachelSchlagwortRepository
			End Get
		End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
