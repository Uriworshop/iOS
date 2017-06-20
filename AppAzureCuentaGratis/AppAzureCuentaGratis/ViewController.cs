using System;
using CoreLocation;
using Geolocator.Plugin;
using UIKit;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppAzureCuentaGratis
{
	public partial class ViewController : UIViewController
	{
		CLLocationManager locationManager;
		double Latitud, Longitud;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();
			try
			{
				locationManager = new CLLocationManager();
				locationManager.RequestWhenInUseAuthorization();
				var locator = CrossGeolocator.Current;
				var position = await locator.GetPositionAsync(10000);
				var Ubicacion = new CLLocation(position.Latitude, position.Longitude);
				Latitud = position.Latitude;
				Longitud = position.Longitude;

				btnUbicar.TouchUpInside += async delegate
				{
					var clg = new CLGeocoder();
					var Datos = await clg.ReverseGeocodeLocationAsync(Ubicacion);
					txtPais.Text = Datos[0].Country;
					string Codigo = Datos[0].IsoCountryCode;

					string servicioREST = "http://api.geonames.org/countryInfoJSON?lang=es&country=" + Codigo + "&username=uriworshop";
					JsonValue json = await TraerCodigo(servicioREST);
				};
			}
			catch (Exception)
			{
				Console.WriteLine("Error Conectate a Internet");
			}
		}

		private async Task<JsonValue> TraerCodigo(string servicioREST)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(servicioREST));
			request.ContentType = "application/json";
			request.Method = "GET";
			using (WebResponse response = await request.GetResponseAsync())
			{
				using (Stream stream = response.GetResponseStream())
				{
					JsonValue jsondoc = await Task.Run(() => JsonValue.Load(stream));
					FromatoDatosJson resultado = JsonConvert.DeserializeObject<FromatoDatosJson>(jsondoc.ToString());
					txtCapital.Text = resultado.datitos[0].capital.ToString();
					txtExtension.Text = resultado.datitos[0].areaInSqKm.ToString();
					txtContinente.Text = resultado.datitos[0].continentName.ToString();
					txtIdioma.Text = resultado.datitos[0].languages.ToString();
					txtMoneda.Text = resultado.datitos[0].currencyCode.ToString();
					return jsondoc;
				}
			}
		}

		public class Datos
		{
			public string continent;
			public string capital;
			public string languages;
			public string geonameId;
			public string south;
			public string isoAlpha3;
			public string north;
			public string fipsCode;
			public string population;
			public string east;
			public string isoNumeric;
			public string areaInSqKm;
			public string countryCode;
			public string west;
			public string countryName;
			public string continentName;
			public string currencyCode;
		}

		public class FromatoDatosJson
		{
			[JsonProperty("geonames")]
			public Datos[] datitos;
		}

	}
}
