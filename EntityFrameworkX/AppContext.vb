Option Explicit On
Option Infer On
Option Strict On

Imports System.Data.Entity
Imports System.Data.Common
Imports BCW.Foundation.Data.EntityFrameworkHandling.Models.Common
Imports BCW.Foundation.Data.EntityFrameworkHandling.Models.Planing

Namespace Contexts

	Public Class AppContext

		Inherits dbcontext

		Private Shared _instance As AppContext
		Private Shared _base As ContextManager

		Shared Sub New()
			_base = ContextManager.Instance
			_base.SetDbConfiguration(New MySqlEntityProviderServicesConfiguration _
			, New MySqlConnection("host=sql01;uid=apps;pwd=bcw;unicode=true;"))
		End Sub

		Public Shared ReadOnly Property Instance As AppContext
		Get
			Return _instance
		End Get
		End Property

		Public Property Persons As DbSet(Of Person)
		Public Property Bookings As DbSet(Of Booking)

		Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
			CreateModel(modelBuilder)
			MyBase.OnModelCreating(modelBuilder)
		End Sub

		Public Sub CreateModel(ByVal modelBuilder As DbModelBuilder)



			PlaningContext.AddToModelBuilder(modelBuilder)
			CommonContext.AddToModelBuilder(modelBuilder)
		End Sub
	End Class

End Namespace
