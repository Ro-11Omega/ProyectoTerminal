using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemBiometric
{
    public partial class FormFingerPrintScanner : FormBiometrico
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        private DPFP.Processing.Enrollment Enroller;
        protected override void Init()
        {
            base.Init();
            base.Text = "Registro Biométrico";
            Enroller = new DPFP.Processing.Enrollment();
            showStates();
        }

        private void showStates()
        {
            SetStatus(String.Format("Número de muestras requeridas: {0}.", Enroller.FeaturesNeeded));
        }

        protected override void CaptureSample(DPFP.Sample Sample)
        {
            try
            {
                base.CaptureSample(Sample);
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                if (features != null)
                {
                    AddLog("Muestra obtenida");
                    Enroller.AddFeatures(features);
                }

                showStates();

                switch (Enroller.TemplateStatus)
                {
                    case DPFP.Processing.Enrollment.Status.Ready:
                        OnTemplate?.Invoke(Enroller.Template);
                        SetInstruction("Registro completado, presione el botón Close");
                        EndScan();
                        break;

                    case DPFP.Processing.Enrollment.Status.Failed:
                        Enroller.Clear();
                        EndScan();
                        showStates();
                        OnTemplate?.Invoke(null);
                        BeginScan();
                        break;
                }
            }
            catch (DPFP.Error.SDKException ex)
            {
                MessageBox.Show($"Error en el SDK: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public FormFingerPrintScanner()
        {
            InitializeComponent();
        }

        private void FormFingerPrintScanner_Load(object sender, EventArgs e)
        {
            FormManager.CenterForm(this);
            FormManager.OrangeTheme(this);
        }
    }
}
