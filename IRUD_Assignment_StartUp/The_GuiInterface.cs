using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRUD_Assignment_StartUp.AssemblyLines;
using IRUD_Assignment_StartUp.Services;

namespace IRUD_Assignment_StartUp
{
    public partial class The_GuiInterface : Form
    {
        private CarAssemblyLine _carLine;
        private MinibusAssemblyLine _minibusLine;
        private HQ _hq;
        private Timer _updateTimer;

        public The_GuiInterface()
        {
            InitializeComponent();

            _carLine = new CarAssemblyLine();
            _minibusLine = new MinibusAssemblyLine();
            _hq = new HQ(_carLine, _minibusLine);

            _carLine.StatusChanged += OnCarStatusChanged;
            _minibusLine.StatusChanged += OnMinibusStatusChanged;
            Spraybooth.GetInstance().StatusChanged += OnSprayboothStatusChanged;

            _ = Task.Run(() => _carLine.ProcessOrders());
            _ = Task.Run(() => _minibusLine.ProcessOrders());

            _updateTimer = new Timer { Interval = 200 };
            _updateTimer.Tick += OnUpdateTimerTick;
            _updateTimer.Start();

            btnOrder.Click += btnOrder_Click;
        }

        private void OnUpdateTimerTick(object sender, EventArgs e)
        {
            UpdateQueueCounts();
        }

        private void OnCarStatusChanged(string status)
        {
            UpdateLabel(lblCarAssemblyDisp, $"Car Assembly Line: {status}");
        }

        private void OnMinibusStatusChanged(string status)
        {
            UpdateLabel(lblMinibusAssemblyDisp, $"Minibus Assembly Line: {status}");
        }

        private void OnSprayboothStatusChanged(string status)
        {
            UpdateLabel(lblSprayboothDisp, $"Spraybooth: {status}");
        }

        private void UpdateQueueCounts()
        {
            lblCarQCntr.Text = $"{_carLine.OrderCount}";
            lblMinibusQCntr.Text = $"{_minibusLine.OrderCount}";
        }

        private void UpdateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke((MethodInvoker)(() => label.Text = text));
            else
                label.Text = text;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (rbtnBlkLux.Checked)
                _hq.OrderCar("Black");
            else if (rbtnWhiteLux.Checked)
                _hq.OrderCar("White");
            else if (rbtnBlkMV.Checked)
                _hq.OrderMinibus("Black");
            else if (rbtnWhiteMV.Checked)
                _hq.OrderMinibus("White");
            else
                MessageBox.Show("Please select a vehicle type and colour.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void The_GuiInterface_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
