Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Base.Attributes
#End Region

Namespace Models.Core.Enums

  Public Enum YesNoEnum
    <EnumDisplayName("Ja")>
    Yes = vbYes
    <EnumDisplayName("Nein")>
    No = vbNo
  End Enum

End Namespace
