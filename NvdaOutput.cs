namespace AccessibleOutput
{
    using System;
    using System.Runtime.InteropServices;

    public class NvdaOutput : IAccessibleOutput
    {
        public NvdaOutput()
        {
        }

        public bool IsAvailable()
        {
            if (Environment.Is64BitProcess)
            {
                return NativeMethods64.nvdaController_testIfRunning() == 0;
            }
            else
            {
                return NativeMethods32.nvdaController_testIfRunning() == 0;
            }
        }

        public void Speak(string text)
        {
            this.Speak(text, false);
        }

        public void Speak(string text, bool interrupt)
        {
            if (interrupt)
            {
                this.StopSpeaking();
            }

            if (Environment.Is64BitProcess)
            {
                NativeMethods64.nvdaController_speakText(text);
            }
            else
            {
                NativeMethods32.nvdaController_speakText(text);
            }
        }

        public void StopSpeaking()
        {
            if (Environment.Is64BitProcess)
            {
                NativeMethods64.nvdaController_cancelSpeech();
            }
            else
            {
                NativeMethods32.nvdaController_cancelSpeech();
            }
        }

        internal static class NativeMethods32
        {
            [DllImport("nvdaControllerClient32.dll")]
            internal static extern int nvdaController_testIfRunning();

            [DllImport("nvdaControllerClient32.dll")]
            internal static extern int nvdaController_speakText(string text);

            [DllImport("nvdaControllerClient32.dll")]
            internal static extern int nvdaController_cancelSpeech();
        }

        internal static class NativeMethods64
        {
            [DllImport("nvdaControllerClient64.dll")]
            internal static extern int nvdaController_testIfRunning();

            [DllImport("nvdaControllerClient64.dll")]
            internal static extern int nvdaController_speakText(string text);

            [DllImport("nvdaControllerClient64.dll")]
            internal static extern int nvdaController_cancelSpeech();
        }
    }
}
