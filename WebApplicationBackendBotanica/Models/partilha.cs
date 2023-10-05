using System.ComponentModel.DataAnnotations;
namespace WebApplicationBackendBotanica.Models
{
    public class partilha
    {


        [Display(Name = "File Name")]
        public string FileName
        {
            get;
            set;
        }
        [Display(Name = "File Size")]
        public string FileSize
        {
            get;
            set;
        }
        public string Modified
        {
            get;
            set;
        }
    }   
}
