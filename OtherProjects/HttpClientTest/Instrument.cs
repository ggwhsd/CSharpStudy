using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FoxMMManagerServer.DBEntitys {

	[JsonObject(MemberSerialization.OptIn)]
	public partial class Instrument {

		[JsonProperty]
		public string InstrumentID { get; set; }

		[JsonProperty]
		public DateTime? CreateDate { get; set; }

		[JsonProperty]
		public string ExchangeID { get; set; }

		[JsonProperty]
		public DateTime? ExpireDate { get; set; }

		[JsonProperty]
		public string InstrumentName { get; set; }

		[JsonProperty]
		public sbyte IsTrading { get; set; }

		[JsonProperty]
		public int MaxLimitOrderVolume { get; set; }

		[JsonProperty]
		public int MaxMarketOrderVolume { get; set; }

		[JsonProperty]
		public int MinLimitOrderVolume { get; set; }

		[JsonProperty]
		public int MinMarketOrderVolume { get; set; }

		[JsonProperty]
		public DateTime? OpenDate { get; set; }

		[JsonProperty]
		public double PriceTick { get; set; }

		/// <summary>
		/// 工具类型：2期权、1期货等等
		/// </summary>
		[JsonProperty]
		public string ProductClass { get; set; } = "xxx";

		[JsonProperty]
		public string ProductID { get; set; } = "xxx";

		/// <summary>
		/// 如果是期权，就会有标的合约
		/// </summary>
		[JsonProperty]
		public string UnderlyingInstrID { get; set; } = "xxx";

		/// <summary>
		/// 合约乘数
		/// </summary>
		[JsonProperty]
		public int VolumeMultiple { get; set; }

	}

}
