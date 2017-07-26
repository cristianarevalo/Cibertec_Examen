namespace Examen.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}
