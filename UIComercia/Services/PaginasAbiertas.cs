using System.Collections.Generic;

namespace UIComercia.Services
{
    public class PaginasAbiertas
    {
        public List<Pagina> Paginas { get; set; }
        
        public Dictionary<int, Dictionary<string, object>> Estado { get; set;}

        

        public PaginasAbiertas()
		{            
            this.Paginas = new List<Pagina>();
            Paginas.Add(new Pagina
            {
                Numero = 1,
                Nombre = "Home",
                Tipo = Activator.CreateInstance("UIComercia", $"UIComercia.Pages.Home").Unwrap().GetType()
            });
            var Parametros = new Dictionary<string, object>();
            Parametros.Add("currentCount", 0);
            this.Estado = new Dictionary<int, Dictionary<string, object>>();
            this.Estado.Add(1, Parametros);
        }

        public void DeclararEstadoInicialCounter(int numeroDePagina)
        {
            var Parametros = new Dictionary<string, object>();
            Parametros.Add("currentCount", 0);            
            this.Estado.Add(numeroDePagina, Parametros);
        }        
    }

    public class Pagina
	{        
        public string Nombre { get; set; }
        public Type Tipo { get; set; }
        public int Numero { get; set; }
	}
}
