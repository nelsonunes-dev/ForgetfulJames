using Newtonsoft.Json;
using ForgetfulJames.Common.Helpers;
using ForgetfulJames.Domain.Constants;

namespace ForgetfulJames.Infrastructure.Common
{
    public abstract class SeedingBase<TEntity> where TEntity : class
    {
        public virtual async Task Seed(ApplicationDbContext dbContext, bool useMockData, CancellationToken cancellationToken = default)
        {
            var fileName = Resources.GetSeedingFileName(typeof(TEntity), useMockData);

            if (string.IsNullOrEmpty(fileName))
                return;

            var fileData = FileHelper.GetFileAsString(fileName);

            if (string.IsNullOrEmpty(fileData))
                return;

            try
            {
                var seedData = JsonConvert.DeserializeObject<IList<TEntity>>(fileData,
                    new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                        Formatting = Formatting.Indented
                    });

                if (seedData == null)
                    return;

                if (!seedData.Any())
                    return;

                foreach (var entity in seedData)
                {
                    if (entity != null && !dbContext.Set<TEntity>().Any())
                        dbContext.Add(entity);
                }

                await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) 
            {
                // Left 
            }
        }
    }
}
