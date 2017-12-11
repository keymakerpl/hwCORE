using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

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
                gpuDetails += " " + Convert.ToString(item["Description"]);
            }

            return gpuDetails;
        }
    }
}
