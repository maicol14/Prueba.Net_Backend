using MongoDB.Driver;
using ProveedoresAPI.Modelo;


namespace ProveedoresAPI.Data
{
    public class ProveedorContext
    {
        public IMongoCollection<Proveedor> Proveedores { get; }

        public ProveedorContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ProveedoresDB");
            Proveedores = database.GetCollection<Proveedor>("Proveedores");
        }
    }
}
