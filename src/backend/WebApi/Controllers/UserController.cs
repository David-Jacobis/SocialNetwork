using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Resources;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models.Models;
using Business.ViewModels.User;
using Amazon;
using System.Linq;

namespace WebApi.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly CommonResource _commomresource;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(CommonResource CommonResource, IUserService UserService, IMapper Mapper)
        {
            _commomresource = CommonResource;
            _userService = UserService;
            _mapper = Mapper;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            try
            {
                var userModel = _mapper.Map<User>(request);

                var existingUserByCode = await _userService.GetUserByCodeAsync(request.CodAceUsu);
                if (existingUserByCode != null) 
                {
                    return StatusCode(400, ApiResponse<object>.ErrorResponse("Erro ao criar usuário devido já ter um existente com o código informado:", _commomresource.DefaultError));
                }

                var existingUserByEmail = await _userService.GetUserByEmail(request.DesEmailUsu);
                if (existingUserByEmail != null) 
                {
                    return StatusCode(400, ApiResponse<object>.ErrorResponse("Erro ao criar usuário devido já ter um existente com o E-mail informado:", _commomresource.DefaultError));
                }

                await _userService.CreateUserAsync(userModel);

                var apiResponse = ApiResponse<UserResponse>.SuccessResponse("Usuário Criado com Sucesso", null);
                return StatusCode(200, apiResponse);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An error occurred:", ex.Message));
            }
            
        }

        [HttpDelete]
        [Route("DeleteConfig/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
                await _userService.DeleteUserAsync(id);

                var apiResponse = ApiResponse<UserResponse>.SuccessResponse("Usuário Deletado com Sucesso", null);

                return StatusCode(200, apiResponse);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ApiResponse<UserResponse>.ErrorResponse(ex.Message, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<UserResponse>.ErrorResponse("An error occurred:", ex.Message));
            }

        }
    }


}
