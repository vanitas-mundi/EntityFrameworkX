Option Explicit On
Option Infer On
Option Strict On
Imports System.Data.Entity

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity.Validation
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Validators.Enums
#End Region

Namespace Validators.Interfaces

    Public Interface IModelValidator(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
    , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

        Function IsModelCollectionValid(ByVal items As IEnumerable(Of TModel)) As Boolean
        Function IsModelValid(ByVal item As TModel) As Boolean
        Function IsPropertyValueValid(ByVal item As TModel, ByVal propertyName As TPropertyNames) As Boolean
        Function GetModelCollectionValidationErrorMessage(ByVal items As IEnumerable(Of TModel)) As String
        Function GetModelValidationErrorMessage(ByVal item As TModel) As String
        Function GetPropertyValidationErrorMessage(ByVal item As TModel, ByVal propertyName As TPropertyNames) As String
        Function GetValidationResults(ByVal item As TModel) As IEnumerable(Of DbEntityValidationResult)
        Function GetValidationResults(ByVal items As IEnumerable(Of TModel)) As IEnumerable(Of DbEntityValidationResult)
        Function GetInvalidPropertyNames(ByVal item As TModel) As IEnumerable(Of TPropertyNames)
        Function WhatHappenedIf(ByVal propertyName As TPropertyNames, ByVal value As Object) As WhatHappenedIfResults
    End Interface

End Namespace

