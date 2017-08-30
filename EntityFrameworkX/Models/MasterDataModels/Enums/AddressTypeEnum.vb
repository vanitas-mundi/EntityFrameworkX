Option Explicit On
Option Infer On
Option Strict On
Imports SSP.Base.Attributes

#Region " --------------->> Imports/ usings "
#End Region

Namespace Models.MasterDataModels.Enums

    Public Enum AddressTypeEnum
        <EnumDisplayName("Person")>
        Person = 1
        <EnumDisplayName("Firma")>
        Firma = 2
        <EnumDisplayName("Veranstaltungsort")>
        Veranstaltungsort = 3
        <EnumDisplayName("Standort")>
        Standort = 4
        <EnumDisplayName("Campusort")>
        Campusort = 5
        <EnumDisplayName("Vermieteranschrift")>
        Vermieteranschrift = 6
        <EnumDisplayName("Mandant")>
        Mandant = 7
        <EnumDisplayName("Fremdinstitut")>
        Fremdinstitut = 8
    End Enum

End Namespace