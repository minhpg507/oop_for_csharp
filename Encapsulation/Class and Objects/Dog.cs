public class Dog
{
    private string name;
    private string breed;
    private int age;
    private string color;
    private int field;

    public Dog(string name, string breed, int age, string color)
    {
        this.name = name;
        this.breed = breed;
        this.age = age;
        this.color = color;
    }

    public string GetName() { return name; }
    public string GetBreed() { return breed; }
    public int GetAge() { return age; }
    public string GetColor() { return color; }

    public override string ToString()
    {
        return "My name is: " + name + "\nMy breed is: " + breed + "\nMy age is: " + age;
    }
}