﻿using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace HrgAuthApi.Dto;

public class UsersDto
{
    public int UserId { get; set; }
    public string Password { get; set; } = default!;
    public int CompanyID { get; set; }
    public int MoadianSubSystemId { get; set; }
    public int InvYear { get; set; }
}
