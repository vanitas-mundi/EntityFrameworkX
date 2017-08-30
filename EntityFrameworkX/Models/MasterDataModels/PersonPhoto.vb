Option Explicit On
Option Infer On
Option Strict On

#Region " --------------->> Imports/ usings "
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports SSP.Base.Attributes
Imports SSP.Data.EntityFrameworkX.Contexts
Imports SSP.Data.EntityFrameworkX.Models.Core
Imports SSP.Data.EntityFrameworkX.Models.Core.Interfaces
#End Region

Namespace Models.MasterDataModels

  Partial Public Class PersonPhoto

    Inherits ModelBase(Of PersonPhoto)
    Implements IModelBase(Of PersonPhoto, PropertyNames, MasterDataContext)

#Region " --------------->> Enumerationen der Klasse "
        Public Enum PropertyNames
            RowId
            PersonPhotoId
            PersonId
            LowQualityImage
            HighQualityImage
            Angelegt
        End Enum
#End Region '{Enumerationen der Klasse}

#Region " --------------->> Eigenschaften der Klasse "
        Private Shared _modelCore As ModelCore(Of PersonPhoto, PropertyNames, MasterDataContext)

    Private _rowId As Int64
    Private _personPhotoId As Int64
    Private _personId As Int64?
    Private _lowQualityImage As Byte()
        Private _highQualityImage As Byte()
        Private _angelegt As DateTime = DateTime.Now
#End Region '{Eigenschaften der Klasse}

#Region " --------------->> Konstruktor und Destruktor der Klasse "
        Shared Sub New()
      _modelCore = New ModelCore(Of PersonPhoto, PropertyNames, MasterDataContext)("datapool.t_photos")
      _modelCore.AddMappingInformation(PropertyNames.RowId, My.Settings.RowIdName)
      _modelCore.AddMappingInformation(PropertyNames.PersonPhotoId, "PhotoId")
      _modelCore.AddMappingInformation(PropertyNames.PersonId, "PersonenFID")
      _modelCore.AddMappingInformation(PropertyNames.LowQualityImage, "Picture")
            _modelCore.AddMappingInformation(PropertyNames.HighQualityImage, "PictureHQ")
            _modelCore.AddMappingInformation(PropertyNames.Angelegt, "Angelegt")
        End Sub
#End Region  '{Konstruktor und Destruktor der Klasse}

#Region " --------------->> Zugriffsmethoden der Klasse "
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <ViewGenerator(IsBrowseable:=False)>
    Public Property RowId As Int64 Implements IModelBase _
    (Of PersonPhoto, PropertyNames, MasterDataContext).RowId
      Get
        Return _rowId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.RowId), _rowId, value)
      End Set
    End Property

    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    <ViewGenerator(CustomViewOrder:=1, DisplayName:="Personen-Foto-Id.", IsBrowseable:=False)>
    Public Property PersonPhotoId As Int64
      Get
        Return _personPhotoId
      End Get
      Set(value As Int64)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64)(NameOf(Me.PersonPhotoId), _personPhotoId, value)
      End Set
    End Property

    <ViewGenerator(CustomViewOrder:=2, DisplayName:="Personen-Id.", IsBrowseable:=False)>
    Public Property PersonId As Int64?
      Get
        Return _personId
      End Get
      Set(value As Int64?)
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Int64?)(NameOf(Me.PersonId), _personId, value)
      End Set
    End Property

    <ViewGenerator(CustomViewOrder:=3, DisplayName:="Foto" _
    , ViewType:=ViewTypes.Image, ToolTipText:="Foto der Person bis zu einer Größe von 20KB.")>
    Public Property LowQualityImage As Byte()
      Get
        Return _lowQualityImage
      End Get
      Set(value As Byte())
        MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Byte())(NameOf(Me.LowQualityImage), _lowQualityImage, value)
      End Set
    End Property

        <ViewGenerator(CustomViewOrder:=4, DisplayName:="Foto-HQ", IsBrowseable:=False _
    , ViewType:=ViewTypes.Image, ToolTipText:="High-Quality-Foto der Person mit uneingeschränkter Größe.")>
        Public Property HighQualityImage As Byte()
            Get
                Return _highQualityImage
            End Get
            Set(value As Byte())
                MyBase.SetPropertyValueAndRaisePropertyChanged _
        (Of Byte())(NameOf(Me.HighQualityImage), _highQualityImage, value)
            End Set
        End Property

        <Required>
        Public Property Angelegt As DateTime
            Get
                Return _angelegt
            End Get
            Set(value As DateTime)
                MyBase.SetPropertyValueAndRaisePropertyChanged _
                (Of DateTime)(NameOf(Me.Angelegt), _angelegt, value)
            End Set
        End Property
#End Region '{Zugriffsmethoden der Klasse}

#Region " --------------->> Ereignismethoden Methoden der Klasse "
#End Region '{Ereignismethoden der Klasse}

#Region " --------------->> Private Methoden der Klasse "
#End Region '{Private Methoden der Klasse}

#Region " --------------->> Öffentliche Methoden der Klasse "
        Public Overrides Function ToString() As String
      Return NameOf(PersonPhoto)
    End Function

    Public Shared Function GetModelCore() As ModelCore _
    (Of PersonPhoto, PropertyNames, MasterDataContext)
      Return _modelCore
    End Function

    Private Function IModelBase_ModelCore() As ModelCore(Of PersonPhoto, PropertyNames, MasterDataContext) _
    Implements IModelBase(Of PersonPhoto, PropertyNames, MasterDataContext).ModelCore
      Return _modelCore
    End Function

    Private Function IModelBase_ModelBase() As ModelBase(Of PersonPhoto) _
    Implements IModelBase(Of PersonPhoto, PropertyNames, MasterDataContext).ModelBase
      Return DirectCast(Me, ModelBase(Of PersonPhoto))
    End Function
#End Region '{Öffentliche Methoden der Klasse}

  End Class

End Namespace