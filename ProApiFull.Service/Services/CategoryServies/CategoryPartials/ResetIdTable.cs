namespace ProApiFull.Service.Services;
public partial class CategoryService
{
    public async Task<Result<string>> ResetIdTableAsync(CancellationToken cancellationToken = default)
    {
        if (await _category.Entity.AnyAsync(cancellationToken: cancellationToken))
            return BadRequest<string>
                (MessageLocalize(SharedKeys.ResetTableCategory));

        await _category.Entity.ResetTable(nameof(context.Categories), cancellationToken);


        return BadRequest<string>
                (MessageLocalize(SharedKeys.ResetTableSuccessfully));
    }
}
