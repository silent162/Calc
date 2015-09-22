﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewPr
{
	public partial class MyPage : ContentPage
	{
		private bool operation_pressed = false;
		private bool equals_pressed = false;
		private bool point_pressed = false;
		public string str;

		public MyPage ()
		{
			InitializeComponent ();
			new Wrapper (this);
		}

		public event EventHandler operatorEvent = null;
		public event EventHandler equalsEvent = null;

		private void OnButtonClicked(object sender, System.EventArgs e)
		{
			Button button = (Button)sender;

			if (button.Text == "." && Output.Text == "0")
			{
				point_pressed = true;
				Output.Text = "0.";
			}

			if ((Output.Text == "0") || operation_pressed || equals_pressed || (Output.Text == "На ноль делить нельзя!"))
				Output.Text = "";
									
			/*if (button.Text == ".") 
			{
				point_pressed = true;
				Output.Text += button.Text;
			}*/

			if (point_pressed == false && button.Text == ".") 
			{				
				Output.Text += button.Text;
				point_pressed = true;

			} 
			else if (point_pressed == true && button.Text != ".")
					Output.Text += button.Text;
			else if (button.Text != ".")
				    Output.Text += button.Text;

			equals_pressed = false;
			operation_pressed = false;

		}

		private void OnCEClicked(object sender, System.EventArgs e)
		{
			Output.Text = "0";
			point_pressed = false;
		}

		private void OnCClicked(object sender, System.EventArgs e)
		{
			Output.Text = "0";
			point_pressed = false;
		}

		private void OnOperatorClicked(object sender, System.EventArgs e)
		{
			str = Output.Text;
			point_pressed = false;
			operation_pressed = true;
			operatorEvent.Invoke (sender,e);
			Output.Text = str;
		}

		private void OnEqualsClicked(object sender, System.EventArgs e)
		{
			str = Output.Text;
			point_pressed = false;
			equals_pressed = true;
			equalsEvent.Invoke (sender,e);
			Output.Text = str;
			operation_pressed = false;
		}
	}
}

