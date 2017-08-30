Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.Test
Imports SSP.Data.EntityFrameworkX.Repositories.Core
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Repositories.MasterDataRepositories
#End Region

Namespace Repositories.Test

  Partial Public Class TestRepository

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private Shared _instance As TestRepository

    Private _validationTestsRepository As New RepositoryBase _
    (Of ValidationTestModel, ValidationTestModel.PropertyNames, TestContext)
    Private _namesRepository As New RepositoryBase _
    (Of NameModel, NameModel.PropertyNames, TestContext)
    Private _valuesRepository As New RepositoryBase _
    (Of ValueModel, ValueModel.PropertyNames, TestContext)

#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Private Sub New()
    End Sub

    Shared Sub New()
      _instance = New TestRepository
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    Public Shared ReadOnly Property Instance As TestRepository
      Get
        Return _instance
      End Get
    End Property

    Public ReadOnly Property ValidationTestsRepository As RepositoryBase _
    (Of ValidationTestModel, ValidationTestModel.PropertyNames, TestContext)
      Get
        Return _validationTestsRepository
      End Get
    End Property

    Public ReadOnly Property NamesRepository As RepositoryBase _
    (Of NameModel, NameModel.PropertyNames, TestContext)
      Get
        Return _namesRepository
      End Get
    End Property

    Public ReadOnly Property ValuesRepository As RepositoryBase _
    (Of ValueModel, ValueModel.PropertyNames, TestContext)
      Get
        Return _valuesRepository
      End Get
    End Property

    Public ReadOnly SchulungsTeilnehmersRepository As New RepositoryBase _
    (Of SchulungsTeilnehmer, SchulungsTeilnehmer.PropertyNames, TestContext)

    Public ReadOnly IdCardsRepository As New RepositoryBase _
    (Of IdCard, IdCard.PropertyNames, TestContext)
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    Public Function IncludeTest() As IQueryable(Of NameModel)


      Dim context = ContextManager.Instance.GetContext(Of TestContext)
      Return context.Set(Of NameModel).Where(Function(item) item.NameModelId = 1).AsQueryable

      'Dim name2 = Me.NamesRepository.AsQueryable.First
      'Console.WriteLine(name2.ValueCollection.Count)

      'Dim name = Me.NamesRepository.AsQueryable(New String() {"ValueCollection"}).First
      'Console.WriteLine(name.ValueCollection.Count)


      'Me.NamesRepository.AsQueryable.in


      'Using context = ContextManager.Instance.CreateContext(Of TestContext)
      '	Return context.NameModels.Include("ValueCollection").First '.Include(function(x)x.)
      'End Using
      Return Nothing
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
