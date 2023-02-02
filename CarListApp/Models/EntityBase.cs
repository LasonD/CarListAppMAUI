using SQLite;

namespace CarListApp.Models
{
    public abstract class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
