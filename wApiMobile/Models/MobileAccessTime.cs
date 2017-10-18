using System;

namespace wApiMobile.Models
{
	public class MobileAccessTime
	{
		public string Legajo { get; set; }

		public long DNI { get; set; }

		public string Movil { get; set; }

		public int TipoMovimiento { get; set; }

		public double Latitud { get; set; }

		public double Longitud { get; set; }

		public string Telefono { get; set; }

		public MobileAccessTime(string legajo, long dni, string movil, int tipoMovimiento, double latitud, double longitud, string telefono)
		{
			this.Legajo = legajo;
			this.DNI = dni;
			this.Movil = movil;
			this.TipoMovimiento = tipoMovimiento;
			this.Latitud = latitud;
			this.Longitud = longitud;
			this.Telefono = telefono;
		}
	}
}