﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; }
        public string? FileDscription { get; set; } 
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
