Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Repositories.Core
Imports SSP.Data.EntityFrameworkX.Validators.Interfaces
Imports SSP.Base.ExtensionMethods
Imports SSP.Data.EntityFrameworkX.Validators.Enums
#End Region

Namespace Validators

    Public Class ModelValidator(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
    , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

        Implements IModelValidator
        Implements IModelValidator(Of TModel, TPropertyNames, TContext)

#Region " --------------->> Implements IModelValidator "
        Private Function GetPropertyName(ByVal propertyName As String) As TPropertyNames

            Dim value = DirectCast(System.Enum.Parse _
            (GetType(TPropertyNames), propertyName), TPropertyNames)
            Return value
        End Function

        Private Function IModelValidator_IsModelCollectionValid _
        (items As IEnumerable(Of Object)) As Boolean _
        Implements IModelValidator.IsModelCollectionValid
            Return Me.IsModelCollectionValid(items.OfType(Of TModel))
        End Function

        Private Function IModelValidator_IsModelValid(item As Object) As Boolean _
        Implements IModelValidator.IsModelValid
            Return Me.IsModelValid(DirectCast(item, TModel))
        End Function

        Private Function IModelValidator_IsPropertyValueValid _
        (item As Object, propertyName As String) As Boolean _
        Implements IModelValidator.IsPropertyValueValid
            Return Me.IsPropertyValueValid(DirectCast(item, TModel), GetPropertyName(propertyName))
        End Function

        Private Function IModelValidator_GetModelCollectionValidationErrorMessage _
        (items As IEnumerable(Of Object)) As String _
        Implements IModelValidator.GetModelCollectionValidationErrorMessage
            Return Me.GetModelCollectionValidationErrorMessage(items.OfType(Of TModel))
        End Function

        Private Function IModelValidator_GetModelValidationErrorMessage(item As Object) As String _
        Implements IModelValidator.GetModelValidationErrorMessage
            Return Me.GetModelValidationErrorMessage(DirectCast(item, TModel))
        End Function

        Private Function IModelValidator_GetPropertyValidationErrorMessage _
        (item As Object, propertyName As String) As String _
        Implements IModelValidator.GetPropertyValidationErrorMessage
            Return Me.GetPropertyValidationErrorMessage _
            (DirectCast(item, TModel), GetPropertyName(propertyName))
        End Function

        Private Function IModelValidator_GetValidationResults(item As Object) _
        As IEnumerable(Of DbEntityValidationResult) _
        Implements IModelValidator.GetValidationResults
            Return Me.GetValidationResults(DirectCast(item, TModel))
        End Function

        Private Function IModelValidator_GetValidationResults(items As IEnumerable(Of Object)) _
        As IEnumerable(Of DbEntityValidationResult) _
        Implements IModelValidator.GetValidationResults
            Return Me.GetValidationResults(items.OfType(Of TModel))
        End Function

        Private Function IModelValidator_GetInvalidPropertyNames _
        (item As Object) As IEnumerable(Of String) _
        Implements IModelValidator.GetInvalidPropertyNames
            Return Me.GetInvalidPropertyNames(DirectCast(item, TModel)).Select _
            (Function(x) x.ToString).ToList
        End Function

        Private Function IModelValidator_WhatHappenedIf _
        (propertyName As String, value As Object) _
        As WhatHappenedIfResults Implements IModelValidator.WhatHappenedIf
            Return Me.WhatHappenedIf(GetPropertyName(propertyName), value)
        End Function
#End Region

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private _contextRepository As RepositoryBase(Of TModel, TPropertyNames, TContext)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Public Sub New(ByVal repository As RepositoryBase(Of TModel, TPropertyNames, TContext))

            _contextRepository = repository
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
        '''<summary>
        '''Validiert die Eigenschaften aller übergebenen Models und liefert true, 
        '''wenn sämtliche Eigenschaften valide Werte beinhalten.
        '''</summary>
        Public Function IsModelCollectionValid _
        (items As IEnumerable(Of TModel)) As Boolean _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).IsModelCollectionValid

            Return Not GetValidationResults(items).Any
        End Function

        '''<summary>
        '''Validiert die Eigenschaften des übergebenen Models und liefert true, 
        '''wenn sämtliche Eigenschaften valide Werte beinhalten.
        '''</summary>
        Public Function IsModelValid(item As TModel) As Boolean _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).IsModelValid

            Dim errors = GetValidationResults(New TModel() {item})
            Return (Not errors.Any(Function(x) (x.Entry.Entity Is item)))
        End Function

        '''<summary>
        '''Validiert die Eigenschaft propertyName des übergebenen Models und liefert true, 
        '''wenn die Eigenschaft einen validen Wert beinhaltet.
        '''</summary>
        Public Function IsPropertyValueValid _
        (item As TModel, propertyName As TPropertyNames) As Boolean _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).IsPropertyValueValid

            Dim errors = GetValidationResults(New TModel() {item})
            Return (Not errors.Any(Function(x) (x.Entry.Entity Is item) _
            AndAlso (x.ValidationErrors.Any _
            (Function(y) y.PropertyName = propertyName.ToString))))
        End Function

        '''<summary>
        '''Validiert die Eigenschaften aller übergebenen Models und liefert einen Leerstring, 
        '''wenn sämtliche Eigenschaften valide Werte beinhalten.
        '''Ansonsten werden die Fehlermeldungen der Validierungsverstösse geliefert.
        '''</summary>
        Public Function GetModelCollectionValidationErrorMessage _
        (items As IEnumerable(Of TModel)) As String _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetModelCollectionValidationErrorMessage

            Dim list = items.ToList
            Dim sb = New Text.StringBuilder
            For Each modelError In GetValidationResults(items)
                Dim model = DirectCast(modelError.Entry.Entity, TModel)
                Dim modelName = String.Concat(GetType(TModel).Name, (list.IndexOf(model) + 1).ToString, ": ")

                For Each validationError In modelError.ValidationErrors
                    sb.AppendLine(String.Concat(modelName, validationError.ErrorMessage))
                Next validationError

            Next modelError

            Return sb.ToString
        End Function

        '''<summary>
        '''Validiert die Eigenschaften des übergebenen Models und liefert einen Leerstring, 
        '''wenn sämtliche Eigenschaften valide Werte beinhalten.
        '''Ansonsten werden die Fehlermeldungen der Validierungsverstösse geliefert.
        '''</summary>
        Public Function GetModelValidationErrorMessage(item As TModel) As String _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetModelValidationErrorMessage

            Dim errors = GetValidationResults(New TModel() {item}).Where(Function(x) x.Entry.Entity Is item)
            Dim validationErrors = New List(Of DbValidationError)
            errors.ToList.ForEach(Sub(x) validationErrors.AddRange(x.ValidationErrors))

            Dim errorsOfModel = validationErrors.Select(Function(x) x.ErrorMessage).ToList
            Return errorsOfModel.EnumerableJoin(vbCrLf)
        End Function

        '''<summary>
        '''Validiert die Eigenschaft propertyName des übergebenen Models und liefert einen Leerstring, 
        '''wenn die Eigenschaft einen validen Wert beinhaltet.
        '''Ansonsten wird die Fehlermeldung des Validierungsverstösses geliefert.
        '''</summary>
        Public Function GetPropertyValidationErrorMessage _
        (item As TModel, propertyName As TPropertyNames) As String _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetPropertyValidationErrorMessage

            Dim errors = GetValidationResults(New TModel() {item}).Where(Function(x) x.Entry.Entity Is item)
            Dim validationErrors = New List(Of DbValidationError)
            errors.ToList.ForEach(Sub(x) validationErrors.AddRange(x.ValidationErrors))

            Dim errorsOfModel = validationErrors.Where _
            (Function(x) x.PropertyName = propertyName.ToString).Select _
            (Function(x) x.ErrorMessage).ToList

            Return errorsOfModel.EnumerableJoin(vbCrLf)
        End Function

        '''<summary>
        '''Liefert eine Liste mit DBEntityValidationResult-Objekten zum übergebenen Model.
        '''Sollten beim Validieren des Models keine Fehler aufgetreten sein,
        '''wird eine leere Liste geliefert.
        '''</summary>
        Public Function GetValidationResults(ByVal item As TModel) _
        As IEnumerable(Of DbEntityValidationResult) _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetValidationResults

            Return GetValidationResults(New TModel() {item})
        End Function

        '''<summary>
        '''Liefert eine Liste mit DBEntityValidationResult-Objekten zu den übergebenen Models.
        '''Sollten beim Validieren der Models keine Fehler aufgetreten sein,
        '''wird eine leere Liste geliefert.
        '''</summary>
        Public Function GetValidationResults(ByVal items As IEnumerable(Of TModel)) _
        As IEnumerable(Of DbEntityValidationResult) _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetValidationResults

            Using context = ContextManager.Instance.CreateContext(Of TContext)
                Dim dbSet = context.Set(Of TModel)
                items.ToList.ForEach(Function(x) dbSet.Add(x))
                Return context.GetValidationErrors()
            End Using
        End Function

        '''<summary>
        '''Liefert eine Liste mit Eigenschaften-Namen des übergebenen Models,
        '''welche invalide Werte aufweisen.
        '''</summary>
        Public Function GetInvalidPropertyNames(item As TModel) As IEnumerable(Of TPropertyNames) _
        Implements IModelValidator(Of TModel, TPropertyNames, TContext).GetInvalidPropertyNames

            Dim errors = GetValidationResults(New TModel() {item}).Where(Function(x) x.Entry.Entity Is item)
            Dim validationErrors = New List(Of DbValidationError)
            errors.ToList.ForEach(Sub(x) validationErrors.AddRange(x.ValidationErrors))

            Dim errorsOfModel = validationErrors.Select _
            (Function(x) CType(System.Enum.Parse(GetType(TPropertyNames), x.PropertyName), TPropertyNames)) _
            .Distinct.ToList

            Return errorsOfModel.ToArray
        End Function

        '''<summary>
        '''Legt ein neues Objekt vom Typ TModel an und setzt die Eigenschaft propertyName
        '''auf den Wert von value und gibt zurück, ob dies ein gültiger Wert für die
        '''Eigenschaft ist.
        '''</summary>
        Public Function WhatHappenedIf _
        (propertyName As TPropertyNames, value As Object) _
        As WhatHappenedIfResults Implements IModelValidator _
        (Of TModel, TPropertyNames, TContext).WhatHappenedIf

            Dim model = New TModel
            model.ModelCore.SetPropertyValue(model, propertyName, value)

            Return If(Me.IsPropertyValueValid(model, propertyName) _
            , WhatHappenedIfResults.WouldBeValid _
            , WhatHappenedIfResults.WouldBeInValid)
        End Function
#End Region '{Öffentliche Methoden der Klasse}

    End Class


End Namespace

