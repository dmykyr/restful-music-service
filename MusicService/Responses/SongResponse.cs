﻿namespace MusicService.Responses
{
    public class SongResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Track { get; set; }

        public string Base64Image { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}
