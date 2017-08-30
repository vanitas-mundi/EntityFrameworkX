Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Repositories.Core
Imports SSP.Data.EntityFrameworkX.Repositories.Test
#End Region

Namespace Models.Test

	Public Module TestModelsExtensions

#Region " --------------->> Person-Extensions "
		<Extension()>
		Public Function Repository(ByVal item As NameModel) As RepositoryBase _
		(Of NameModel, NameModel.PropertyNames, TestContext)

			Return TestRepository.Instance.NamesRepository
		End Function

		<Extension()>
		Public Function Repository(ByVal item As ValueModel) As RepositoryBase _
		(Of ValueModel, ValueModel.PropertyNames, TestContext)

			Return TestRepository.Instance.ValuesRepository
		End Function
#End Region

	End Module

End Namespace
