Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.Runtime.CompilerServices
Imports SSP.Data.EntityFrameworkX.Repositories.MasterDataRepositories
#End Region

Namespace Models.MasterDataModels

	Public Module MasterDataModelsExtensions

#Region " --------------->> Person-Extensions "
		'''<summary>Liefert die Anschriften einer Person.</summary>
		<Extension()>
		Public Function Addresses(ByVal person As Person) As IQueryable(Of Address)

      Return MasterDataRepository.Instance.AddressesRepository.AsQueryable.Where _
      (Function(x) x.PersonId = person.PersonId)
    End Function

		'''<summary>Liefert die Kommunikationsmedien einer Person.</summary>
		<Extension()>
		Public Function Communiations(ByVal person As Person) As IQueryable(Of Communication)

			Return MasterDataRepository.Instance.CommunicationsRepository.AsQueryable.Where _
			(Function(x) x.PersonId = person.PersonId)
		End Function

    '''<summary>Liefert Low- und HighQuality Foto der Person.</summary>
    <Extension()>
    Public Function Photos(ByVal person As Person) As PersonPhoto

      Return MasterDataRepository.Instance.PersonPhotosRepository.GetById(person.PersonId)
    End Function
#End Region

  End Module

End Namespace
