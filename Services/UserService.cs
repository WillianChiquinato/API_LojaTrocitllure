using System.Text.RegularExpressions;
using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;
using Microsoft.IdentityModel.Tokens;

namespace Api_LojaTricotllure.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _userRepository;
    
    public UserService(ILogger<UserService> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<CustomResponse<List<User>>> GetUsers()
    {
        try
        {
            var users = await _userRepository.GetUsers();
            
            return new CustomResponse<List<User>>(
                true,
                new List<string>(),
                users,
                users.Count
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<CustomResponse<User>> GetUserByEmailAndPassword(string email, string password)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAndPassword(email, password);

            return CustomResponse<User>.SuccessTrade(user);
        }
        catch (Exception ex)
        {
            return CustomResponse<User>.Fail("Erro ao buscar usuario", ex.Message);
        }
    }
    
    public async Task<CustomResponse<User>> GoogleLogin(string emailUnique)
    {
        try
        {
            var googleUser = await _userRepository.ReadUserWithEmail(emailUnique);
            
            return CustomResponse<User>.SuccessTrade(googleUser);
        }
        catch (Exception ex)
        {
            return CustomResponse<User>.Fail("Erro interno ao logar com google", ex.Message);
        }
    }

    public async Task<CustomResponse<User>> CreateUser(User user)
    {
        try
        {
            var cpfExists = await _userRepository.ReadUserByCPF(user.CpfCnpj);
            var emailExists = await _userRepository.ReadUserWithEmail(user.Email);

            if (cpfExists != null)
                return CustomResponse<User>.Fail("CPF já cadastrado");
            
            if (emailExists != null)
                return CustomResponse<User>.Fail("Email cadastrado na plataforma, tente outro!!");

            var phoneClean = String.Empty;
            if (user.PrimaryPhone != null)
            {
                phoneClean = Regex.Replace(user.PrimaryPhone.ToString(), @"\D", "");
            }

            if (!phoneClean.IsNullOrEmpty())
            {
                if (phoneClean.Length < 10 || phoneClean.Length > 11)
                    return CustomResponse<User>.Fail("Telefone inválido");

                user.PhoneDDD = int.Parse(phoneClean[..2]);
                user.PrimaryPhone = phoneClean[2..];
            }
            
            user.DocumentType = user.CpfCnpj != null && user.CpfCnpj.Length == 11 ? 1 : 2;
            user.IsActive = true;
            
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            var createdUser = await _userRepository.CreateUser(user);

            return CustomResponse<User>.SuccessTrade(createdUser);
        }
        catch (Exception ex)
        {
            return CustomResponse<User>.Fail("Erro interno ao criar usuário", ex.Message);
        }
    }

    public async Task<CustomResponse<User>> FirstAcessUser(int id)
    {
        try
        {
            var acessUsertoUpdated = await _userRepository.FirstAcessUser(id);
            
            return CustomResponse<User>.SuccessTrade(acessUsertoUpdated);
        }
        catch (Exception)
        {
            return CustomResponse<User>.Fail("Erro interno ao atualizar usuário");
        }
    }
}