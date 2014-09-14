using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLOPE
{
	class CLOPE
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
					double removeDelta = transaction.ClusterNumber == 0 ? 0 : clusters[transaction.ClusterNumber].DeltaRemove(transaction.Parameters, repulsionCoefficient);
					double maxDelta = 0;
					double delta = 0;
					int newClusterNumber = transaction.ClusterNumber;

					foreach (KeyValuePair<int, CLOPECluster> pair in clusters)
					{
						delta = pair.Value.DeltaAdd(transaction.Parameters, repulsionCoefficient);
						if (delta + removeDelta > maxDelta)
						{
							maxDelta = delta;
							newClusterNumber = pair.Key;
						}
					}

					CLOPECluster cluster = new CLOPECluster();
					delta = cluster.DeltaAdd(transaction.Parameters, repulsionCoefficient);
					if (delta + removeDelta > maxDelta)
					{
						if (clusters.Count == 0)
							newClusterNumber = 1;
						else
							newClusterNumber = clusters.Keys.Max() + 1;
						clusters.Add(newClusterNumber, cluster);
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
	}
}
