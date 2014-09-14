using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLOPE.Native
{
	public class CLOPECluster
	{
		public int Square { get { return square; } }
		public int Width { get { return width; } }
		public int Size { get { return size; } }
		public Dictionary<int, int> Occ { get { return occ; } }

		int square;
		int width;
		int size;
		Dictionary<int, int> occ = new Dictionary<int, int>();

		public void AddTransaction(List<int> transaction)
		{
			square += transaction.Count;
			for (int i = 0; i < transaction.Count; i++)
			{
				if (!occ.ContainsKey(transaction[i]))
					occ.Add(transaction[i], 0);
				occ[transaction[i]] += 1;
			}
			width = occ.Count;
			size++;
		}

		public void RemoveTransaction(List<int> transaction)
		{
			square -= transaction.Count;
			for (int i = 0; i < transaction.Count; i++)
			{
				occ[transaction[i]] -= 1;
				if (occ[transaction[i]] == 0)
					occ.Remove(transaction[i]);
			}
			width = occ.Count;
			size--;
		}
	}
}
