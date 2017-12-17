using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hwCORE.model;

namespace hwCORE {
    public partial class MainView : Form {

        private MainViewModel _model = new MainViewModel();

        public MainView() {
            InitializeComponent();
            
        }

        private void MainView_Load(object sender, EventArgs e) {

            cpuTextBox.Text = _model.getCPUdetails();
            osTextBox.Text = _model.getOSdetails();
            gpuTextBox.Text = _model.getGpuDetails();
            hddTextBox.Text = _model.getHddDetails();
            memTextBox.Text = _model.getMemoryDetails();
            mbTextBox.Text = _model.getMotherboardDetails();

        }

        private void button3_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(cpuTextBox.Text);
        }

        private void button4_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(osTextBox.Text);
        }

        private void button5_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(gpuTextBox.Text);
        }

        private void button6_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(hddTextBox.Text);
        }

        private void button7_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(memTextBox.Text);
        }

        private void button8_Click(object sender, EventArgs e) {
            _model.copyToClipboardButton(mbTextBox.Text);
        }
    }
}
