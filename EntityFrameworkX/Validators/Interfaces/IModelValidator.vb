Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity.Validation
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Validators.Enums
#End Region

Namespace Validators.Interfaces

    Public Interface IModelValidator

        Function IsModelCollectionValid(ByVal items As IEnumerable(Of Object)) As Boolean
        Function IsModelValid(ByVal item As Object) As Boolean
        Function IsPropertyValueValid(ByVal item As Object, ByVal propertyName As String) As Boolean
        Function GetModelCollectionValidationErrorMessage(ByVal items As IEnumerable(Of Object)) As String
        Function GetModelValidationErrorMessage(ByVal item As Object) As String
        Function GetPropertyValidationErrorMessage(ByVal item As Object, ByVal propertyName As String) As String
        Function GetValidationResults(ByVal item As Object) As IEnumerable(Of DbEntityValidationResult)
        Function GetValidationResults(ByVal items As IEnumerable(Of Object)) As IEnumerable(Of DbEntityValidationResult)
        Function GetInvalidPropertyNames(ByVal item As Object) As IEnumerable(Of String)
        Function WhatHappenedIf(ByVal propertyName As String, ByVal value As Object) As WhatHappenedIfResults
    End Interface

End Namespace

