namespace UIComercia.Services
{
    public class PaginasAbiertas
    {
        public List<Pagina> Paginas { get; set; }

        public PaginasAbiertas()
		{            
            this.Paginas = new List<Pagina>();
            Paginas.Add(new Pagina
            {
                Numero = 1,
                Nombre = "Home",
                Tipo = Activator.CreateInstance("UIComercia", $"UIComercia.Pages.Home").Unwrap().GetType()
            });            
		}
    }

    public class Pagina
	{        
        public string Nombre { get; set; }
        public Type Tipo { get; set; }
        public int Numero { get; set; }
	}
}
