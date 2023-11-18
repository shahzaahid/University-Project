using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    
        public class ImageResult
        {
            public byte[] ImageBytes { get; set; }
            public string Extension { get; set; }
        }
}
   