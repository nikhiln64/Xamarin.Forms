﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Login_model.Validation_Classes
{
    public class MinimumLengthValidation : Behavior<Entry>
    {
        public int MinLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // if Entry text is longer then valid length
            if (entry.Text.Length < this.MinLength)
            {
                string entryText = entry.Text;
                entry.Focus();
            }
        }
    }
}
