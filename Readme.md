<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to invoke different forms via the popup menu


<p>Problem:</p><p>I'd like to customize the popup menu so that it contains additional menu items and clicking on them invokes my custom controls (web forms).</p><p>Solution:</p><p>Explore this example to see how you can accomplish this task. Right-click the appointment to see custom menu items which invoke user forms.<br />
The code uses<a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_PreparePopupMenutopic"> PreparePopupMenu</a> event to modify the default menu, and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxSchedulerASPxScheduler_AppointmentFormShowingtopic">AppointmentFormShowing</a> event to specify the forms to show. The server callback is performed with the MyMenuAppointmentCallbackCommand class instance, inherited from the DevExpress.Web.ASPxScheduler.Internal.MenuAppointmentCallbackCommand class.</p>

<br/>


