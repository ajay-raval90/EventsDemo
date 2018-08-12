using EventManagement.DB.Entities;
using EventManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DB.Repository
{
    public class AuthRepository: IAuthRepository, IDisposable
    {
        EventDbContext context;
        public AuthRepository(EventDbContext context)
        {
            this.context = context;
        }
        public AuthRepository()
        {
            this.context = new EventDbContext();
        }
        public Client FindClient(string clientId)
        {
            var client = context.Clients.Find(clientId);
            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = context.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();
            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }
            context.RefreshTokens.Add(token);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await context.RefreshTokens.FindAsync(refreshTokenId);
            if (refreshToken != null)
            {
                context.RefreshTokens.Remove(refreshToken);
                return await context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            context.RefreshTokens.Remove(refreshToken);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await context.RefreshTokens.FindAsync(refreshTokenId);
            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return context.RefreshTokens.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }
        public void SeedClients()
        {
            var getClientCount = context.Clients.Count();
            if(getClientCount==0)
            {
                Client client = new Client
                {
                    Active = true,
                    AllowedOrigin = "*",
                    ApplicationType = ApplicationTypes.NativeConfidential,
                    Id = "36F0D48184E115F7F571B9026A2DE732",
                    Name = "Native Mobile App",
                    RefreshTokenLifeTime = 1440,
                    Secret = "7C17BA4E0C63401084B41B1E27161A4F"
                };
                AddClient(client);

                client = new Client
                {
                    Active = true,
                    AllowedOrigin = "http://localhost:50457",
                    ApplicationType = ApplicationTypes.JavaScript,
                    Id = "E5BA49BA5A2B48367B044FC8D63352FB",
                    Name = "Events Management",
                    RefreshTokenLifeTime = 1440,
                    Secret = "A281B4BAEB8DB22027CE28005D1BE0D3"
                };
                AddClient(client);
            }
        }
    }
}