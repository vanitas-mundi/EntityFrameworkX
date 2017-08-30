Option Infer On
Option Explicit On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Data.Entity
#End Region

Namespace Contexts.Core.Interfaces

	Public Interface IContextBase(Of TContext As DbContext)

		Function ContextBase() As ContextBase(Of TContext)
	End Interface

End Namespace
