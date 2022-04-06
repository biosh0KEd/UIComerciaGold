namespace UIComercia.Services
{
	public class PaginaActual
	{
		public string NombrePaginaActual { get; set; } = "Home";
		public Type TypePaginaActual { get; set; } = Activator.CreateInstance("UIComercia", "UIComercia.Pages.Home").Unwrap().GetType();

		public void SetNombrePaginaActual(string name)
		{
			if (!string.Equals(NombrePaginaActual, name))
			{
				NombrePaginaActual = name;
				TypePaginaActual = Activator.CreateInstance("UIComercia", $"UIComercia.Pages.{name}").Unwrap().GetType();
				NotifyStateChanged();
			}
		}

		public event Action OnChange;

		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}
