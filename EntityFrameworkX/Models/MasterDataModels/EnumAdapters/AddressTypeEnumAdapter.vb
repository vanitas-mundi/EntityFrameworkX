Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
'Bsp: Imports SSP.Data.EntityFrameworkX.Models.MasterDataModels.Enums
#End Region

Namespace Models.MasterDataModels.EnumAdapters

    Public Class AddressTypeEnumAdapter

        Inherits EnumValueAdapterBase(Of AddressTypeEnum)

#Region " --------------->> Enumerationen der Klasse "
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _instance As AddressTypeEnumAdapter
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
            _instance = New AddressTypeEnumAdapter
        End Sub

        Private Sub New()
            Dim initializer = New EnumValueAdapterInitializer(Of AddressTypeEnum)
            initializer.AddToDictionary(AddressTypeEnum.Person, "Person", "Person")
            initializer.AddToDictionary(AddressTypeEnum.Firma, "Firma", "Firma")
            initializer.AddToDictionary(AddressTypeEnum.Veranstaltungsort, "Veranstaltungsort", "Veranstaltungsort")
            initializer.AddToDictionary(AddressTypeEnum.Standort, "Standort", "Standort")
            initializer.AddToDictionary(AddressTypeEnum.Campusort, "Campusort", "Campusort")
            initializer.AddToDictionary(AddressTypeEnum.Vermieteranschrift, "Vermieteranschrift", "Vermieteranschrift")
            initializer.AddToDictionary(AddressTypeEnum.Mandant, "Mandant", "Mandant")
            initializer.AddToDictionary(AddressTypeEnum.Fremdinstitut, "Fremdinstitut", "Fremdinstitut")

            Me.InitializeAdapter(initializer)
        End Sub
#End Region '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
        Public Shared ReadOnly Property Instance As AddressTypeEnumAdapter
            Get
                Return _instance
            End Get
        End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
#End Region '{Öffentliche Methoden der Klasse}

    End Class

End Namespace