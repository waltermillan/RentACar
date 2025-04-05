namespace API.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }                     //ID => Table: User Field: Id
        public string UserName { get; set; }            //ID => Table: User Field: Name
        public int IdRol { get; set; }                  //ID => Table: User Field: IdRol
        public string Rol { get; set; }                 //ID => Table: Rol Field: Description
    }
}
