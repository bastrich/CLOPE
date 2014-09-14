using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLOPE
{
	public partial class Form1 : Form
	{
		const string srcDataFilepath = "../../data/agaricus-lepiota.data";
		const string normDataFilePath = "normalizedData.data";
		const string resDataFilePath = "res.txt";


		public Form1()
		{
			InitializeComponent();
			rTextBox.Text = 2.6 + ""; //чтобы не было проблем с дестичным разделителем в Windows на разных языках
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Dictionary<int, CLOPECluster> clusters = null;
			BackgroundWorker bw = new BackgroundWorker();

			bw.DoWork += new DoWorkEventHandler(new Action<object, DoWorkEventArgs>((o, dwe) =>
			{
				BeginInvoke(new Action(() =>
				{
					button1.Enabled = false;
				}));

				double r;
				if (!double.TryParse(rTextBox.Text, out r))
				{
					MessageBox.Show("Коэффициент отталкивания введён в неправильном формате!");
					return;
				}

				BeginInvoke(new Action(() =>
				{
					statusLabel.Text = "Выполняется кластеризация...";
				}));

				Mushroom.Normalize(srcDataFilepath, normDataFilePath);
				CLOPEData data = new CLOPEData(normDataFilePath, resDataFilePath);
				clusters = CLOPE.Execute(data, r);
				data.Close();
			}));

			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(new Action<object, RunWorkerCompletedEventArgs>((o, wce) =>
			{
				BeginInvoke(new Action(() =>
				{
					if (clusters != null)
					{
						clustersTable.Rows.Clear();
						int sumSize = 0;
						int sumE = 0;
						int sumP = 0;
						StreamReader srSrc = new StreamReader(srcDataFilepath);
						StreamReader srRes = new StreamReader(resDataFilePath);
						Dictionary<int, int> em = new Dictionary<int, int>();
						Dictionary<int, int> pm = new Dictionary<int, int>();
						while (!srSrc.EndOfStream)
						{
							string type = srSrc.ReadLine().Split(',')[0];
							string[] transaction = srRes.ReadLine().Split(',');
							int clusterNumber = int.Parse(transaction[transaction.Length - 1]);
							if (!pm.ContainsKey(clusterNumber))
								pm.Add(clusterNumber, 0);
							if (!em.ContainsKey(clusterNumber))
								em.Add(clusterNumber, 0);
							if (type == "e")
								em[clusterNumber] += 1;
							else
								pm[clusterNumber] += 1;
						}
						srSrc.Close();
						srRes.Close();
						foreach (KeyValuePair<int, CLOPECluster> pair in clusters)
						{
							clustersTable.Rows.Add(pair.Key, pair.Value.Square, pair.Value.Width, pair.Value.Size, em[pair.Key], pm[pair.Key]);
							sumSize += pair.Value.Size;
							sumE += em[pair.Key];
							sumP += pm[pair.Key];
						}
						clustersTable.Rows.Add("Итого", "", "", sumSize, sumE, sumP);
					}
					statusLabel.Text = "Остановлено";
					button1.Enabled = true;
				}));
			}));

			bw.RunWorkerAsync();
		}
	}
}
