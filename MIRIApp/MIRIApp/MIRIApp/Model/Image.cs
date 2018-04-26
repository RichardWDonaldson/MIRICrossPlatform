using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MIRIApp.Model
{
   public class Image 
    {
        public Image()
        {
            ImageId = Guid.NewGuid();
        }


        public Guid ImageId { get; set; }

        public ImageSource Source { get; set; }

        public byte[] OrgImage { get; set; }
        
        
    }
}
