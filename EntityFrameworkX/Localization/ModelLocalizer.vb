Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Base.StringHandling
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Base.ExtensionMethods.EnumerableExtensions
Imports SSP.Data.EntityFrameworkX.Models.Core.EnumAdapters
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports System.Text
Imports SSP.Base.Serialization
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Validators.Exceptions
Imports SSP.Data.EntityFrameworkX.Localization.Exceptions
#End Region

Namespace Localization

  Public Class ModelLocalizer _
  (Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
  , TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
    Private _lastExecutedStatement As New Statement
    Private _models As IEnumerable(Of TModel)
    Private _modelBase As ModelCore(Of TModel, TPropertyNames, TContext)
    Private _databaseName As String = ""
    Private _tableName As String = ""
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
    Public Sub New(ByVal models As IEnumerable(Of TModel))
      Initialize(models)
    End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    '''<summary>Liefert das letzte gegen die Datenbank abgesetzte SQL-Statement.</summary>
    Public ReadOnly Property LastExecutedStatement As Statement
      Get
        Return _lastExecutedStatement
      End Get
    End Property

    Private ReadOnly Property Context As DatabaseDefaultContext
      Get
        Return ContextManager.Instance.GetContext(Of DatabaseDefaultContext)
      End Get
    End Property

    Private ReadOnly Property ModelBase As ModelCore(Of TModel, TPropertyNames, TContext)
      Get
        Return _modelBase
      End Get
    End Property

    Private ReadOnly Property DatabaseName As String
      Get
        Return _databaseName
      End Get
    End Property

    Private ReadOnly Property TableName As String
      Get
        Return _tableName
      End Get
    End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
    Private Sub Initialize(ByVal models As IEnumerable(Of TModel))

      _models = models

      If Not _models.Any Then Exit Sub
      _modelBase = _models.First.ModelCore
      Dim parts = Me.ModelBase.TableName.Split("."c)
      _databaseName = parts.First
      _tableName = parts.Last
    End Sub

    Private Function ParseToPropertyName(ByVal s As String) As TPropertyNames
      Return CType(System.Enum.Parse(GetType(TPropertyNames), s), TPropertyNames)
    End Function

    Private Function GetLocalizeablePropertyNames() As List(Of TPropertyNames)
      Return Helper.Reflection.PropertyInfo.GetArrayByAttribute _
      (Of TModel, IsLocalizeableAttribute).Select _
      (Function(x) ParseToPropertyName(x.Name)).ToList
    End Function

    Private Function GetNotLocalizeablePropertyNames() As List(Of TPropertyNames)
      Return Me.ModelBase.GetPropertyNames.Except(GetLocalizeablePropertyNames).ToList
    End Function

    Private Function GetModelsRowIdString() As String
      Return _models.Select(Function(x) x.RowId.ToString).EnumerableJoin
    End Function

    Private Function GetCultureCodeString(ByVal cultureCode As CultureCodes) As String
      Return CultureCodeEnumAdapter.Instance.ParseEnumValueToDatabaseString(cultureCode)
    End Function

    Private Function ParseToDatabaseFieldName(ByVal propertyName As TPropertyNames) As String
      Return Me.ModelBase.GetDatabaseFieldName(propertyName)
    End Function

    Private Function GetFieldString _
    (ByVal formatMask As String, ByVal propertyName As TPropertyNames) As String

      Dim fieldName = ParseToDatabaseFieldName(propertyName)
      Return String.Format(formatMask, fieldName, propertyName.ToString)
    End Function

    Private Sub AddFieldStringsToStringBuilder _
    (ByVal sb As StringBuilder _
    , ByVal culturecode As CultureCodes _
    , ByVal delimiter As String)

#Region "Format-Masken setzen"
      Dim localizeableFormat = String.Concat _
      ("def.GetLocalization('" _
      , Me.DatabaseName _
      , "', '" _
      , Me.TableName _
      , "', '{0}', _rowid, {0}, '" _
      , GetCultureCodeString(culturecode) _
      , "') AS '{1}'")

      Dim notLocalizeableFormat = "{0} AS '{1}'"
#End Region

      Dim localizeablePropertyNames = GetLocalizeablePropertyNames()
      Dim notLocalizeablePropertyNames = GetNotLocalizeablePropertyNames()

      Dim fields = New List(Of String)

      fields.AddRange(notLocalizeablePropertyNames.Select _
      (Function(x) GetFieldString(notLocalizeableFormat, x)))

      fields.AddRange(localizeablePropertyNames.Select _
      (Function(x) GetFieldString(localizeableFormat, x)))

      sb.AppendLine(fields.EnumerableJoin(", " & delimiter))
    End Sub

    Private Function GetModelsFromDatabaseAndSetModelCultureCode _
    (ByVal statement As Statement, ByVal cultureCode As CultureCodes) As IEnumerable(Of TModel)

      _lastExecutedStatement = statement

      'Modelle abrufen
      Dim result = Me.Context.Database.SqlQuery(Of TModel)(statement.CommandText).ToList
      'ModelCultureCode setzen
      result.ForEach(Sub(x) x.ModelBase.ModelCultureCode = cultureCode)
      Return result
    End Function

    Private Function GetTranslateStatement(ByVal cultureCode As CultureCodes) As Statement
      Dim delimiter = String.Concat(vbCrLf, vbTab)
      Dim sb = New StringBuilder
      sb.Append(String.Concat("SELECT", delimiter))
      AddFieldStringsToStringBuilder(sb, cultureCode, delimiter)
      sb.Append(String.Concat("FROM", delimiter))
      sb.AppendLine(ModelBase.TableName)
      sb.Append(String.Concat("WHERE", delimiter))
      sb.AppendLine(String.Format("(_rowid IN({0}))", GetModelsRowIdString))
      Return New Statement(sb.ToString)
    End Function

    Private Function PropertyValuesEqual _
    (ByVal propertyValue As Object, ByVal propertyValue2 As Object) As Boolean

      Return Serializers.Json.Instance.IsDataEqualTo(Of Object) _
      (propertyValue, propertyValue2)
    End Function


#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
    '''<summary></summary>
    Public Function TranslateModels(ByVal cultureCode As CultureCodes) As IEnumerable(Of TModel)

      If _models.Any Then
        Return GetModelsFromDatabaseAndSetModelCultureCode _
        (GetTranslateStatement(cultureCode), cultureCode)
      Else
        Return New List(Of TModel)
      End If
    End Function

    Private Function LocalizedModelsInModels _
    (ByVal localizedModels As IEnumerable(Of TModel)) As Boolean

      Dim modelIds = _models.Select(Function(y) y.RowId).ToList

      Return (Not localizedModels.ToList.Select _
      (Function(x) modelIds.Contains(x.RowId)).Distinct.Contains(False))
    End Function



    '''<summary></summary>
    Public Sub SaveLocalizedModels(ByVal models As IEnumerable(Of TModel))

      If Not models.Any Then Exit Sub

      If Not LocalizedModelsInModels(models) Then
        Dim modelIds = models.Select(Function(x) x.RowId.ToString).EnumerableJoin
        Throw New ModelLocalizerException("Invalid RowId in " & modelIds)
      End If

      If Not Me.ModelBase.GetDefaultRepository.ModelValidator.IsModelCollectionValid(models) Then
        Throw New ModelValidatorException _
        (Me.ModelBase.GetDefaultRepository.ModelValidator.GetModelCollectionValidationErrorMessage(models))
      End If

      Dim statementStrings = New List(Of String)

      For Each m In models

        Dim cachedModel = _models.First(Function(x) x.RowId = m.RowId)

        For Each propertyName In GetLocalizeablePropertyNames()

          Dim cultureCode = GetCultureCodeString(m.ModelBase.ModelCultureCode)
          Dim field = Me.ParseToDatabaseFieldName(propertyName)

          If Not PropertyValuesEqual _
            (cachedModel.ModelCore.GetPropertyValue(cachedModel, propertyName) _
            , m.ModelCore.GetPropertyValue(m, propertyName)) Then

            Dim value = Me.ModelBase.GetPropertyValue(m, propertyName)

            If (value Is Nothing) OrElse (value.ToString.Trim = "") Then
              Dim oldValue = cachedModel.ModelCore.GetPropertyValue(cachedModel, propertyName)
              m.ModelCore.SetPropertyValue(m, propertyName, oldValue)

              statementStrings.Add(String.Format(My.Settings.DeleteLocalization _
              , Me.DatabaseName, Me.TableName, field, m.RowId, cultureCode))
            Else
              statementStrings.Add(String.Format(My.Settings.SetLocalization _
              , Me.DatabaseName, Me.TableName, field, m.RowId, value, cultureCode))
            End If
          Else
            statementStrings.Add(String.Format(My.Settings.DeleteLocalization _
            , Me.DatabaseName, Me.TableName, field, m.RowId, cultureCode))
          End If
        Next propertyName

        For Each propertyName In GetNotLocalizeablePropertyNames()
          Dim value = m.ModelCore.GetPropertyValue(m, propertyName)
          cachedModel.ModelCore.SetPropertyValue(cachedModel, propertyName, value)
        Next propertyName
      Next m

      Me.ModelBase.GetDefaultRepository.UpdateRange(_models)

      Dim statement = New Statement(statementStrings.EnumerableJoin(";" & vbCrLf))
      _lastExecutedStatement = statement

      Me.Context.Database.ExecuteSqlCommand(statement.CommandText)
    End Sub
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace
