using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taller_be.Models
{
    public class ServiceCMS
    {
        public static object getAbout()
        {
            Dictionary<string, string> about = new Dictionary<string, string>();

            about.Add("titulo", Resources.Textos.about_titulo);
            about.Add("texto", Resources.Textos.about_texto);

            return about;
        }
    }
}
