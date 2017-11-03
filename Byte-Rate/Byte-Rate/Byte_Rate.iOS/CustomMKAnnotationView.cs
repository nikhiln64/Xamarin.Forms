using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MapKit;

namespace Byte_Rate.iOS
{
    class CustomMKAnnotationView : MKAnnotationView
    {
        public string name { get; set; }

        public string rating { get; set; }

        public CustomMKAnnotationView(IMKAnnotation annotation, string name)
            : base(annotation, name)
        {
        }
    }
}