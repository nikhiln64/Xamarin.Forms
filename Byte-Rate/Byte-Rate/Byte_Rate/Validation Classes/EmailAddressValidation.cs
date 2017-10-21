using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Byte_Rate.Validation_Classes
{
    class EmailAddressValidation : Behavior<Entry>
    {
       
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";    
            var emailValue = e.NewTextValue;
            var emailEntry = sender as Entry;
            if (emailValue.Contains("@") && emailValue.Contains(".")) {
                if (Regex.IsMatch(emailValue, emailRegex))
                {
                    emailEntry.TextColor = Color.Black;
                }
                else
                {
                    emailEntry.TextColor = Color.Red;
                }
            }else
            {
                emailEntry.TextColor = Color.Black;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }
    }
}
