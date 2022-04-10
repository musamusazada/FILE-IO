namespace StudentManager;

public  class Student
{
    public string Name;
    public string Surname;
    public string AlbumNo;

    public Student(string name, string surname, string albumNo)
    {
        this.Name = name;
        this.Surname = surname;
        this.AlbumNo = albumNo;
    }
}