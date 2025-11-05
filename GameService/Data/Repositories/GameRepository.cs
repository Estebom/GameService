
using GameService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext Context;
        public GameRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<List<Game>> Get()
        {
            try
            {
                return await Context.Games.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Game> Get(Guid id) 
        {
            try
            {
                return await Context.Games.Where(g => g.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task Add(GameDTO gameDTO)
        {
            try 
            {
                Game game = new Game() 
                {
                   Name = gameDTO.Name,
                   Description = gameDTO.Description,
                   Price = gameDTO.Price,
                };

                await Context.Games.AddAsync(game);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var game = await Context.Games.FindAsync(id);

                if (game is null) 
                {
                    return false;
                }

                Context.Games.Remove(game);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<bool> Update(Guid id, GameDTO gameDTO)
        {
            try
            {
                var game = await Context.Games.FindAsync(id);

                if (game == null) 
                {
                    return false;
                }

                game.Name = gameDTO.Name;
                game.Description = gameDTO.Description;
                game.Price = gameDTO.Price;

                Context.Update(game);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
