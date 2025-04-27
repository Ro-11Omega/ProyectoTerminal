using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemBiometric
{
    delegate void Function();

    public partial class FormBiometrico : Form, DPFP.Capture.EventHandler
	{
        private DPFP.Capture.Capture biometricCapture;
        public FormBiometrico()
		{
			InitializeComponent();
        }

        #region Iniciar y Cerrar FormBiometrico

        private void FormBiometrico_Load(object sender, EventArgs e)
        {
            Init();
            BeginScan();
        }

        private void FormBiometrico_FormClosed(object sender, FormClosedEventArgs e)
        {
            EndScan();
        }
        #endregion

        #region Instanciar DPFP.Capture.Capture(SDK)
        protected virtual void Init()
        {
            try
            {
                biometricCapture = new DPFP.Capture.Capture(); // SDK DPFP.Capture.Capture

                if (null != biometricCapture)
                    biometricCapture.EventHandler = this;
                else
                    SetInstruction("Problema al instanciar el lector biométrico.");
            }
            catch
            {
                MessageBox.Show("Problema al instanciar el lector biométrico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Iniciar y Detener Scanner StartCapture(SDK) Y StopCapture(SDK)

        protected void BeginScan()
        {
            if (null != biometricCapture)
            {
                try
                {
                    biometricCapture.StartCapture(); //Funcion SDK
                    SetInstruction("Coloque su dedo en el lector biométrico.");
                }
                catch
                {
                    SetInstruction("Problema al iniciar la operación captura.");
                }
            }
        }

        protected void EndScan()
        {
            if (null != biometricCapture)
            {
                try
                {
                    biometricCapture.StopCapture(); //Funcion SDK
                }
                catch
                {
                    SetInstruction("Ocurrio un problema al detener la operación captura.");
                }
            }
        }

        #endregion

        #region Class DPFP.Capture.EventHandler SDK

        #region Captura exitosa SDK OnComplete

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
		{
			AddLog("Muestra dactilar capturada correctamente");
			SetInstruction("Vuelve a colocar el mismo dedo en el lector biométrico");
			CaptureSample(Sample);
		}

        #endregion

        #region Lector tocado y dedo retirado SDK OnFingerGone Y OnFingerTouch
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
		{
			AddLog("El usuario ha retirado su dedo del lector biométrico.");
		}

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
		{
			AddLog("El usuario ha tocado el lector biométrico.");
		}

        #endregion

        #region Dispositivo conectado y desconectado SDK OnReaderConnect Y OnReaderDisconnect
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
		{
			AddLog("El Lector biométrico está conectado.");
		}

		public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
		{
			AddLog("El Lector biométrico está desconectado.");
		}

        #endregion

        #region Calidad de muestra SDK OnSampleQuality

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
		{
			if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
				AddLog("Calidad de muestra: Alta");
			else
				AddLog("Calidad de muestra: Baja");
		}

        #endregion

        #endregion

        protected virtual void CaptureSample(DPFP.Sample Sample)
        {
            showPicture(ConversionSampleToBitmap(Sample));
        }

        protected Bitmap ConversionSampleToBitmap(DPFP.Sample Sample)
		{
			DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
			Bitmap bitmap = null;
			Convertor.ConvertToPicture(Sample, ref bitmap); //SDK
			return bitmap;
		}

		protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
		{
			DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
			DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
			DPFP.FeatureSet features = new DPFP.FeatureSet(); //SDK
			Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
			if (feedback == DPFP.Capture.CaptureFeedback.Good)
				return features;
			else
				return null;
		}

        #region Mostrar mensajes e imagenes
        protected void SetStatus(string status)
        {
            if (LabelStates.InvokeRequired)
            {
                LabelStates.BeginInvoke(new Action(() => LabelStates.Text = status));
            }
            else
            {
                LabelStates.Text = status;
            }
        }

        protected void SetInstruction(string new_instruction)
        {
            if (TBoxInstruction.InvokeRequired)
            {
                TBoxInstruction.BeginInvoke(new Action(() => TBoxInstruction.Text = new_instruction));
            }
            else
            {
                TBoxInstruction.Text = new_instruction;
            }
        }

        protected void AddLog(string message)
        {
            if (TBoxStatus.InvokeRequired)
            {
                TBoxStatus.BeginInvoke(new Action(() => TBoxStatus.AppendText(message + "\r\n")));
            }
            else
            {
                TBoxStatus.AppendText(message + "\r\n");
            }
        }

        private void showPicture(Bitmap bitmap)
        {
            if (PBox.InvokeRequired)
            {
                PBox.BeginInvoke(new Action(() => PBox.Image = new Bitmap(bitmap, PBox.Size)));
            }
            else
            {
                PBox.Image = new Bitmap(bitmap, PBox.Size);
            }
        }

        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
			this.Hide();
        }
    }
}