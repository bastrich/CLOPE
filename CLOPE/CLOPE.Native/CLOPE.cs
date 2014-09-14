using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLOPE.Native
{
	public class CLOPE
	{
		public static Dictionary<int, CLOPECluster> Execute(ICLOPEData data, double repulsionCoefficient)
		{
			Dictionary<int, CLOPECluster> clusters = new Dictionary<int, CLOPECluster>();		
			bool moved = true;
			while (moved)
			{
				moved = false;
				data.ToBegin();
				while (!data.IsEnd())
				{
					Transaction transaction = data.ReadNextTransaction();
					double removeDelta = transaction.ClusterNumber == 0 ? 0 : DeltaRemove(clusters[transaction.ClusterNumber], transaction.Parameters, repulsionCoefficient);
					double maxDelta = 0;
					double delta = 0;
					int newClusterNumber = transaction.ClusterNumber;

					foreach (KeyValuePair<int, CLOPECluster> pair in clusters)
					{
						delta = DeltaAdd(pair.Value, transaction.Parameters, repulsionCoefficient);
						if (delta + removeDelta > maxDelta)
						{
							maxDelta = delta;
							newClusterNumber = pair.Key;
						}
					}

					delta = DeltaAdd(null, transaction.Parameters, repulsionCoefficient);
					if (delta + removeDelta > maxDelta)
					{
						if (clusters.Count == 0)
							newClusterNumber = 1;
						else
							newClusterNumber = clusters.Keys.Max() + 1;
						clusters.Add(newClusterNumber, new CLOPECluster());
					}

					if (newClusterNumber != transaction.ClusterNumber)
					{
						if (transaction.ClusterNumber != 0)
							clusters[transaction.ClusterNumber].RemoveTransaction(transaction.Parameters);			
						clusters[newClusterNumber].AddTransaction(transaction.Parameters);
						moved = true;
						transaction.ClusterNumber = newClusterNumber;
						data.WriteTransaction(transaction);	
					}						
				}
			}

			List<int> keysForDeleting = new List<int>();
			foreach (int key in clusters.Keys)		
				if (clusters[key].Size == 0)
					keysForDeleting.Add(key);
			foreach (int key in keysForDeleting)
				clusters.Remove(key);

			return clusters;
		}

		static double DeltaAdd(CLOPECluster cluster, List<int> transaction, double r)
		{
			if (cluster == null)
				return transaction.Count / Math.Pow(transaction.Count, r);
			int squareNew = cluster.Square + transaction.Count;
			int widthNew = cluster.Width;
			for (int i = 0; i < transaction.Count; i++)
				if (!cluster.Occ.ContainsKey(transaction[i]))
					widthNew++;				
			return squareNew * (cluster.Size + 1) / Math.Pow(widthNew, r) - cluster.Square * cluster.Size / Math.Pow(cluster.Width, r);
		}

		static double DeltaRemove(CLOPECluster cluster, List<int> transaction, double r)
		{
			int squareNew = cluster.Square - transaction.Count;
			int widthNew = cluster.Width;
			for (int i = 0; i < transaction.Count; i++)
				if (cluster.Occ[transaction[i]] == 1)
					widthNew--;
			return squareNew * (cluster.Size - 1) / Math.Pow(widthNew, r) - cluster.Square * cluster.Size / Math.Pow(cluster.Width, r);
		}
	}
}
