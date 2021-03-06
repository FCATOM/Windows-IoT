﻿using GHIElectronics.UWP.GadgeteerCore;
using System.Threading.Tasks;

using GSI = GHIElectronics.UWP.GadgeteerCore.SocketInterfaces;

namespace GHIElectronics.UWP.Gadgeteer.Modules {
	public class LED7C : Module {
		public override string Name => "LED7C";
		public override string Manufacturer => "GHI Electronics, LLC";

		private GSI.DigitalIO red;
		private GSI.DigitalIO green;
		private GSI.DigitalIO blue;

		public enum Color {
			Off,
			Blue,
			Green,
			Cyan,
			Red,
			Magenta,
			Yellow,
			White
		}

		protected async override Task Initialize(ISocket parentSocket) {
			this.red = await parentSocket.CreateDigitalIOAsync(SocketPinNumber.Four, false);
			this.green = await parentSocket.CreateDigitalIOAsync(SocketPinNumber.Five, false);
			this.blue = await parentSocket.CreateDigitalIOAsync(SocketPinNumber.Three, false);
		}

		public void SetColor(Color color) {
			var c = (int)color;

			this.red.Write((c & 4) != 0);
			this.green.Write((c & 2) != 0);
			this.blue.Write((c & 1) != 0);
		}
	}
}