namespace PaintballProject.Controllers
{
    internal class PaintballDbContext
    {
        public object Players { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}