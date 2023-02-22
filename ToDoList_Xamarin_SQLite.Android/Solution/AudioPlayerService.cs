using Android.Media;
using ToDoList_Xamarin_SQLite.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToDoList_Xamarin_SQLite.Droid.Solution.AudioPlayerService))]
namespace ToDoList_Xamarin_SQLite.Droid.Solution
{
    public class AudioPlayerService : IAudioPlayerService
    {
        public AudioPlayerService() { }

        MediaPlayer player = new MediaPlayer();
        public void PlayAudioFile(string fileName)
        {
            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
                player.Reset();
                var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
                player.Prepared += (s, e) =>
                {
                    player.Start();
                };
                player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
                player.Prepare();
            }
        }

        public void Stop()
        {
            player.Stop();
            //player.Dispose();
        }

        public void Pause()
        {
            player.Pause();
        }
    }
}
