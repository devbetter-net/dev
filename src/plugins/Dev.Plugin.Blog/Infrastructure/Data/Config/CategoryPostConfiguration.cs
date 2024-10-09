using Dev.Plugin.Blog.Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dev.Plugin.Blog.Infrastructure.Data.Config;

public class CategoryPostConfiguration : IEntityTypeConfiguration<CategoryPost>
{
    public void Configure(EntityTypeBuilder<CategoryPost> builder)
    {
        builder.ToTable("BlogCategoryPost");
        builder.HasKey(x => new { x.CategoryId, x.PostId });
        builder.HasOne(x => x.Category).WithMany(x => x.CategoryPosts).HasForeignKey(x => x.CategoryId);
        builder.HasOne(x => x.Post).WithMany(x => x.CategoryPosts).HasForeignKey(x => x.PostId);
    }

}
