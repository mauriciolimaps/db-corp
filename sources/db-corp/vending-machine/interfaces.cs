using System;
using System.Collections.Generic;
using System.Text;

namespace DBCorp
{
	interface ICoin
	{
		string	Name		{  get;  }
		Decimal Value		{  get;  }
	}
}
