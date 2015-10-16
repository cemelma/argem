using deneysan_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneysan_Data.Entities
{
  public class ProjectGroup
  {
    [Key]
    public int ProjectGroupId { get; set; }

    [Required(ErrorMessage = "Grup Adını Giriniz")]
    [Display(Name = "Grup Adı")]
    public string GroupName { get; set; }

  

    public bool Online { get; set; }
  

    public virtual ICollection<Projects>Projects { get; set; }

    [Required(ErrorMessage = "Dili Seçiniz.")]
    public string Language { get; set; }
    public string PageSlug { get; set; }
    public int SortNumber { get; set; }
  }
}
