using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace hwCORE.model {
    class MainViewModel {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getCPUdetails() {

            string cpuDetails = String.Empty;
            var details = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get();
            foreach (var item in details) {
                cpuDetails = Convert.ToString(item["Name"]);
                cpuDetails += " " + Convert.ToString(item["Description"]);
            }

            return cpuDetails;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getOSdetails() {

            string osDetails = String.Empty;
            var details = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get();
            foreach (var item in details) {
                osDetails = Convert.ToString(item["Caption"]);
                osDetails += "Service Pack " + Convert.ToString(item["ServicePackMajorVersion"]);
            }

            return osDetails;
        }

        public string getGpuDetails() {

            string gpuDetails = String.Empty;

            var details = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get();
            foreach (var item in details) {
                gpuDetails = Convert.ToString(item["Caption"]);
                //gpuDetails += " " + Convert.ToString(item["Description"]);
            }

            return gpuDetails;
        }

        public string getHddDetails() {

            string hddDetails = String.Empty;

            var details = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get();
            
            foreach (var item in details) {
                hddDetails += Convert.ToString(item["Caption"]) + "; ";
                //hddDetails += " " + Convert.ToString(item["Description"]);
            }

            return hddDetails;

        }

        public string getMemoryDetails() {

            //string memDetails = String.Empty;

            long mSize = 0;
            long mCap = 0;
            long mSizeInGB = 0;
            try {

                var details = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory").Get();
                foreach (var item in details) {
                    mCap = Convert.ToInt64(item["Capacity"]);
                    mSize += mCap;    
                }
                mSize = (mSize / 1024) / 1024;
                mSizeInGB = mSize / 1024;

                return mSize.ToString() + " MB " + "("+mSizeInGB+ " GB)";

            }
            catch (ManagementException ex) {

                MessageBox.Show("Błąd! "+ex);
                Application.Exit();
                throw;
            }


            
        }

        public string getMotherboardDetails() {

            string mbDetails = String.Empty;

            var details = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard").Get();

            foreach (var item in details) {
                mbDetails = Convert.ToString(item["Manufacturer"]);
                mbDetails += " " + Convert.ToString(item["Product"]);

            }

            return mbDetails;
        }

        public void copyToClipboardButton(string stringToCopy) {

            Clipboard.SetText(stringToCopy);

        }

    }
}
