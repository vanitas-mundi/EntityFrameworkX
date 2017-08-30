﻿Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
#End Region

Namespace Repositories.Core.Interfaces

  '''<summary>Erweitere eine Klasse um Repository-Basisfunktionalität.</summary>
  Public Interface IRepositoryReadOnlyBase(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
  , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

    '''<summary>Prüft, ob ein Objekt mit der angegebenen Id in der Datenbank existiert.</summary>
    Function Exists(ByVal id As Int64) As Boolean
    '''<summary>Liefert das Objekt zur angegebenen Id.</summary>
    Function GetById(ByVal id As Int64) As TModel
    '''<summary>Liefert das Objekt zur angegebenen Id.</summary>
    Function GetById(ByVal id As Int64, ByVal includes As String()) As TModel
    '''<summary>Liefert die Objekt zu den angegebenen Ids.</summary>
    Function GetByIds(ByVal ids As IEnumerable(Of Int64)) As IQueryable(Of TModel)
    '''<summary>Fügt das angebene Objekt in die Datenbank ein.</summary>
    Function GetAll() As IQueryable(Of TModel)
    '''<summary>Liefert alle Objekte aus der Datenbank als IQueryable.</summary>
    Function AsQueryable() As IQueryable(Of TModel)
    '''<summary>
    '''Liefert alle Objekte aus der Datenbank als IQueryable.
    '''Benötigte Includes werden als String-Array übergeben.
    '''</summary>
    Function AsQueryable(ByVal includes As String()) As IQueryable(Of TModel)
    '''<summary>Liefert das letzte ausgeführte SQL-Kommando.</summary>
    ReadOnly Property LastExecutedStatement As Statement
    '''<summary>Führt eine Stored-Function vom Typ T aus. 
    ''' Bsp.: ExecuteStoredFunction(Of String)("nv.GetValue", "param1") | 
    '''       ExecuteStoredFunction(Of String)("MD5", "Geheim")
    '''</summary>
    Function ExecuteStoredFunction(Of T) _
    (ByVal functionName As String, ByVal ParamArray functionParameters As Object()) As T

    '''<summary>Führt ein SQL-Stament aus.</summary>
    Function ExecuteStatement(Of T) (ByVal statement As string) As T

  End Interface

End Namespace

