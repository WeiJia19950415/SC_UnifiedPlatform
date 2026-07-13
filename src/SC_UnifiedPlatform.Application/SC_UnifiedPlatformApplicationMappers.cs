using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using SC_UnifiedPlatform.Books;

namespace SC_UnifiedPlatform;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class SC_UnifiedPlatformBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class SC_UnifiedPlatformCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}
