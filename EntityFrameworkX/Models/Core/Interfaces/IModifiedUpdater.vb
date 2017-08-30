Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
#End Region

Namespace Models.Core.Interfaces

	Public Interface IModifiedUpdater

		'''<summary>Erfasst-User-Id.</summary>
		Property CreationUserId As Int64
		'''<summary>Erfasst-Datum.</summary>
		Property CreationDate As DateTime

		'''<summary>Geändert-User-Id.</summary>
		Property ManipulationUserId As Int64
		'''<summary>Geändert-Datum.</summary>
		Property ManipulationDate As DateTime?
	End Interface

End Namespace

