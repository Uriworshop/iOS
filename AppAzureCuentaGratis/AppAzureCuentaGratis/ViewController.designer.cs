// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace AppAzureCuentaGratis
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnUbicar { get; set; }

		[Outlet]
		UIKit.UILabel txtCapital { get; set; }

		[Outlet]
		UIKit.UILabel txtContinente { get; set; }

		[Outlet]
		UIKit.UILabel txtExtension { get; set; }

		[Outlet]
		UIKit.UILabel txtIdioma { get; set; }

		[Outlet]
		UIKit.UILabel txtMoneda { get; set; }

		[Outlet]
		UIKit.UILabel txtPais { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnUbicar != null) {
				btnUbicar.Dispose ();
				btnUbicar = null;
			}

			if (txtCapital != null) {
				txtCapital.Dispose ();
				txtCapital = null;
			}

			if (txtContinente != null) {
				txtContinente.Dispose ();
				txtContinente = null;
			}

			if (txtExtension != null) {
				txtExtension.Dispose ();
				txtExtension = null;
			}

			if (txtIdioma != null) {
				txtIdioma.Dispose ();
				txtIdioma = null;
			}

			if (txtMoneda != null) {
				txtMoneda.Dispose ();
				txtMoneda = null;
			}

			if (txtPais != null) {
				txtPais.Dispose ();
				txtPais = null;
			}
		}
	}
}
