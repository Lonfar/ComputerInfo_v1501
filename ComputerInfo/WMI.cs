using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Data;

namespace ComputerInfo
{
    public class WMIInfo
    {
        public string GetCPUInfo()
        {
            string info = "";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in osDetailsCollection)
            {
                info += "CPU信息： " + MangementObj["Name"];
            }
            return info;
        }
        public string GetNetworkInfo()
        {
            string info = "";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in osDetailsCollection)
            {
                if (MangementObj["IPAddress"] != null)
                {
                    if (MangementObj["IPAddress"] is Array)
                    {
                        string[] addresses = (string[])MangementObj["IPAddress"];
                        info += "IP地址： ";
                        foreach (string IP in addresses)
                        {
                            info += IP + "\t";
                        }
                        info += "\r" + "MAC地址： " + MangementObj["MACAddress"];
                    }
                    else
                    {
                        info += "IP地址： " + MangementObj["IPAddress"] + "\r"
                                + "MAC地址： " + MangementObj["MacAddress"];
                    }
                }
            }
            return info;
        }
        public string GetOSInfo()
        {
            string info = "";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject OperatingSystem in osDetailsCollection)
            {
                info += "操作系统： " + OperatingSystem["Caption"] + "\r"
                       + "剩余物理内存： " + Convert.ToInt16((Convert.ToDouble(OperatingSystem["FreePhysicalMemory"]) / 1024) / 1024) + " GB \r"
                       + "总物理内存： " + Convert.ToInt16((Convert.ToDouble(OperatingSystem["TotalVisibleMemorySize"]) / 1024) / 1024) + " GB";
            }
            return info;
        }
        public string GetMainboard()
        {
            string info = "";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject OperatingSystem in objOSDetails.Get())
            {
                info = "主板制造商：" + OperatingSystem["Manufacturer"].ToString() + "\r";
                info += "型号：" + OperatingSystem["Product"].ToString() + "\r";
                info += "序列号：" + OperatingSystem["SerialNumber"].ToString();
            }
            return info;
        }
        public string GetDiskInfo()
        {
            String info = "";
            int i = 1;
            ManagementClass objClass = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection objCollection = objClass.GetInstances();
            foreach (ManagementObject MangementObj in objCollection)
            {
                info += "No." + i + "硬盘信息：";
                info += MangementObj.Properties["Model"].Value.ToString() + "\r";
                i++;
            }
            return info;
        }
        public string GetDiskSize()
        {
            String info = "";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectCollection objCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in objCollection)
            {
                if (MangementObj["DriveType"].ToString() == "3")
                {
                    info += string.Format("盘符：{0},文件系统：{1},总容量：{2},剩余容量：{3} \r", MangementObj["Name"].ToString(),
                       MangementObj["FileSystem"],
                       Convert.ToInt16((Convert.ToInt64(Convert.ToDouble(MangementObj["Size"]) / 1024) / 1024) / 1024).ToString() + "GB",
                       Convert.ToInt16((Convert.ToInt64(Convert.ToDouble(MangementObj["FreeSpace"]) / 1024) / 1024) / 1024).ToString() + "GB");
                }
            }
            return info;
        }
        public string GetCDROM()
        {
            String info = "DVD/CD-ROM驱动器：";
            ManagementObjectSearcher objClass = new ManagementObjectSearcher("SELECT  * FROM Win32_CDROMDrive");
            ManagementObjectCollection objCollection = objClass.Get();
            foreach (ManagementObject MangementObj in objCollection)
            {
                info += MangementObj.Properties["NAME"].Value.ToString();
            }
            return info;
        }
        public string GetSoundDevice()
        {
            string info = "声卡设备：";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT  * FROM Win32_SoundDevice");
            ManagementObjectCollection objCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in objCollection)
            {
                info += MangementObj.Properties["NAME"].Value.ToString();
            }
            return info;
        }
        public string GetVideoController()
        {
            string info = "";
            int i = 1;
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT  * FROM Win32_VideoController");
            ManagementObjectCollection objCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in objCollection)
            {
                info += "No." + i + "显卡设备：";
                info += MangementObj.Properties["NAME"].Value.ToString() + "\r";
                i++;
            }
            return info;
        }
        public string Get()
        {
            string info = "网卡设备：";
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher("SELECT  * FROM Win32_NetworkAdapter");
            ManagementObjectCollection objCollection = objOSDetails.Get();
            foreach (ManagementObject MangementObj in objCollection)
            {
                info += MangementObj.Properties["NAME"].Value.ToString() + "\r";
            }
            return info;
        }
    }
}
