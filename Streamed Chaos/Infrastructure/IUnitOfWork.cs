namespace Streamed_Chaos.Infrastructure
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// uploads the file 
        /// </summary>
        /// <param name="file"></param>
        void UploadImage(IFormFile file);
    }
}
