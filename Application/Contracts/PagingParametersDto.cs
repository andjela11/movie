namespace Application.Contracts;

public class PagingParametersDto
{
    private const int maxPagesize = 50;
    public int PageNumber { get; set; } = 1;

    private int _pagesize = 10;

    public int PageSize
    {
        get
        {
            return this._pagesize;
        }
        set
        {
            this._pagesize = (value > maxPagesize) ? maxPagesize : value;
        }
    }
}
