using LibraryApp.Models.IDomain;

namespace LibraryApp.Models;

public class SpecialEditionBook : Book,IBook
{
    public int InStorage { get; set; } = 10;
    private string Autograph { get; set; }

    public override string BookDetails()
    {
        return $"ISBN: {Isbn}\n Title: {Title}\n Genre: {Genre}\n Available: {Available}\n Special edition:YES\n Autograph: {Autograph}";
    }

    new public string ShowAutograph()
    {
        return Autograph;
    }
}