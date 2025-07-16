using System;
using System.Collections.Generic;

namespace wmdsoftware.Models;

public partial class Visitorregistration
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? ContactNumber { get; set; }

    public string? City { get; set; }

    public string? Company { get; set; }

    public string? Email { get; set; }
}
