namespace PaintballProject.Controllers
{
    internal class PaintballDbContext
    {
        public object Players { get; internal set; }

        internal object Players(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal void Players(object playerToRemove)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}