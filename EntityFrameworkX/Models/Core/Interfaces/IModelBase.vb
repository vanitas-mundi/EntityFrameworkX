Option Explicit On
Option Infer On
Option Strict On
Imports System.Data.Entity
Imports SSP.Data.EntityFrameworkX.Contexts.Core.Interfaces

#Region " --------------->> Imports/ usings "
#End Region

Namespace Models.Core.Interfaces

	Public Interface IModelBase(Of TModel As {Class, New, IModelBase(Of TModel, TPropertyNames, TContext)} _
	, TPropertyNames As Structure, TContext As {DbContext, IContextBase(Of TContext)})

		Function ModelCore() As ModelCore(Of TModel, TPropertyNames, TContext)
		Function ModelBase() As ModelBase(Of TModel)
		Property RowId As Int64
	End Interface

End Namespace


