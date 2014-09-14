using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLOPE
{
	class Transaction
	{
		public List<int> Parameters { get { return parameters; } }
		public int ClusterNumber { get { return clusterNumber; } set { clusterNumber = value; } }

		public Transaction(List<int> parameters, int clusterNumber)
		{
			this.parameters = parameters;
			this.clusterNumber = clusterNumber;
		}

		List<int> parameters;
		int clusterNumber;
	}
}
