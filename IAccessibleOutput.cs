namespace AccessibleOutput
{
    using System;

    public interface IAccessibleOutput
    {
        bool IsAvailable();
        void Speak(string text);
        void Speak(string text, bool interrupt);
        void StopSpeaking();
    }
}
