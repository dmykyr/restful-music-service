﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Models
{
    [Keyless]
    public class FavoriteArtist
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
