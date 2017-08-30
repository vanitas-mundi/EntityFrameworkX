Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports BCW.Data.BaseDAL.Contexts
#End Region

Namespace Repositories.Core

  '''<summary>Stellt Repository-Basisfunktionalität zur Verfügung für StoredProcedures</summary>
  Public MustInherit Class RepositoryBaseStoredProcedure(Of T, TContextType As ContextBase)

    Inherits RepositoryBase(Of T, TContextType)

#Region " --------------->> Enumerationen der Klasse "
#End Region  '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region  '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    ''' <summary>Konstruktor</summary>
    Public Sub New(ByVal unityWrapper As IUnityDALWrapper, ByVal contextType As Type)
      MyBase.New(unityWrapper, contextType)
    End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region  '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region  '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region  '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function Add(ByVal item As T) As Int32
      Return 0
    End Function

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function AddRange(ByVal items As IEnumerable(Of T)) As Int32
      Return 0
    End Function

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function Update(ByVal item As T) As Int32
      Return 0
    End Function

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function UpdateRange(ByVal items As IEnumerable(Of T)) As Int32
      Return 0
    End Function

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function Delete(ByVal item As T) As Int32
      Return 0
    End Function

    ''' <summary>Dummy-Fnktion, liefert immer 0.</summary>
    Public Overrides Function DeleteRange(ByVal items As IEnumerable(Of T)) As Int32
      Return 0
    End Function

#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
