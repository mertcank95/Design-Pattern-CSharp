//Hierarchy

Section section1 = new Section("Section 1");
section1.Add(new Pragraph("Paragraph 1.1"));
section1.Add(new Pragraph("Paragraph 1.2"));

Section section2 = new Section("Section 2");
section2.Add(new Pragraph("Paragraph 2.1"));
section2.Add(new Pragraph("Paragraph 2.2"));

DocumentComponent document = new Section("Document");
document.Add(section1);
document.Add(section2);

document.Display(0);
//base 
abstract class DocumentComponent
{
    protected string name;
    public DocumentComponent(string name)
    {
        this.name = name;
    }
    public abstract void Add(DocumentComponent component);
    public abstract void Remove(DocumentComponent component);
    public abstract void Display(int depth);
}

//Leaf
class Pragraph : DocumentComponent
{
    public Pragraph(string name) : base(name){}

    public override void Add(DocumentComponent component)
    {
        Console.WriteLine("Cannot add to a leaf component.");
    }
    public override void Remove(DocumentComponent component)
    {
        Console.WriteLine("Cannot romove from a leaf component.");
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-',depth)+name);
    }
}

//Composite
class Section : DocumentComponent
{
    private List<DocumentComponent> _children = new List<DocumentComponent>();
    public Section(string name) : base(name)
    {
    }

    public override void Add(DocumentComponent component)
    {
        _children.Add(component);
    }
    public override void Remove(DocumentComponent component)
    {
        _children.Remove(component);
    }
    public override void Display(int depth)
    {
        Console.WriteLine(new string('-',depth)+name);
        foreach (DocumentComponent item in _children)
        {
            item.Display(depth + 2);
        }
    }
}