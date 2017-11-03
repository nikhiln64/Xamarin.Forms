using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Maps;
using Android.Gms.Maps;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps.Model;
using Byte_Rate.CustomRenderer;
using Byte_Rate.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace Byte_Rate.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> customPins;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            if (pin.Label == "You")
            {
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.personpin));
            }
            else {
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.placepin));
            }
            return marker;
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            if (!string.IsNullOrWhiteSpace(customPin.name))
            {
                var url = Android.Net.Uri.Parse(customPin.name);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (customPin.name == "You")
                {
                    view = inflater.Inflate(Resource.Layout.UserInfoWindow, null);
                    var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);

                    if (infoTitle != null)
                    {
                        infoTitle.Text = customPin.name;
                    }

                    return view;
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.RestaurentDetailsInfo, null);
                    var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                    var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                    if (infoTitle != null)
                    {
                        infoTitle.Text = customPin.name;
                    }
                    if (infoSubtitle != null)
                    {
                        infoSubtitle.Text = "Rating: " + customPin.rating + "  " + customPin.available;
                    }

                    return view;
                }

                
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            if (customPins != null) {
                foreach (var pin in customPins)
                {
                    if (pin.Position == position)
                    {
                        return pin;
                    }
                }
            }
            return null;
        }
    }
}