Option Explicit On
Option Infer On
Option Strict On
Imports System.Collections.ObjectModel

#Region " --------------->> Imports/ usings "
#End Region

Namespace Models.Core.Interfaces

	Public Interface IEnumValueAdapter(Of TEnum As Structure)
		ReadOnly Property EnumValueDictionary As EnumValueAdapterInitializer(Of TEnum)
		ReadOnly Property DisplayValues As ReadOnlyCollection(Of String)
		ReadOnly Property DatabaseValues As ReadOnlyCollection(Of String)
		Function ParseDisplayStringToEnumValue(ByVal value As String) As TEnum
		Function ParseEnumValueToDisplayString(ByVal value As TEnum) As String
		Function ParseDatabaseStringToEnumValue(ByVal value As String) As TEnum
		Function ParseEnumValueToDatabaseString(ByVal value As TEnum) As String
		Function ParseToEnumValue(ByVal value As String) As TEnum
		Sub InitializeAdapter(ByVal initializer As EnumValueAdapterInitializer(Of TEnum))
	End Interface

End Namespace
