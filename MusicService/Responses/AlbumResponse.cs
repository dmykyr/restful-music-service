using System.ComponentModel.DataAnnotations;

namespace MusicService.Responses
{
    public class AlbumResponse
    {
        public Guid Id { get; set; }

        public Guid PublisherId { get; set; }

        public string Title { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}
