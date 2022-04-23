﻿using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class OrdersService : IBaseEntity
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int MyOrderId { get; set; }
    public double QuantityWeight { get; set; }
    public double QuantityRadius { get; set; }
    public string? DestinationsAddress { get; set; }
    public string? DeparturesAddress { get; set; }
    public double TotalCost { get; set; }
    public int BeginCityId { get; set; }
    public int EndCityId { get; set; }
}