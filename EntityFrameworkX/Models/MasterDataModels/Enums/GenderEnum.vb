Option Explicit On
Option Infer On
Option Strict On
Imports SSP.Base.Attributes

#Region " --------------->> Imports/ usings "
#End Region

Namespace Models.MasterDataModels.Enums

  Public Enum GenderEnum
    <EnumDisplayName("-")>
    Unknown = 1
    <EnumDisplayName("männlich")>
    Male = 2
    <EnumDisplayName("weiblich")>
    Female = 3
  End Enum

End Namespace
