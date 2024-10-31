using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProveedoresAPI.Modelo
{
    public class Proveedor
    {

        [BsonId]  // Indica que este es el campo _id
        public ObjectId Id { get; set; }  // Campo para el identificador único
        public string NIT { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NombreContacto { get; set; }
        public string CorreoContacto { get; set; }
    }
}
