using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;
using jwtauth.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace jwtauth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            
        }

    [HttpGet]
    public async Task<IActionResult> GetAccount()
    {
        var AccountModel = await accountRepository.GetAccountsAsync();
        return Ok(AccountModel);
    }

    [HttpGet ("{id:int}")]
    public async Task<IActionResult> AccontGetId([FromRoute] int id)
    {
        var AccontGetById = await accountRepository.GetAccountById(id);
        if (AccontGetById == null)
        {
            return NotFound ();
        }

        return Ok(AccontGetById);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] Account account)
    {
        var AccountModelCreate = await accountRepository.CreateAccountAsync(account);
        return CreatedAtAction(nameof(AccontGetId), new{id = AccountModelCreate.AccountId},AccountModelCreate);
    }

    [HttpPut]
    [Route ("{id:int}")]
    public async Task<IActionResult> UPdateAccount([FromRoute] int id , [FromBody]  Account account)
    {
        var updateModel = await accountRepository.UpdateAccountAsync(id, account);
        if (updateModel == null)
        {
            return NotFound();
        }

        return Ok(updateModel);
    }

    [HttpDelete]
    [Route ("{id:int}")]
    public async Task<IActionResult> AccountDelete([FromRoute] int id )
    {
        var deleteModels = await accountRepository.DeleteAcccountAsync(id);

        if (deleteModels == null)
        {
            return NotFound();
        }

        return Ok(deleteModels);
    }

    }
}