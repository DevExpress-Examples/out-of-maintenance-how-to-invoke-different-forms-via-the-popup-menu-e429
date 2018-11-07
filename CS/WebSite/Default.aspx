<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="DevExpress.Web.v15.2" Namespace="DevExpress.Web" TagPrefix="dxm" %>

<%@ Register Assembly="DevExpress.XtraScheduler.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v15.2" Namespace="DevExpress.Web.ASPxScheduler"
    TagPrefix="dxwschs" %>

<%@ Register Src="~/DefaultObjectDataSources.ascx" TagName="DefaultObjectDataSources" TagPrefix="dds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dds:DefaultObjectDataSources runat="server" ID="DataSource1" />
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server"  GroupType="Resource" Start="2008-07-18" ClientInstanceName="Scheduler1"
            OnAppointmentFormShowing="ASPxScheduler1_AppointmentFormShowing"
            OnBeforeExecuteCallbackCommand="ASPxScheduler1_BeforeExecuteCallbackCommand"
             OnPopupMenuShowing="ASPxScheduler1_PopupMenuShowing">
            <Views>
                <DayView>
                    <TimeRulers>
                        <cc1:timeruler></cc1:timeruler>
                    </TimeRulers>
                </DayView>
                <WorkWeekView>
                    <TimeRulers>
                        <cc1:timeruler></cc1:timeruler>
                    </TimeRulers>
                </WorkWeekView>
            </Views>
        </dxwschs:ASPxScheduler>
    </div>
    </form>
    <script type="text/javascript">
        function DefaultViewMenuHandler(scheduler, s, e) {
            scheduler.RaiseCallback("MYAPTMENU|" + e.item.name);
        }
    </script>
</body>
</html>
