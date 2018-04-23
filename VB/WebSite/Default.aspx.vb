Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxMenu
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler.Commands
Imports DevExpress.Web.ASPxScheduler.Internal

Public Enum FormType
	Form1
	Form2
	None
End Enum
Partial Public Class [Default]
	Inherits System.Web.UI.Page
	Private formType_Renamed As FormType = FormType.None
	Public Property FormType() As FormType
		Get
			Return formType_Renamed
		End Get
		Set(ByVal value As FormType)
			formType_Renamed = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		DataHelper.SetupMappings(ASPxScheduler1)
		DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource)
		DataSource1.AttachTo(ASPxScheduler1)
	End Sub
	Protected Sub ASPxScheduler1_AppointmentFormShowing(ByVal sender As Object, ByVal e As AppointmentFormEventArgs)
		If formType_Renamed = FormType.Form1 Then
			e.FormTemplateUrl = ResolveUrl("~/UserForms/Form1.ascx")
		ElseIf formType_Renamed = FormType.Form2 Then
			e.FormTemplateUrl = ResolveUrl("~/UserForms/Form2.ascx")
		End If
	End Sub
	Protected Sub ASPxScheduler1_BeforeExecuteCallbackCommand(ByVal sender As Object, ByVal e As SchedulerCallbackCommandEventArgs)
		If e.CommandId = "MYAPTMENU" Then
			e.Command = New MyMenuAppointmentCallbackCommand(CType(sender, ASPxScheduler))
		End If
	End Sub
	Protected Sub ASPxScheduler1_PreparePopupMenu(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxScheduler.PreparePopupMenuEventArgs)
		Dim menu As ASPxSchedulerPopupMenu = e.Menu
		If menu.Id = DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu Then
			menu.ClientSideEvents.ItemClick = String.Format("function(s, e) {{ DefaultViewMenuHandler({0}, s, e); }}", ASPxScheduler1.ClientInstanceName)
			MenuHelper.AddMenuItem(menu, 1, "Show form1", "ShowForm1")
			MenuHelper.AddMenuItem(menu, 2, "Show form2", "ShowForm2")
		End If
	End Sub

End Class
#Region "MyMenuAppointmentCallbackCommand"
Public Class MyMenuAppointmentCallbackCommand
	Inherits MenuAppointmentCallbackCommand
	Private formType_Renamed As FormType = FormType.None

	Public Sub New(ByVal scheduler As ASPxScheduler)
		MyBase.New(scheduler)
	End Sub

	
	Public Overrides ReadOnly Property Id() As String
		Get
			Return "MYAPTMENU"
		End Get
	End Property
	Public Overrides ReadOnly Property RequiresControlHierarchy() As Boolean
		Get
			Return True
		End Get
	End Property
	Private ReadOnly Property FormType() As FormType
		Get
			Return formType_Renamed
		End Get
	End Property
	

	
	Protected Overrides Sub ParseParameters(ByVal parameters As String)
		If parameters = "ShowForm1" Then
			Me.formType_Renamed = FormType.Form1
		ElseIf parameters = "ShowForm2" Then
			Me.formType_Renamed = FormType.Form2
		End If
		MyBase.ParseParameters(parameters)
	End Sub
	
	
	Protected Overrides Sub ExecuteCore()
		MyBase.ExecuteCore()
		If FormType <> FormType.None Then
			CType(Control.Page, [Default]).FormType = FormType
			Dim command As New WebEditAppointmentCommand(Control, Control)
			command.Execute()
		End If
	End Sub
	
End Class
#End Region
#Region "MenuHelper"
Public Class MenuHelper
	Public Shared Sub RemoveMenuItem(ByVal menu As ASPxSchedulerPopupMenu, ByVal menuItemName As String)
		Dim item As DevExpress.Web.ASPxMenu.MenuItem = menu.Items.FindByName(menuItemName)
		If item IsNot Nothing Then
			menu.Items.Remove(item)
		End If
	End Sub
	Public Shared Sub AddMenuItem(ByVal menu As ASPxSchedulerPopupMenu, ByVal index As Integer, ByVal caption As String, ByVal menuItemName As String)
		Dim items As MenuItemCollection = menu.Items
		Dim item As New MenuItem(caption, menuItemName)
		items.Insert(index, item)
	End Sub
End Class
#End Region
