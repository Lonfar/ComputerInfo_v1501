using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                WMIInfo wmi = new WMIInfo();
                Label1.Text = wmi.GetCPUInfo() + "</br>";
                Label1.Text += wmi.GetMainboard() + "</br>";
                Label1.Text += wmi.GetNetworkInfo() + "</br>";
                Label1.Text += wmi.GetOSInfo() + "</br>";
                Label1.Text += wmi.GetDiskInfo() + "</br>";
                Label1.Text += wmi.GetDiskSize() + "</br>";
                Label1.Text += wmi.GetCDROM() + "</br>";
                Label1.Text += wmi.GetSoundDevice() + "</br>";
                Label1.Text += wmi.GetVideoController() + "</br>";
                Label1.Text += wmi.Get() + "</br>";
            }
        }
    }
}