IImageLoader imageLoader = new ImageLoaderProxy("image.jpg");
imageLoader.Load();
interface IImageLoader
{
    void Load();
}
class RealImage : IImageLoader
{
    private string _imagePath;
    public RealImage(string fileName)
    {
        _imagePath = fileName;
        loadImageFromDisk();
    }
    public void Load()
    {
        Console.WriteLine($"Displaying image {_imagePath}");
    }
    private void loadImageFromDisk()
    {
        Console.WriteLine($"Loading image {_imagePath} from disk ... ");
        Thread.Sleep(1000);
    }
}
public class ImageLoaderProxy : IImageLoader
{
    private RealImage _realImage;
    private string _imagePath;
    public ImageLoaderProxy(string imagePath)
    {
        _imagePath = imagePath;
    }
    public void Load()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_imagePath);
        }
        _realImage.Load();
    }
}
