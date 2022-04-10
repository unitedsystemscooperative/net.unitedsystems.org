﻿using System.ComponentModel.DataAnnotations;

namespace UnitedSystemsCooperative.Web.Shared;

public class Ally
{
    public string Id { get; set; }

    [Required] public string Name { get; set; }
}