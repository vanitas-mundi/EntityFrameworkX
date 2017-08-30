Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Text
#End Region

Namespace Core

	Public Class ModelTemplateBuilder

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}
		Private _propertyNames As New List(Of String)
		Private _properties As New List(Of ModelProperty)
		Private _nameSpace As String
		Private _modelName As String
		Private _tableName As String

		Public Sub New(ByVal modelName As String, ByVal tableName As String)
			Me.New(modelName, tableName, "")
		End Sub

		Public Sub New(ByVal modelName As String, ByVal tableName As String, ByVal [nameSpace] As String)
			_modelName = modelName.Trim
			_tableName = tableName.Trim
			_nameSpace = [nameSpace].Trim
		End Sub

		Public Sub AddProperty(ByVal prop As ModelProperty)
			_properties.Add(prop)
		End Sub

		Public Sub SaveTemplate(ByVal fileName As String)

			My.Computer.FileSystem.WriteAllText(fileName, Me.BuildTemplate, False, Encoding.Default)
		End Sub

		Public Function GenerateFileName(ByVal basePath As String) As String
			With My.Computer.FileSystem
				Dim path = basePath

				If Not (basePath.EndsWith("\Models", StringComparison.CurrentCultureIgnoreCase) _
				OrElse basePath.EndsWith("\Models\", StringComparison.CurrentCultureIgnoreCase)) Then
					path = .CombinePath(basePath, "Models")
				End If

				If _nameSpace.Length > 0 Then path = .CombinePath(path, _nameSpace)

				Return .CombinePath(path, String.Concat(_modelName, ".vb"))
			End With
		End Function

		Public Function BuildTemplate() As String
			Dim template = New StringBuilder(My.Settings.ModelTemplate)
			template.Replace("<Namespace>", If(String.IsNullOrWhiteSpace(_nameSpace), "", String.Concat(".", _nameSpace)))
			template.Replace("<ModelName>", _modelName)
			template.Replace("<TableName>", _tableName)
			Dim propertyNames = String.Join(vbCrLf, _properties.Select(Function(p) String.Format("{0}{0}{0}{1}", vbTab, p.Name)).ToArray)
			template.Replace("<PropertyNames>", propertyNames)

			Dim sb = New StringBuilder
			Dim mappingInformations = New StringBuilder
			Dim mask = "{0}{0}{0}_modelBase.AddMappingInformation(PropertyNames.{1}, ""{2}"")"
			For Each prop In _properties
				sb.AppendLine(String.Format("{0}{0}'''<summary>{1}</summary>", vbTab, prop.Summery))

				Dim typeName = String.Concat(prop.TypeName.ToString.Split("."c).Last, If(prop.AllowNull, "?", ""))
				sb.AppendLine(String.Format("{0}{0}Public Property {1} As {2}", vbTab, prop.Name, typeName))

				mappingInformations.AppendLine(String.Format(mask, vbTab, prop.Name, prop.DatabaseFieldName))
			Next
			template.Replace("<Properties>", sb.ToString)
			template.Replace("<MappingInformations>", mappingInformations.ToString)

			Return template.ToString
		End Function

		Public Overrides Function ToString() As String
			Return Me.BuildTemplate
		End Function
	End Class

	Public Class ModelProperty
		Public Property Name As String
		Public Property DatabaseFieldName As String
		Public Property Summery As String
		Public Property TypeName As TypeCode
		Public Property AllowNull As Boolean = False
	End Class

End Namespace
