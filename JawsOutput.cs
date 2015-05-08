namespace AccessibleOutput
{
    using System;
    using FSAPILib;

    public class JawsOutput : IAccessibleOutput
    {
        private IJawsApi api;

        public JawsOutput()
        {
            this.api = new JawsApi();
        }

        public bool IsAvailable()
        {
            return this.api.SayString(string.Empty);
        }

        public void Speak(string text)
        {
            this.Speak(text, false);
        }

        public void Speak(string text, bool interrupt)
        {
            this.api.SayString(text, interrupt);
        }

        public void StopSpeaking()
        {
            this.api.StopSpeech();
        }
    }
}
