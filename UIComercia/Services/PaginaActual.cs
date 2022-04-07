using Microsoft.AspNetCore.Components;

namespace UIComercia.Services
{
	public class PaginaActual
	{
		private int contador = 2; 
		public int Numero = 1;
		public string NombrePaginaActual { get; set; } = "Home";		
		public Type TypePaginaActual { get; set; } = Activator.CreateInstance("UIComercia", $"UIComercia.Pages.Home").Unwrap().GetType();		

		public void CrearNuevaPagina(string name)
		{			
			NombrePaginaActual = name;
			Numero = contador;
			contador++;
			TypePaginaActual = Activator.CreateInstance("UIComercia", $"UIComercia.Pages.{name}").Unwrap().GetType();
			NotifyStateChanged();			
		}

		public Pagina GetPagina()
		{
			return new Pagina
			{
				Nombre = NombrePaginaActual,
				Tipo = TypePaginaActual,
				Numero = Numero
			};
		}		

		public void cambiarVentana(Pagina pagina)
		{
			this.NombrePaginaActual = pagina.Nombre;
			this.Numero = pagina.Numero;
			this.TypePaginaActual = pagina.Tipo;
			NotifyStateChanged();
		}

		public event Action OnChange;

		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}
