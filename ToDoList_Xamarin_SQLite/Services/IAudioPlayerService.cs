namespace ToDoList_Xamarin_SQLite.Services
{
    public interface IAudioPlayerService
    {
        void PlayAudioFile(string fileName);
        void Stop();
        void Pause();
    }
}
