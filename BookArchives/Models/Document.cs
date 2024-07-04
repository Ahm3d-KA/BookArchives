namespace BookArchives.Models;

public class Document
{
    public string title { get; set; }
    public List<string> author_name { get; set; }
    public double ratings_average { get; set; }
    public List<string> subject { get; set; }
    public int cover_i { get; set; }
    public int first_publish_year { get; set; }
    public int number_of_pages_median { get; set; }
    public List<string> id_goodreads { get; set; }
    public string ddc_sort { get; set; }
}