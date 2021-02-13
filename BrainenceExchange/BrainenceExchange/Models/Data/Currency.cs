using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrainenceExchange.Models.Data
{
    public class Currency
    {
        public string Code { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        public static string DefaultPath
        {
            get
            {
                return System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", $"default.png");
            }
        }

        [NotMapped]
        public string Path
        {
            get
            {
                return System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", $"{Picture}");
            }
        }

    }
}
