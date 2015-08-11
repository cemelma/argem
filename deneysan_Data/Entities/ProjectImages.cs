using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneysan_DAL.Entities
{
  public class ProjectsGallery
  {
    [Key]
    public int Id { get; set; }

    public int ProjeId { get; set; }
    public string Image { get; set; }
    public string ImageThumb { get; set; }


  }
}
