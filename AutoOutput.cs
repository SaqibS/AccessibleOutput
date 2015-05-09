namespace AccessibleOutput
{
    using System;
    using System.Linq;

    public class AutoOutput : IAccessibleOutput
    {
        private static readonly IAccessibleOutput[] outputs = { new JawsOutput(), new NvdaOutput(), new SapiOutput() };

        public AutoOutput()
        {
        }

        public bool IsAvailable()
        {
            return outputs.Any(x => x.IsAvailable());
        }

        public void Speak(string text)
        {
            this.Speak(text, false);
        }

        public void Speak(string text, bool interrupt)
        {
            IAccessibleOutput output = this.GetFirstAvailableOutput();

            if (interrupt)
            {
                output.StopSpeaking();
            }

            output.Speak(text);
        }

        public void StopSpeaking()
        {
            IAccessibleOutput output = this.GetFirstAvailableOutput();
            output.StopSpeaking();
        }

        private IAccessibleOutput GetFirstAvailableOutput()
        {
            return outputs.FirstOrDefault(x => x.IsAvailable());
        }
    }
}
