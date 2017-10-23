using System.Data.Entity;

namespace Web.Models.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
                
        }
    }
}