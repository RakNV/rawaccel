﻿using grapher.Models.Options;
using System;
using System.Windows.Forms;

namespace grapher
{
    public class OptionXY : OptionBase
    {
        #region Constructors
        public OptionXY(FieldXY fields, Label label, ActiveValueLabelXY activeValueLabels)
        {
            Fields = fields;
            Label = label;
            ActiveValueLabels = activeValueLabels;
            ActiveValueLabels.Left = fields.CombinedWidth + fields.Left;
        }

        public OptionXY(
            TextBox xBox,
            TextBox yBox,
            CheckBox lockCheckBox,
            Form containingForm,
            double defaultData,
            Label label,
            ActiveValueLabelXY activeValueLabels)
            : this(new FieldXY(xBox, yBox, lockCheckBox, containingForm, defaultData), label, activeValueLabels)
        {
        }

        public OptionXY(
            TextBox xBox,
            TextBox yBox,
            CheckBox lockCheckBox,
            Form containingForm,
            double defaultData,
            Label label,
            ActiveValueLabelXY activeValueLabels,
            string startingName):
            this(
                xBox,
                yBox,
                lockCheckBox,
                containingForm,
                defaultData,
                label,
                activeValueLabels)
        {
            SetName(startingName);
        }

        #endregion Constructors

        #region Properties

        public FieldXY Fields { get; }

        public Label Label { get; }

        public ActiveValueLabelXY ActiveValueLabels { get; }

        public override int Top
        {
            get
            {
                return Fields.Top;
            }
            set
            {
                Fields.Top = value;
            }
        }

        public override int Height
        {
            get
            {
                return Fields.Height;
            }
        }

        public override int Left
        {
            get
            {
                return Fields.Left;
            }
            set
            {
                Fields.Left = value;
            }
        }

        public override int Width 
        {
            get
            {
                return Fields.Width;
            }
            set
            {
                Fields.Width = value;
            }
        }

        public override bool Visible
        {
            get
            {
                return Fields.Visible;
            }
        }
        #endregion Properties

        #region Methods

        public void SetName(string name)
        {
            Label.Text = name;
            //Label.Left = Convert.ToInt32((Fields.XField.Box.Left / 2.0) - (Label.Width / 2.0));   //Centered
            Label.Left = Convert.ToInt32(Fields.XField.Box.Left - Label.Width - 10);    //Right-aligned
        }

        public void SetActiveValues(double x, double y)
        {
            ActiveValueLabels.SetValues(x, y);
            Fields.SetActive(x, y);
            
        }

        public override void AlignActiveValues()
        {
            ActiveValueLabels.AlignActiveValues();
        }

        public override void Hide()
        {
            Fields.Hide();
            Fields.LockCheckBox.Hide();
            Label.Hide();
        }

        public void Show()
        {
            Fields.Show();
            Fields.LockCheckBox.Show();
            Label.Show();
        }

        public override void Show(string name)
        {
            SetName(name);

            Show();
        }

        #endregion Methods
    }
}
