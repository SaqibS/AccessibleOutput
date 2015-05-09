namespace AccessibleOutput
{
    using System;
    using System.Speech.Synthesis;

    public class SapiOutput : IAccessibleOutput
    {
        private SpeechSynthesizer synth;

        public SapiOutput()
        {
            this.synth = new SpeechSynthesizer();
        }

        public bool IsAvailable()
        {
            return true;
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

            this.synth.SpeakAsync(text);
        }

        public void StopSpeaking()
        {
            this.synth.SpeakAsyncCancelAll();
        }
    }
}
