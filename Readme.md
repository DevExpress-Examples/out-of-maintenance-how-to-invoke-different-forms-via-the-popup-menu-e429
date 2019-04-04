<!-- default file list -->
*Files to look at*:

* [CustomEvents.cs](./CS/WebSite/App_Code/CustomEvents.cs) (VB: [CustomEvents.vb](./VB/WebSite/App_Code/CustomEvents.vb))
* [CustomResources.cs](./CS/WebSite/App_Code/CustomResources.cs) (VB: [CustomResources.vb](./VB/WebSite/App_Code/CustomResources.vb))
* [DataHelper.cs](./CS/WebSite/App_Code/DataHelper.cs) (VB: [DataHelper.vb](./VB/WebSite/App_Code/DataHelper.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
* [DefaultObjectDataSources.ascx](./CS/WebSite/DefaultObjectDataSources.ascx) (VB: [DefaultObjectDataSources.ascx](./VB/WebSite/DefaultObjectDataSources.ascx))
* [DefaultObjectDataSources.ascx.cs](./CS/WebSite/DefaultObjectDataSources.ascx.cs) (VB: [DefaultObjectDataSources.ascx.vb](./VB/WebSite/DefaultObjectDataSources.ascx.vb))
* [Form1.ascx](./CS/WebSite/UserForms/Form1.ascx) (VB: [Form1.ascx](./VB/WebSite/UserForms/Form1.ascx))
* [Form1.ascx.cs](./CS/WebSite/UserForms/Form1.ascx.cs) (VB: [Form1.ascx.vb](./VB/WebSite/UserForms/Form1.ascx.vb))
* [Form2.ascx](./CS/WebSite/UserForms/Form2.ascx) (VB: [Form2.ascx](./VB/WebSite/UserForms/Form2.ascx))
* [Form2.ascx.cs](./CS/WebSite/UserForms/Form2.ascx.cs) (VB: [Form2.ascx.vb](./VB/WebSite/UserForms/Form2.ascx.vb))
<!-- default file list end -->
# How to invoke different forms via the popup menu


<p>Problem:</p><p>I'd like to customize the popup menu so that it contains additional menu items and clicking on them invokes my custom controls (web forms).</p><p>Solution:</p><p>Explore this example to see how you can accomplish this task. Right-click the appointment to see custom menu items which invoke user forms.<br />
The code uses<a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_PreparePopupMenutopic"> PreparePopupMenu</a> event to modify the default menu, and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_AppointmentFormShowingtopic">AppointmentFormShowing</a> event to specify the forms to show. The server callback is performed with the MyMenuAppointmentCallbackCommand class instance, inherited from the DevExpress.Web.ASPxScheduler.Internal.MenuAppointmentCallbackCommand class.</p>

<br/>


