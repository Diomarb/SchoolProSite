

namespace SchoolProSite.DAL.Exceptions
{
    public class DaoCourseException : Exception
    {
        
        
            public DaoCourseException(string message) : base(message)
        {
            //logica para guardar el error en la base de datos y enviar un correo.
        }
    }
}
