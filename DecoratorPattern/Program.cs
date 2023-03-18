using System.Numerics;
var cubes = new Cube();
CubeMaterial cube = new  CubeMaterial(cubes,"BLUE","GROUND") ;
cube.CreateCube(new Vector3(10, 5, 1), new Vector3(1, 1, 1));
interface ICube3D
{
    void CreateCube(Vector3 cubeSize, Vector3 cubeLocation);
}

class Cube : ICube3D
{
    public void CreateCube(Vector3 cubeSize, Vector3 cubeLocation)
    {
        Console.WriteLine($"Size {cubeSize.X} {cubeSize.Y} {cubeSize.Z}");
        Console.WriteLine($"Location {cubeLocation.X} {cubeLocation.Y} {cubeLocation.Z}");
        Console.WriteLine("Created Cube");

    }
}

class CubeDecorator:ICube3D
{
    readonly ICube3D _cube;
    public CubeDecorator(ICube3D cube)
    {
        _cube = cube;
    }

   virtual public void CreateCube(Vector3 cubeSize, Vector3 cubeLocation)
   {
        _cube.CreateCube(cubeSize, cubeLocation);
   }
    
}
class CubeMaterial : CubeDecorator
{
    readonly ICube3D _cube;
    private string _color;
    private string _texture;

    public CubeMaterial(ICube3D cube, string color, string texture) : base(cube)
    {
        _cube = cube;
        _color = color;
        _texture = texture;
    }

    private void CreatedCubeMaterial ()
    {
        Console.WriteLine($"Color : {_color} Texture : {_texture}");
    }

    public override void CreateCube(Vector3 cubeSize, Vector3 cubeLocation)
    {
        base.CreateCube(cubeSize, cubeLocation);
        CreatedCubeMaterial();
    }
}