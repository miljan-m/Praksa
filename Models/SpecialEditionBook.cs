using LibraryApp.Models.BaseDomain;
using LibraryApp.Models.IDomain;

namespace LibraryApp.Models;

public class SpecialEditionBook : Book, IBook, IBaseEntity
{
    public int InStorage { get; set; }
    private string autograph;
    public string Autograph { get => autograph; set => autograph = value; }

    public override string BookDetails()
    {
        return $"ISBN: {Isbn}\n Title: {Title}\n Genre: {Genre}\n Available: {Available}\n Special edition:YES\n Autograph: {Autograph}";
    }

    new public string ShowAutograph()
    {
        return Autograph;
    }
}