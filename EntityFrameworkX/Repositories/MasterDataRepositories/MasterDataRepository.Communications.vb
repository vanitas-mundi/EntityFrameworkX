Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels
Imports SSP.Data.EntityFrameworkX.Repositories.Core
#End Region

Namespace Repositories.MasterDataRepositories

	Partial Public Class MasterDataRepository

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

		Public Function GetOfficialEmailAdressByPersonId(ByVal personId As Int64) As String

      Return Me.CommunicationsRepository.ExecuteStoredFunction(Of String) _
      ("datapool.GetCommunication", personId, My.Settings.OfficialEmailName)

    End Function

#End Region '{Öffentliche Methoden der Klasse}

	End Class

End Namespace
