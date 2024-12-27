using FCNetwork.Common.Exceptions;
using FCNetwork.Common.Security.User;
using FCNetwork.Infrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using FCNetwork.Infrastructure.Data;
using FCNetwork.Infrastructure.Entities;

namespace FCNetwork.Application.Services
{
    public class UserService(UserManager<User> userManager,AppDbContext context)
    {
        public async Task<UserLoginResponse> AuthenticateAsync(UserLoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                throw new PayloadException("L'émail et le mot de passe sont obligatoires");
            }

            var user = await userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new PayloadException("L'utilisateur n'existe pas");
            }

            var result = await userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!result)
            {
                throw new PayloadException("Le mot de passe est incorrect");
            }
            return new UserLoginResponse { Email = loginRequest.Email };
        }

        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest registerRequest)
        {
            if(registerRequest == null)
            {
                throw new PayloadException("L'email et le mot de passe sont obligatoires");
            }

            var user = new User
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email,
            };

            var checkDuplicate = await userManager.FindByEmailAsync(user.Email);
            if (checkDuplicate != null)
            {
                throw new PayloadException("L'utilisateur existe déjà");
            }

           var result = await userManager.CreateAsync(user, registerRequest.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(",",result.Errors.Select(x => x.Description));
                throw new Exception($"Erreur lors de la création de l'utilisateur : {errors}");
            }
            else
            {
                var device = await context.Devices.FindAsync(registerRequest.DeviceId);
                user = await userManager.FindByEmailAsync(registerRequest.Email);
                if(device == null || user == null)
                {
                    throw new PayloadException("L'utilisateur ou le device n'existe pas");
                }else{
                    var player = new Player
                    {
                        Device = device,
                        GameTag = registerRequest.GameTag,
                        
                    };
                    var playerResult = await context.Players.AddAsync(player);
                    user.Player = player;
                    await userManager.UpdateAsync(user);

                    await context.SaveChangesAsync();
                }
            }

            return new RegisterResponse { Email = registerRequest.Email };
        }
    }
}
