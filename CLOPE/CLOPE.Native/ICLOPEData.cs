using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLOPE.Native
{
	public interface ICLOPEData
	{
		Transaction ReadNextTransaction();
		void WriteTransaction(Transaction transaction);
		void ToBegin();
		bool IsEnd();
	}
}
