﻿namespace Api.Models;

/*Lavet få ændringer siden skabelsen via scaffolding, så at det vil være tættere
 * på hvordan jeg ville havde skrevet det hvis jeg arbejdet med det
 * fra grunden up. fjernet partial, virtual og new.*/
public class Producer
{
    public int Id { get; set; }
    public string Fuldenavn { get; set; } = null!;

    //Alt herunder er database relation
    public ICollection<FilmProducer> FilmProducers{ get; set; }
}

//todo make a DTO, interface, repository and controller for Producer