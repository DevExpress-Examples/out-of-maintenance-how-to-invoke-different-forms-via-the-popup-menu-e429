using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxMenu;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxScheduler.Commands;
using DevExpress.Web.ASPxScheduler.Internal;

public enum FormType { Form1, Form2, None }
public partial class Default : System.Web.UI.Page {
	FormType formType = FormType.None;
	public FormType FormType { get { return formType; } set { formType = value; } }

	protected void Page_Load(object sender, EventArgs e) {
		DataHelper.SetupMappings(ASPxScheduler1);
		DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource);
		DataSource1.AttachTo(ASPxScheduler1);
	}
	protected void ASPxScheduler1_AppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
		if(formType == FormType.Form1) {
			e.FormTemplateUrl = ResolveUrl("~/UserForms/Form1.ascx");
		}
		else if(formType == FormType.Form2) {
			e.FormTemplateUrl = ResolveUrl("~/UserForms/Form2.ascx");
		}
	}
	protected void ASPxScheduler1_BeforeExecuteCallbackCommand(object sender, SchedulerCallbackCommandEventArgs e) {
		if(e.CommandId == "MYAPTMENU") 
			e.Command = new MyMenuAppointmentCallbackCommand((ASPxScheduler)sender);
	}
	protected void ASPxScheduler1_PreparePopupMenu(object sender, DevExpress.Web.ASPxScheduler.PreparePopupMenuEventArgs e) {
		ASPxSchedulerPopupMenu menu = e.Menu;
		if(menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu) {
			menu.ClientSideEvents.ItemClick = String.Format("function(s, e) {{ DefaultViewMenuHandler({0}, s, e); }}", ASPxScheduler1.ClientInstanceName);
			MenuHelper.AddMenuItem(menu, 1, "Show form1", "ShowForm1");
			MenuHelper.AddMenuItem(menu, 2, "Show form2", "ShowForm2");
		}
	}

}
#region MyMenuAppointmentCallbackCommand
public class MyMenuAppointmentCallbackCommand : MenuAppointmentCallbackCommand {
	FormType formType = FormType.None;

	public MyMenuAppointmentCallbackCommand(ASPxScheduler scheduler)
		: base(scheduler) {
	}

	
	public override string Id { get { return "MYAPTMENU"; } }
	public override bool RequiresControlHierarchy { get { return true; } }
	FormType FormType { get { return formType; } }
	

	
	protected override void ParseParameters(string parameters) {
		if(parameters == "ShowForm1")
			this.formType = FormType.Form1;
		else if(parameters == "ShowForm2")
			this.formType = FormType.Form2;
		base.ParseParameters(parameters);
	}
	
	protected override void ExecuteCore() {
		base.ExecuteCore();
		if(FormType != FormType.None) {
			((Default)Control.Page).FormType = FormType;
			WebEditAppointmentCommand command = new WebEditAppointmentCommand(Control, Control);
			command.Execute();
		}
	}
	
}
#endregion
#region MenuHelper
public class MenuHelper {
	public static void RemoveMenuItem(ASPxSchedulerPopupMenu menu, string menuItemName) {
		DevExpress.Web.ASPxMenu.MenuItem item = menu.Items.FindByName(menuItemName);
		if(item != null)
			menu.Items.Remove(item);
	}
	public static void AddMenuItem(ASPxSchedulerPopupMenu menu, int index, string caption, string menuItemName) {
		MenuItemCollection items = menu.Items;
		MenuItem item = new MenuItem(caption, menuItemName);
		items.Insert(index, item);
	}
}
#endregion
