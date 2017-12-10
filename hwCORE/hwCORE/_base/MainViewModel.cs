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
            var details = new ManagementObjectSearcher("Select * FROM Win32_Processor").Get();
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
            var details = new ManagementObjectSearcher("Select * FROM Win32_OperatingSystem").Get();
            foreach (var item in details) {
                osDetails = Convert.ToString(item["Name"]);
                osDetails += " Service Pack " + Convert.ToString(item["ServicePackMajorVersion"]);
            }

            return osDetails;
        }
    }
}
