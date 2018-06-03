/*
Copyright (C) 2018 Wampa842

This file is part of WPlugins.

WPlugins is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

WPlugins is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPlugins.ObjExport
{
	public partial class ExportProgressForm : Form
	{
		private BackgroundWorker worker;
		public ExportProgressForm(BackgroundWorker worker, int max)
		{
			InitializeComponent();
			this.worker = worker;
			totalProgressBar.Maximum = max;
		}

		public void UpdateProgress(int percent, ProgressReporter rep)
		{
			totalProgressBar.Value = rep.TotalProgress;
		}

		private void cancelProcessButton_Click(object sender, EventArgs e)
		{
			worker.CancelAsync();
		}
	}
}
