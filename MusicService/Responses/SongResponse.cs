namespace MusicService.Responses
{
    public class SongResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public byte[] Track { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}
