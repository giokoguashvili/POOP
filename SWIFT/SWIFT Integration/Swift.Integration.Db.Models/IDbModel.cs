namespace Swift.Integration.Db.Models
{
    public interface IDbModel { }
    public interface IDbModel<out T> 
    {
        T AsDbModel();
    }
}
