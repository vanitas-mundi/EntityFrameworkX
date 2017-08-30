Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
Imports SSP.Data.EntityFrameworkX.Repositories.Core
#End Region

Namespace Models.Core

	'''<summary></summary>
	'''<typeparam name="TPropertyNames"></typeparam>
	'''<remarks>https://msdn.microsoft.com/de-de/data/jj591617.aspx</remarks>
	Public Class ModelCore(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
	, TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
		Private _mappingInformations As New Dictionary(Of TPropertyNames, String)
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
		Public Sub New(ByVal tableName As String)
			_TableName = tableName
		End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
		Public Property TableName As String
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
		Public Function GetPropertyValue _
		(ByVal contextModel As TModel, ByVal propertyName As TPropertyNames) As Object

			Return contextModel.GetType.InvokeMember _
			(propertyName.ToString, Reflection.BindingFlags.GetProperty, Nothing, contextModel, Nothing)
		End Function

		Public Sub SetPropertyValue _
		(ByVal contextModel As TModel, ByVal propertyName As TPropertyNames, ByVal value As Object)

			contextModel.GetType.InvokeMember _
			(propertyName.ToString, Reflection.BindingFlags.SetProperty, Nothing, contextModel, New Object() {value})
		End Sub

		Public Function GetPrimaryKeyPropertyName() As TPropertyNames
			Return GetPropertyName(0)
		End Function

		Public Function GetPrimaryKeyDatabaseField() As String
			Return GetDatabaseFieldName(0)
		End Function

		Public Function GetDatabaseFieldName(ByVal propertyName As TPropertyNames) As String
			Return _mappingInformations.Item(propertyName)
		End Function

		Public Function GetDatabaseFieldName(ByVal index As Int32) As String
			Return System.Enum.GetName(GetType(TPropertyNames), index)
		End Function

		Public Function GetPropertyNames() As TPropertyNames()
			Return System.Enum.GetValues(GetType(TPropertyNames)).OfType(Of TPropertyNames).ToArray
		End Function

		Public Function GetPropertyName(ByVal databaseFieldName As String) As TPropertyNames
			Return _mappingInformations.Where _
			(Function(item) String.Compare(item.Value, databaseFieldName, True) = 0).First.Key
		End Function

		Public Function GetPropertyName(ByVal index As Int32) As TPropertyNames
			Return GetPropertyName(GetDatabaseFieldName(index))
		End Function

		Public Sub AddMappingInformation(ByVal propertyName As TPropertyNames, ByVal databaseFieldName As String)
			_mappingInformations.Add(propertyName, databaseFieldName)
		End Sub

		Public Sub AddToModelBuilder(ByVal modelBuilder As DbModelBuilder)

			With modelBuilder.Entity(Of TModel)()
				For Each key In _mappingInformations.Keys
					.ToTable(Me.TableName)
					Dim propertyName = key

					modelBuilder.Properties.Where(Function(p) p.DeclaringType Is GetType(TModel) _
					AndAlso p.Name.Equals(propertyName.ToString)).Configure _
					(Function(c) c.HasColumnName(GetDatabaseFieldName(propertyName)))
				Next key
			End With
		End Sub

		Public Function GetDefaultContext() As TContext
			Return ContextManager.Instance.CreateContext(Of TContext)
		End Function

		Public Function GetDefaultRepository() As RepositoryBase _
		(Of TModel, TPropertyNames, TContext)

			Return New RepositoryBase(Of TModel, TPropertyNames, TContext)
		End Function

#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace

